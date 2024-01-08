using BusinessLogic_Layer;
using Microsoft.AspNetCore.Mvc;
using Model_Layer;

namespace ProductCatalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		IProductLogic productLogic = new ProductLogic();

		[HttpPost("AddProduct")]
		public IActionResult AddProduct([FromBody] ProductModel productModel)
		{
			try
			{
				return Ok(productLogic.AddProduct(productModel));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetProducts")]
		public IActionResult GetProducts()
		{
			try
			{
				if (productLogic.GetAllProducts() != null)
				{
					return Ok(productLogic.GetAllProducts());
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

		[HttpGet("GetProductByID/{id}")]

		public IActionResult GetProductByID([FromRoute] int id)
		{
			try
			{
				var data = productLogic.GetProductById(id);

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

		[HttpGet("GetProductByCategory/{categoryId}")]

		public IActionResult GetProductByCategory([FromRoute] int categoryId)
		{
			try
			{
				var data = productLogic.GetProductByCategory(categoryId);

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

		[HttpGet("GetProductByProductType/{typeId}")]

		public IActionResult GetProductByProductType([FromRoute] int typeId)
		{
			try
			{
				var data = productLogic.GetProductByProductType(typeId);

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

		[HttpPut("UpdateProduct")]

		public IActionResult UpdateProduct([FromBody] ProductModel productModel)
		{
			try
			{
				var data = productLogic.UpdateProduct(productModel);
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

		[HttpDelete("DeleteProduct/{id}")]
		public IActionResult DeleteProduct([FromRoute] int id)
		{
			try
			{
				productLogic.DeleteProduct(id);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
