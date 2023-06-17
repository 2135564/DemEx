using System;
using System.Collections.Generic;

namespace DemEx.Models
{
    public partial class ProductSale
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Number { get; set; }
        public int ProductId { get; set; }
        public int StatusId { get; set; }
        public int PointId { get; set; }
        public DateTime DateOfIsue { get; set; }
        public decimal CostSum { get; set; }
        public DateTime DateOfSale { get; set; }
        public int? DiscountSum { get; set; }

        public virtual Point Point { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
