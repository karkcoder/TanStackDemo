using Microsoft.EntityFrameworkCore;

namespace TestApp.Model
{
	public class InsuranceDbContext : DbContext
	{
		public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options)
			: base(options)
		{
		}

		// DbSet for your InsuranceMember model
		public DbSet<InsuranceMember> InsuranceMembers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			// Additional configurations (if needed)
		}
	}
}