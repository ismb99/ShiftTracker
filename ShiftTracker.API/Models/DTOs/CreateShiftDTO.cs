using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftTracker.API.Models.DTOs
{
    public class CreateShiftDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Location { get; set; }
    }
}
