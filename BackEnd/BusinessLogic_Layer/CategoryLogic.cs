using Entity_Layer;
using Model_Layer;

namespace BusinessLogic_Layer
{
	public class CategoryLogic: ICategoryLogic
	{
		ICategoryRepo categoryRepo = new CategoryRepo();

		public CategoryModel AddCategory(CategoryModel category)
		{
			return Mapper.EMCategoryMapper(categoryRepo.AddCategory(Mapper.MECategoryMapper(category)));
		}

		public List<CategoryModel> GetAllCategories()
		{
			List<CategoryModel> categories = new List<CategoryModel>();

			foreach (var cat in categoryRepo.GetAllCategories())
			{
				categories.Add(Mapper.EMCategoryMapper(cat));
			}

			return categories;
		}

		public CategoryModel GetCategoryById(int id)
		{
			return Mapper.EMCategoryMapper(categoryRepo.GetCategoryById(id));
		}

		public CategoryModel UpdateCategory(CategoryModel category)
		{
			return Mapper.EMCategoryMapper(categoryRepo.UpdateCategory(Mapper.MECategoryMapper(category)));
		}
	}
}