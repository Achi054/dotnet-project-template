using Microsoft.EntityFrameworkCore;

namespace Custom.Infrastructure
{
	// Generic ApplicationDbContext for EF Core
	public class ApplicationDbContext : DbContext
	{
		// Constructor for dependency injection
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		// Fluent API configuration
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Apply configurations from separate classes (recommended for clean code)
			modelBuilder?.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		}
	}
}
