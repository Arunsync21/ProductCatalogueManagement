using Entity_Layer.Entities;
using Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer
{
	public interface IFeatureLogic
	{
		public FeatureModel AddFeature(FeatureModel feature);
		public FeatureModel UpdateFeature(FeatureModel feature);
		public List<FeatureModel> GetFeaturesByProductType(int typeId);
	}
}
