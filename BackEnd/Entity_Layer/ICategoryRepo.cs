using Entity_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
	public interface ICategoryRepo
	{
		public Category AddCategory(Category category);
		public Category UpdateCategory(Category category);
		public List<Category> GetAllCategories();
		public Category GetCategoryById(int id);
	}
}
