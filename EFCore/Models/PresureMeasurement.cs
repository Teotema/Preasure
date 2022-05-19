using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class PresureMeasurement
    {
        public int Id { get; set; }

        [ForeignKey(nameof(MeasurementRange))]
        public int MeasurementRangeId { get; set; }
        public float Value { get; set; }
    }
}
