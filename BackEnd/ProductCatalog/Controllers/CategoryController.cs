using BusinessLogic_Layer;
using Microsoft.AspNetCore.Mvc;
using Model_Layer;

namespace ProductCatalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		ICategoryLogic categoryLogic = new CategoryLogic();

		[HttpPost("AddCategory")]
		public IActionResult AddCategory([FromBody] CategoryModel categoryModel)
		{
			try
			{
				return Ok(categoryLogic.AddCategory(categoryModel));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetCategories")]
		public IActionResult GetCategories()
		{
			try
			{
				if (categoryLogic.GetAllCategories() != null)
				{
					return Ok(categoryLogic.GetAllCategories());
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

		[HttpGet("GetCategoryByID/{id}")]

		public IActionResult GetCategoryByID([FromRoute] int id)
		{
			try
			{
				var data = categoryLogic.GetCategoryById(id);

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

		[HttpPut("UpdateCategory")]

		public IActionResult UpdateCategory([FromBody] CategoryModel categoryModel)
		{
			try
			{
				var data = categoryLogic.UpdateCategory(categoryModel);
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
