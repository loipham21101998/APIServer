using System;
using System.Collections.Generic;

namespace DigitalPhotoPrinting.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? Date { get; set; }
        public string? Author { get; set; }
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
    }
}
