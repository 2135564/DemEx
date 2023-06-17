using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Resources;

namespace DemEx.Models
{
    public partial class Product
    {
        private string? _photo;
        public Product()
        {
            ProductSales = new HashSet<ProductSale>();
        }

        public int Id { get; set; }

        public string? Photo
        {
            get
            {
                if (_photo == null || _photo == string.Empty)
                    return "\\Resources\\Image.png";
                else return "\\Resources\\" + _photo;
            }
            set 
            {
                if (value == null || value == string.Empty || value == "\\Resources\\Image.png")
                    _photo = null;
                else _photo = value.Replace("\\Resources\\", "");
            }
        }

        public string Title { get; set; } = null!;
        public string? Decription { get; set; }
        public decimal Cost { get; set; }
        public int? Discount { get; set; }
        public int ManufacturerId { get; set; }
        public int CountInStock { get; set; }

        public virtual Manufacturer Manufacturer { get; set; } = null!;
        public virtual ICollection<ProductSale> ProductSales { get; set; }

        [NotMapped]

        public decimal? CostDiscount
        {
            get 
            {
                if (Discount != null)
                    return Cost - (Cost / 100 * Discount);
                return null;
            }
        }
    }
}
