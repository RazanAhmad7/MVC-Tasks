using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskTwoMVC.Data;
using TaskTwoMVC.Models;

namespace TaskTwoMVC.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly MyDbContext _Context;

		public CategoriesController(MyDbContext context)
		{
			_Context = context;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _Context.Categories.ToListAsync());
		}

		public IActionResult Create()
		{
			
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Create([Bind("CategoryId, CategoryName")] Categories category, IFormFile imageFile)
		{
						if (imageFile != null && imageFile.Length > 0)
						{
							var fileName = Path.GetFileName(imageFile.FileName);
							var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

							using (var stream = new FileStream(filePath, FileMode.Create))
							{
								await imageFile.CopyToAsync(stream);
							}

							category.CategoryImagePath = "/images/" + fileName;
						}

						_Context.Add(category);
						await _Context.SaveChangesAsync(); // Ensure this line completes without errors

						return RedirectToAction("Index");
					
				
			}


		public async Task<IActionResult> Delete(int id)
		{
			var category = await _Context.Categories.FindAsync(id);
			if (category != null)
			{
				_Context.Categories.Remove(category);
				await _Context.SaveChangesAsync();
			}
			return RedirectToAction("Index");
		}




		} 
	}
