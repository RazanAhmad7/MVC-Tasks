using System.ComponentModel.DataAnnotations;

namespace TaskTwoMVC.Models
{
	public class Categories
	{
		[Key]
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }

		public string CategoryImagePath { get; set; }

		public ICollection<Products> Products { get; set; }
	}
}
