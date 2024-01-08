using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer
{
	public class ProductModel
	{
		public int ProductId { get; set; }
		public int? CategoryId { get; set; }
		public int? TypeId { get; set; }
		public string ProductName { get; set; } = null!;
		public double? Price { get; set; }
		public int? Stock { get; set; }
		public string? BrandName { get; set; }
	}
}
