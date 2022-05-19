using DataTransferObjects;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbServices
{
    public class DbService : UnitOfWorkService, IDbServise
    {
        private readonly IRepository<PresureMeasurement> _repositoryPressure;
        private readonly IRepository<MeasurementRange> _repositoryRanges;
        public DbService(IRepository<PresureMeasurement> repositoryPressure, 
            IRepository<MeasurementRange> repositoryRanges, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repositoryPressure = repositoryPressure;
            _repositoryRanges = repositoryRanges;
        }

        public void AddPressure(PresureDto presure)
        {
            var range = new MeasurementRange();
            _repositoryRanges.Add(range);
            range.Start = presure.Start;
            range.End = presure.End;
            UnitOfWork.SaveChanges();
            foreach (var item in presure.Presures)
            {
                _repositoryPressure.Add(new PresureMeasurement()
                {
                    Value = item,
                    MeasurementRangeId = range.Id
                }); 
            }
            UnitOfWork.SaveChanges();
        }

        public PresureDto[] GetPressures()
        {
            var pressures = _repositoryRanges.GetAll().Include(x => x.Presures);
            return pressures.Select(x => new PresureDto()
            {
                Start = x.Start,
                End = x.End,
                Presures = x.Presures.Select(x => x.Value).ToList()
            }).ToArray();
        }
    }
}
