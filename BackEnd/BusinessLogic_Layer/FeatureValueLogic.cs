using Entity_Layer;
using Entity_Layer.Entities;
using Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer
{
	public class FeatureValueLogic : IFeatureValueLogic
	{
		IFeatureValueRepo featureValueRepo = new FeatureValueRepo();
		public FeatureValueModel AddFeatureValue(FeatureValueModel featureValue)
		{
			return Mapper.EMFeatureValueMapper(featureValueRepo.AdddFeatureValue(Mapper.MEFeatureValueMapper(featureValue)));
		}

		public void DeleteFeatureValue(int id)
		{
			featureValueRepo.DeleteFeatureValue(id);
		}

		public List<FeatureValueModel> GetFeatureValuesByProduct(int productId)
		{
			List<FeatureValueModel> featureValues = new List<FeatureValueModel>();

			foreach (var featureValue in featureValueRepo.GetFeatureValuesByProduct(productId))
			{
				featureValues.Add(Mapper.EMFeatureValueMapper(featureValue));
			}
			return featureValues;
		}

		public FeatureValueModel UpdateFeatureValue(FeatureValueModel featureValue)
		{
			return Mapper.EMFeatureValueMapper(featureValueRepo.UpdateFeatureValue(Mapper.MEFeatureValueMapper(featureValue)));
		}
	}
}
