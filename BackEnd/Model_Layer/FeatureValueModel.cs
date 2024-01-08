using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer
{
	public class FeatureValueModel
	{
		public int ValueId { get; set; }
		public int? ProductId { get; set; }
		public int? FeatureId { get; set; }
		public string ValueName { get; set; } = null!;
	}
}
