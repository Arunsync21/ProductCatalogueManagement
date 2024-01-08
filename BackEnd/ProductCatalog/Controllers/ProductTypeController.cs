using BusinessLogic_Layer;
using Microsoft.AspNetCore.Mvc;
using Model_Layer;

namespace ProductCatalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductTypeController : ControllerBase
	{
		IProductTypeLogic productTypeLogic = new ProductTypeLogic();

		[HttpPost("AddProductType")]
		public IActionResult AddProductType([FromBody] ProductTypeModel productTypeModel)
		{
			try
			{
				return Ok(productTypeLogic.AddProductType(productTypeModel));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetProductTypes")]
		public IActionResult GetProductTypes()
		{
			try
			{
				if (productTypeLogic.GetAllProductTypes() != null)
				{
					return Ok(productTypeLogic.GetAllProductTypes());
				}
				else
				{
					return BadRequest();
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetProductTypeByID/{id}")]

		public IActionResult GetProductTypeByID([FromRoute] int id)
		{
			try
			{
				var data = productTypeLogic.GetProductTypeById(id);

				if (data != null)
				{
					return Ok(data);
				}
				else
				{
					return NotFound();
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetProductTypeByCategory/{categoryId}")]

		public IActionResult GetProductTypeByCategory([FromRoute] int categoryId)
		{
			try
			{
				var data = productTypeLogic.GetProductTypeByCategory(categoryId);

				if (data != null)
				{
					return Ok(data);
				}
				else
				{
					return NotFound();
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("UpdateProductType")]

		public IActionResult UpdateProductType([FromBody] ProductTypeModel productTypeModel)
		{
			try
			{
				var data = productTypeLogic.UpdateProductType(productTypeModel);
				if (data != null)
				{
					return Ok(data);
				}
				else
				{
					return BadRequest();
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
