using System;
using System.Collections.Generic;

namespace Entity_Layer.Entities
{
    public partial class Category
    {
        public Category()
        {
            ProductTypes = new HashSet<ProductType>();
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<ProductType> ProductTypes { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
