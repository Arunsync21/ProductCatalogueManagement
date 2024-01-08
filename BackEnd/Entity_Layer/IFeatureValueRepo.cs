using Entity_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
	public interface IFeatureValueRepo
	{
		public FeatureValue AdddFeatureValue(FeatureValue featureValue);
		public FeatureValue UpdateFeatureValue(FeatureValue featureValue);
		public List<FeatureValue> GetFeatureValuesByProduct(int productId);
		public void DeleteFeatureValue(int id);
	}
}
