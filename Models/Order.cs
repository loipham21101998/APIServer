using System;
using System.Collections.Generic;

namespace DigitalPhotoPrinting.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public string? Status { get; set; }
        public double? Total { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
