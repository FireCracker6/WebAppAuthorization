using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppAuthorization.Models.Entities;

namespace WebAppAuthorization.Contexts;

public class IdentityContext : IdentityDbContext
{
	public IdentityContext(DbContextOptions options) : base(options)
	{
	}
	public DbSet<UserProfileEntity> UserProfiles { get; set; }
}
