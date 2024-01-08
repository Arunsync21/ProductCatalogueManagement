using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer
{
	public class ProductTypeModel
	{
		public int TypeId { get; set; }
		public int? CategoryId { get; set; }
		public string TypeName { get; set; } = null!;
	}
}
