using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer
{
	public class FeatureModel
	{
		public int FeatureId { get; set; }
		public int? TypeId { get; set; }
		public string FeatureName { get; set; } = null!;
	}
}
