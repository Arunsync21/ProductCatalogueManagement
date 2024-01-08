using Entity_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
	public class FeatureValueRepo : IFeatureValueRepo
	{
		ProductCatalogContext productCatalogContext = new ProductCatalogContext();
		public FeatureValue AdddFeatureValue(FeatureValue featureValue)
		{
			productCatalogContext.FeatureValues.Add(featureValue);
			productCatalogContext.SaveChanges();
			return featureValue;
		}

		public void DeleteFeatureValue(int id)
		{
			FeatureValue featureValue = productCatalogContext.FeatureValues.FirstOrDefault(value => value.ValueId == id);
			productCatalogContext.FeatureValues.Remove(featureValue);
			productCatalogContext.SaveChanges();
		}

		public List<FeatureValue> GetFeatureValuesByProduct(int productId)
		{
			return productCatalogContext.FeatureValues.Where(featureValue => featureValue.ProductId == productId).ToList();
		}

		public FeatureValue UpdateFeatureValue(FeatureValue featureValue)
		{
			productCatalogContext.FeatureValues.Update(featureValue);
			productCatalogContext.SaveChanges();
			return featureValue;
		}
	}
}
