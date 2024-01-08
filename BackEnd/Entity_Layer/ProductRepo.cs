using Entity_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
	public class ProductRepo : IProductRepo
	{
		ProductCatalogContext productCatalogContext = new ProductCatalogContext();
		public Product AddProduct(Product product)
		{
			productCatalogContext.Products.Add(product);
			productCatalogContext.SaveChanges();
			return product;
		}

		public void DeleteProduct(int id)
		{
			Product product = productCatalogContext.Products.FirstOrDefault(p => p.ProductId == id);
			productCatalogContext.Products.Remove(product);
			productCatalogContext.SaveChanges();
		}

		public List<Product> GetAllProducts()
		{
			return productCatalogContext.Products.ToList();
		}

		public List<Product> GetProductByCategory(int categoryId)
		{
			return productCatalogContext.Products.Where(product => product.CategoryId == categoryId).ToList();
		}

		public Product GetProductById(int id)
		{
			return productCatalogContext.Products.FirstOrDefault(product => product.ProductId == id);
		}

		public List<Product> GetProductByProductType(int typeId)
		{
			return productCatalogContext.Products.Where(product => product.TypeId == typeId).ToList();
		}

		public Product UpdateProduct(Product product)
		{
			productCatalogContext.Products.Update(product);
			productCatalogContext.SaveChanges();
			return product;
		}
	}
}
