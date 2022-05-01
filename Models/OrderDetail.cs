using System;
using System.Collections.Generic;

namespace DigitalPhotoPrinting.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int ImageId { get; set; }
        public int Sizeid { get; set; }
        public int MaterialId { get; set; }
        public string? Payment { get; set; }
        public int? Quantity { get; set; }
        public string? Status { get; set; }

        public virtual Image Image { get; set; } = null!;
        public virtual Material Material { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
        public virtual Size Size { get; set; } = null!;
    }
}
