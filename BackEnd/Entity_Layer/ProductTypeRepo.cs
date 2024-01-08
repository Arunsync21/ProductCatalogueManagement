using Entity_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
	public class ProductTypeRepo : IProductTypeRepo
	{
		ProductCatalogContext productCatalogContext = new ProductCatalogContext();
		public ProductType AddProductType(ProductType productType)
		{
			productCatalogContext.ProductTypes.Add(productType);
			productCatalogContext.SaveChanges();
			return productType;
		}

		public List<ProductType> GetAllProductTypes()
		{
			return productCatalogContext.ProductTypes.ToList();
		}

		public List<ProductType> GetProductTypeByCategory(int categoryId)
		{
			return productCatalogContext.ProductTypes.Where(productType => productType.CategoryId == categoryId).ToList();
		}

		public ProductType GetProductTypeById(int id)
		{
			return productCatalogContext.ProductTypes.FirstOrDefault(productType => productType.TypeId == id);
		}

		public ProductType UpdateProductTpe(ProductType productType)
		{
			productCatalogContext.ProductTypes.Update(productType);
			productCatalogContext.SaveChanges();
			return productType;
		}
	}
}
