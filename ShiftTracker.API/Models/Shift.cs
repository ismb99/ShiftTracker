using System.ComponentModel.DataAnnotations;

namespace ShiftTracker.API.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal Pay { get; set; }
        public decimal Minutes { get; set; }
        public string Location { get; set; }

    }
}
