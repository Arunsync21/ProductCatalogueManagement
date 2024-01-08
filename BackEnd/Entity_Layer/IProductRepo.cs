using Entity_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
	public interface IProductRepo
	{
		public Product AddProduct(Product product);
		public Product UpdateProduct(Product product);
		public List<Product> GetAllProducts();
		public Product GetProductById(int id);
		public List<Product> GetProductByCategory(int categoryId);
		public List<Product> GetProductByProductType(int typeId);
		public void DeleteProduct(int id);
	}
}
