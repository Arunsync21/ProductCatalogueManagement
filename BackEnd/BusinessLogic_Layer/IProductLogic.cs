using Entity_Layer.Entities;
using Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer
{
	public interface IProductLogic
	{
		public ProductModel AddProduct(ProductModel product);
		public ProductModel UpdateProduct(ProductModel product);
		public List<ProductModel> GetAllProducts();
		public ProductModel GetProductById(int id);
		public List<ProductModel> GetProductByCategory(int categoryId);
		public List<ProductModel> GetProductByProductType(int typeId);
		public void DeleteProduct(int id);
	}
}
