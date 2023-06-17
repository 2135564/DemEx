using System;
using System.Collections.Generic;

namespace DemEx.Models
{
    public partial class Status
    {
        public Status()
        {
            ProductSales = new HashSet<ProductSale>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<ProductSale> ProductSales { get; set; }
    }
}
