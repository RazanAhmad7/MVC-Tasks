
using Microsoft.EntityFrameworkCore;
using TaskOneMVC.Models;

namespace TaskOneMVC.Data
{
	public class TaskDbContext : DbContext
	{
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
            
        }

		public DbSet<Department> Items { get; set; }  // the tabel on the database


	}
}
