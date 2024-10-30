using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTwoMVC.Models
{
	public class Products
	{
	
		public int Id { get; set; }
		public string Name { get; set; }
		public string Price { get; set; }
		public string ProductImagePath { get; set; }

		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public Categories Categories { get; set; }

	}
}
