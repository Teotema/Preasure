using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class PressureDbContext : DbContext, IUnitOfWork
    {
        public PressureDbContext(DbContextOptions<PressureDbContext> options) : base(options)
        { }
        void IUnitOfWork.SaveChanges()
        {
            SaveChanges();
        }

        public DbSet<PresureMeasurement>  PresureMeasurements { get; set; }
        public DbSet<MeasurementRange> MeasurementRanges { get; set; }

    }
}
