using Entity_Layer.Entities;
using Entity_Layer;
using Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer
{
	public class ProductLogic : IProductLogic
	{
		IProductRepo productRepo = new ProductRepo();
		public ProductModel AddProduct(ProductModel product)
		{
			return Mapper.EMProductMapper(productRepo.AddProduct(Mapper.MEProductMapper(product)));
		}

		public void DeleteProduct(int id)
		{
			productRepo.DeleteProduct(id);
		}

		public List<ProductModel> GetAllProducts()
		{
			List<ProductModel> products = new List<ProductModel>();

			foreach (var product in productRepo.GetAllProducts())
			{
				products.Add(Mapper.EMProductMapper(product));
			}

			return products;
		}

		public List<ProductModel> GetProductByCategory(int categoryId)
		{
			List<ProductModel> products = new List<ProductModel>();

			foreach (var product in productRepo.GetProductByCategory(categoryId))
			{
				products.Add(Mapper.EMProductMapper(product));
			}
			return products;
		}

		public ProductModel GetProductById(int id)
		{
			return Mapper.EMProductMapper(productRepo.GetProductById(id));
		}

		public List<ProductModel> GetProductByProductType(int typeId)
		{
			List<ProductModel> products = new List<ProductModel>();
			foreach (var product in productRepo.GetProductByProductType(typeId))
			{
				products.Add(Mapper.EMProductMapper(product));
			}
			return products;
		}

		public ProductModel UpdateProduct(ProductModel product)
		{
			return Mapper.EMProductMapper(productRepo.UpdateProduct(Mapper.MEProductMapper(product)));
		}
	}
}
