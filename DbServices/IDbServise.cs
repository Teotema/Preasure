using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbServices
{
    public interface IDbServise
    {
        public PresureDto[] GetPressures();
        public void AddPressure(PresureDto presure);
    }
}
