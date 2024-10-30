using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskTwoMVC.Models;

namespace TaskTwoMVC.Data
{
	public class MyDbContext : DbContext
	{

        
		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

		public DbSet<Categories> Categories { get; set; }
		public DbSet<Products> Products { get; set; }
	}
}
