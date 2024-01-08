using System;
using System.Collections.Generic;

namespace Entity_Layer.Entities
{
    public partial class ProductType
    {
        public ProductType()
        {
            Features = new HashSet<Feature>();
            Products = new HashSet<Product>();
        }

        public int TypeId { get; set; }
        public int? CategoryId { get; set; }
        public string TypeName { get; set; } = null!;

        public virtual Category? Category { get; set; }
        public virtual ICollection<Feature> Features { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
