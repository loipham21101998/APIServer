using System;
using System.Collections.Generic;

namespace DigitalPhotoPrinting.Models
{
    public partial class Image
    {
        public Image()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Date { get; set; }
        public int? AccountId { get; set; }
        public string? FolderName { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
