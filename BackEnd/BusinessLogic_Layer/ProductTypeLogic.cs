using Entity_Layer;
using Entity_Layer.Entities;
using Model_Layer;

namespace BusinessLogic_Layer
{
	public class ProductTypeLogic: IProductTypeLogic
	{
		IProductTypeRepo productTypeRepo = new ProductTypeRepo();

		public ProductTypeModel AddProductType(ProductTypeModel productType)
		{
			return Mapper.EMProductTypeMapper(productTypeRepo.AddProductType(Mapper.MEProductTypeMapper(productType)));
		}

		public List<ProductTypeModel> GetAllProductTypes()
		{
			List<ProductTypeModel> productTypes = new List<ProductTypeModel>();

			foreach (var productType in productTypeRepo.GetAllProductTypes())
			{
				productTypes.Add(Mapper.EMProductTypeMapper(productType));
			}

			return productTypes;
		}

		public List<ProductTypeModel> GetProductTypeByCategory(int categoryId)
		{
			List<ProductTypeModel> productTypes = new List<ProductTypeModel>();

			foreach (var productType in productTypeRepo.GetProductTypeByCategory(categoryId))
			{
				productTypes.Add(Mapper.EMProductTypeMapper(productType));
			}
			return productTypes;
		}

		public ProductTypeModel GetProductTypeById(int id)
		{
			return Mapper.EMProductTypeMapper(productTypeRepo.GetProductTypeById(id));
		}

		public ProductTypeModel UpdateProductType(ProductTypeModel productType)
		{
			return Mapper.EMProductTypeMapper(productTypeRepo.UpdateProductTpe(Mapper.MEProductTypeMapper(productType)));
		}
	}
}