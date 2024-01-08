using Entity_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
	public class CategoryRepo : ICategoryRepo
	{
		ProductCatalogContext productCatalogContext = new ProductCatalogContext();
		public Category AddCategory(Category category)
		{
			productCatalogContext.Categories.Add(category);
			productCatalogContext.SaveChanges();
			return category;
		}

		public Category UpdateCategory(Category category)
		{
			productCatalogContext.Categories.Update(category);
			productCatalogContext.SaveChanges();
			return category;
		}

		public List<Category> GetAllCategories()
		{
			return productCatalogContext.Categories.ToList();
		}

		public Category GetCategoryById(int id)
		{
			return productCatalogContext.Categories.FirstOrDefault(category => category.CategoryId == id);
		}
	}
}
