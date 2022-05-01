using System;
using System.Collections.Generic;

namespace DigitalPhotoPrinting.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public double? Rate { get; set; }
        public int AccountId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Account Account { get; set; } = null!;
    }
}
