using System;
using System.Collections.Generic;

namespace Entity_Layer.Entities
{
    public partial class Feature
    {
        public Feature()
        {
            FeatureValues = new HashSet<FeatureValue>();
        }

        public int FeatureId { get; set; }
        public int? TypeId { get; set; }
        public string FeatureName { get; set; } = null!;

        public virtual ProductType? Type { get; set; }
        public virtual ICollection<FeatureValue> FeatureValues { get; set; }
    }
}
