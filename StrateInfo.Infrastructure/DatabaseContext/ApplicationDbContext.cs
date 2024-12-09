using Microsoft.EntityFrameworkCore;
using StateInfo.Domain.Models;

namespace StrateInfo.Infrastructure.DatabaseContext;

public class ApplicationDbContext:DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	public DbSet<StateOrganizationModel> Organizations { get; set; }
	public DbSet<Address> Addresses { get; set; }

}
