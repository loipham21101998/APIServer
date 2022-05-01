using System;
using System.Collections.Generic;

namespace DigitalPhotoPrinting.Models
{
    public partial class Combo
    {
        public Combo()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
