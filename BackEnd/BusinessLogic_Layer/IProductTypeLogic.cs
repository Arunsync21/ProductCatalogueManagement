using Entity_Layer.Entities;
using Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer
{
	public interface IProductTypeLogic
	{
		public ProductTypeModel AddProductType(ProductTypeModel productType);
		public ProductTypeModel UpdateProductType(ProductTypeModel productType);
		public List<ProductTypeModel> GetAllProductTypes();
		public ProductTypeModel GetProductTypeById(int id);
		public List<ProductTypeModel> GetProductTypeByCategory(int categoryId);
	}
}
