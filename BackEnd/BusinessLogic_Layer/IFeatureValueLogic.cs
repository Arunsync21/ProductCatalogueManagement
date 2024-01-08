using Entity_Layer.Entities;
using Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer
{
	public interface IFeatureValueLogic
	{
		public FeatureValueModel AddFeatureValue(FeatureValueModel featureValue);
		public FeatureValueModel UpdateFeatureValue(FeatureValueModel featureValue);
		public List<FeatureValueModel> GetFeatureValuesByProduct(int productId);
		public void DeleteFeatureValue(int id);
	}
}
