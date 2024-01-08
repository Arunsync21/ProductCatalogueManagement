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
	public class FeatureLogic : IFeatureLogic
	{
		IFeatureRepo featureRepo = new FeatureRepo();

		public FeatureModel AddFeature(FeatureModel feature)
		{
			return Mapper.EMFeatureMapper(featureRepo.AddFeature(Mapper.MEFeatureMapper(feature)));
		}

		public List<FeatureModel> GetFeaturesByProductType(int typeId)
		{
			List<FeatureModel> features = new List<FeatureModel>();

			foreach (var feature in featureRepo.GetFeaturesByProductType(typeId))
			{
				features.Add(Mapper.EMFeatureMapper(feature));
			}
			return features;
		}

		public FeatureModel UpdateFeature(FeatureModel feature)
		{
			return Mapper.EMFeatureMapper(featureRepo.UpdateFeature(Mapper.MEFeatureMapper(feature)));
		}
	}
}
