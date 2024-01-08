using System;
using System.Collections.Generic;

namespace Entity_Layer.Entities
{
    public partial class Product
    {
        public Product()
        {
            FeatureValues = new HashSet<FeatureValue>();
        }

        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public int? TypeId { get; set; }
        public string ProductName { get; set; } = null!;
        public double? Price { get; set; }
        public int? Stock { get; set; }
        public string? BrandName { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ProductType? Type { get; set; }
        public virtual ICollection<FeatureValue> FeatureValues { get; set; }
    }
}
