using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ServerManagement.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
}