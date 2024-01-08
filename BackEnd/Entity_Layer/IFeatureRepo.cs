using Entity_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
	public interface IFeatureRepo
	{
		public Feature AddFeature(Feature feature);
		public Feature UpdateFeature(Feature feature);
		public List<Feature> GetFeaturesByProductType(int typeId);
	}
}
