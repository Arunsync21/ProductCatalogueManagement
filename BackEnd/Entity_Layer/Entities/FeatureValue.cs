using System;
using System.Collections.Generic;

namespace Entity_Layer.Entities
{
    public partial class FeatureValue
    {
        public int ValueId { get; set; }
        public int? ProductId { get; set; }
        public int? FeatureId { get; set; }
        public string ValueName { get; set; } = null!;

        public virtual Feature? Feature { get; set; }
        public virtual Product? Product { get; set; }
    }
}
