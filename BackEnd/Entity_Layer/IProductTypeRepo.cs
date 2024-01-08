using Entity_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
	public interface IProductTypeRepo
	{
		public ProductType AddProductType(ProductType productType);
		public ProductType UpdateProductTpe(ProductType productType);
		public List<ProductType> GetAllProductTypes();
		public ProductType GetProductTypeById(int id);
		public List<ProductType> GetProductTypeByCategory(int categoryId);
	}
}
