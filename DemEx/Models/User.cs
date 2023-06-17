using System;
using System.Collections.Generic;

namespace DemEx.Models
{
    public partial class User
    {
        public User()
        {
            ProductSales = new HashSet<ProductSale>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<ProductSale> ProductSales { get; set; }
    }
}
