using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using myapp.Models;

namespace myapp.Data;

public class ApplicationDbaContext : IdentityDbContext
{
    public ApplicationDbaContext(DbContextOptions<ApplicationDbaContext> options)
        : base(options)
    {
    }

    public DbSet<Registro> DataRegistro { get; set; }

}