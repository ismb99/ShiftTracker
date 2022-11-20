using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.API.Models.DTOs
{
    public class ShiftDTO
    {
        //public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Location { get; set; }
        public decimal Pay { get; set; }
        public decimal Minutes { get; set; }
    }
}
