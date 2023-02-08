using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Strategy.WebApi.Models;

namespace Identity.WebApi.Models;

public class AppIdentityDbContext : IdentityDbContext<AppUser>
{
  public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
  {
    
  }
  public DbSet<Product> Products { get; set; }
}
