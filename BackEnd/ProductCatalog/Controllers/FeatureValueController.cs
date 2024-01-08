using BusinessLogic_Layer;
using Microsoft.AspNetCore.Mvc;
using Model_Layer;

namespace ProductCatalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureValueController : ControllerBase
	{
		IFeatureValueLogic featureValueLogic = new FeatureValueLogic();

		[HttpPost("AddFeatureValue")]
		public IActionResult AddFeatureValue([FromBody] FeatureValueModel featureValueModel)
		{
			try
			{
				return Ok(featureValueLogic.AddFeatureValue(featureValueModel));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetFeatureValueByProduct/{productId}")]

		public IActionResult GetFeatureValueByProduct([FromRoute] int productId)
		{
			try
			{
				var data = featureValueLogic.GetFeatureValuesByProduct(productId);

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

		[HttpPut("UpdateFeatureValue")]

		public IActionResult UpdateFeatureValue([FromBody] FeatureValueModel featureValueModel)
		{
			try
			{
				var data = featureValueLogic.UpdateFeatureValue(featureValueModel);
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

		[HttpDelete("DeleteFeatureValue/{id}")]
		public IActionResult DeleteFeatureValue([FromRoute] int id)
		{
			try
			{
				featureValueLogic.DeleteFeatureValue(id);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
