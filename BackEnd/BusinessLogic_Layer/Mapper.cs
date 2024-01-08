using Entity_Layer.Entities;
using Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic_Layer
{
	public class Mapper
	{
		// Model to Entity

		public static Category MECategoryMapper(CategoryModel model)
		{
			return new Category()
			{
				CategoryId = model.CategoryId,
				CategoryName = model.CategoryName
			};
		}

		public static ProductType MEProductTypeMapper(ProductTypeModel model)
		{
			return new ProductType()
			{
				TypeId = model.TypeId,
				CategoryId = model.CategoryId,
				TypeName = model.TypeName
			};
		}

		public static Feature MEFeatureMapper(FeatureModel model)
		{
			return new Feature()
			{
				FeatureId = model.FeatureId,
				TypeId = model.TypeId,
				FeatureName = model.FeatureName
			};
		}

		public static Product MEProductMapper(ProductModel model)
		{
			return new Product()
			{
				ProductId = model.ProductId,
				CategoryId= model.CategoryId,
				TypeId= model.TypeId,
				ProductName = model.ProductName,
				Price = model.Price,
				Stock = model.Stock,
				BrandName = model.BrandName
			};
		}

		public static FeatureValue MEFeatureValueMapper(FeatureValueModel model)
		{
			return new FeatureValue()
			{
				ValueId = model.ValueId,
				ProductId = model.ProductId,
				FeatureId = model.FeatureId,
				ValueName = model.ValueName
			};
		}


		// Entity to Model

		public static CategoryModel EMCategoryMapper(Category entity)
		{
			return new CategoryModel()
			{
				CategoryId = entity.CategoryId,
				CategoryName = entity.CategoryName
			};
		}

		public static ProductTypeModel EMProductTypeMapper(ProductType entity)
		{
			return new ProductTypeModel()
			{
				TypeId = entity.TypeId,
				CategoryId = entity.CategoryId,
				TypeName = entity.TypeName
			};
		}

		public static FeatureModel EMFeatureMapper(Feature entity)
		{
			return new FeatureModel()
			{
				FeatureId = entity.FeatureId,
				TypeId = entity.TypeId,
				FeatureName = entity.FeatureName
			};
		}

		public static ProductModel EMProductMapper(Product entity)
		{
			return new ProductModel()
			{
				ProductId = entity.ProductId,
				CategoryId = entity.CategoryId,
				TypeId = entity.TypeId,
				ProductName = entity.ProductName,
				Price = entity.Price,
				Stock = entity.Stock,
				BrandName = entity.BrandName
			};
		}

		public static FeatureValueModel EMFeatureValueMapper(FeatureValue entity)
		{
			return new FeatureValueModel()
			{
				ValueId = entity.ValueId,
				ProductId = entity.ProductId,
				FeatureId = entity.FeatureId,
				ValueName = entity.ValueName
			};
		}
	}
}
