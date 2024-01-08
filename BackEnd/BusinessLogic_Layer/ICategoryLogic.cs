using Entity_Layer.Entities;
using Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer
{
	public interface ICategoryLogic
	{
		public CategoryModel AddCategory(CategoryModel category);
		public CategoryModel UpdateCategory(CategoryModel category);
		public List<CategoryModel> GetAllCategories();
		public CategoryModel GetCategoryById(int id);
	}
}
