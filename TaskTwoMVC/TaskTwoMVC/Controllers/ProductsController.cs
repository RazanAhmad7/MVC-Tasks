using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskTwoMVC.Data;
using TaskTwoMVC.Models;

namespace TaskTwoMVC.Controllers
{
	public class ProductsController : Controller
	{
		private readonly MyDbContext _context;

		public ProductsController(MyDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _context.Products.Include(p => p.Categories).ToListAsync());
		}

		public IActionResult Create()
		{
			ViewData["Categories"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Id, Name, Price, CategoryId")] Products product, IFormFile imageFile)
		{

			if (imageFile != null && imageFile.Length > 0)
			{
				var fileName = Path.GetFileName(imageFile.FileName);
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await imageFile.CopyToAsync(stream);
				}

				product.ProductImagePath = "/images/" + fileName;
			}

			_context.Add(product);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(int id)
		{
			var category = await _context.Products.FindAsync(id);
			if (category != null)
			{
				_context.Products.Remove(category);
				await _context.SaveChangesAsync();
			}
			return RedirectToAction("Index");
		}
	}
}
