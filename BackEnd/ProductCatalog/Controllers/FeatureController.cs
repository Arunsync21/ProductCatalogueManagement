using BusinessLogic_Layer;
using Microsoft.AspNetCore.Mvc;
using Model_Layer;

namespace ProductCatalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureController : ControllerBase
	{
		IFeatureLogic featureLogic = new FeatureLogic();

		[HttpPost("AddFeature")]
		public IActionResult AddFeature([FromBody] FeatureModel featureModel)
		{
			try
			{
				return Ok(featureLogic.AddFeature(featureModel));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetFeatureByProductType/{typeId}")]

		public IActionResult GetFeatureByProductType([FromRoute] int typeId)
		{
			try
			{
				var data = featureLogic.GetFeaturesByProductType(typeId);

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

		[HttpPut("UpdateFeature")]

		public IActionResult UpdateFeature([FromBody] FeatureModel featureModel)
		{
			try
			{
				var data = featureLogic.UpdateFeature(featureModel);
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
