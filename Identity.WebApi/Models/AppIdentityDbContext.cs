using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.WebApi.Models;

public class AppIdentityDbContext : IdentityDbContext<AppUser>
{
  public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
  {
    
  }
}
