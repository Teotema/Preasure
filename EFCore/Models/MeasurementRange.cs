using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class MeasurementRange
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public List<PresureMeasurement> Presures { get; set; }
    }
}
