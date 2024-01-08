using Entity_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
	public class FeatureRepo: IFeatureRepo
	{
		ProductCatalogContext productCatalogContext = new ProductCatalogContext();

		public Feature AddFeature(Feature feature)
		{
			productCatalogContext.Features.Add(feature);
			productCatalogContext.SaveChanges();
			return feature;
		}

		public Feature UpdateFeature(Feature feature)
		{
			productCatalogContext.Features.Update(feature);
			productCatalogContext.SaveChanges();
			return feature;
		}

		public List<Feature> GetFeaturesByProductType(int typeId)
		{
			return productCatalogContext.Features.Where(feature => feature.TypeId == typeId).ToList();
		}
	}
}
