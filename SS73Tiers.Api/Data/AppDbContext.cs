using System;
using Microsoft.EntityFrameworkCore;
using SS73Tiers.Api.Models;

namespace SS73Tiers.Api.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
		{
		}
		public DbSet<Position> Position { get; set; }
		public DbSet<Department> Department { get; set; }
		public DbSet<Employee> Employee { get; set; }
	}
}

