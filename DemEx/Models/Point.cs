using System;
using System.Collections.Generic;

namespace DemEx.Models
{
    public partial class Point
    {
        public Point()
        {
            ProductSales = new HashSet<ProductSale>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<ProductSale> ProductSales { get; set; }
    }
}
