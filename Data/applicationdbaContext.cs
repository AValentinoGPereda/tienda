using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using myapp.Models;

namespace myapp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Registro> DataRegistro { get; set; }
    public DbSet<Contactos> DataContacto { get; set; }

    public DbSet<Producto> DataProductos { get; set; }
    public DbSet<Proforma> DataProformas { get; set; }

    public DbSet<Pago> DataPago { get; set; }

    public DbSet<Pedido> DataPedido { get; set; }

    public DbSet<DetallePedido> DataDetallePedido { get; set; } 
}