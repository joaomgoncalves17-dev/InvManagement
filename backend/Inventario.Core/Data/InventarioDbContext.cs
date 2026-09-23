using Microsoft.EntityFrameworkCore;
using Inventario.Core.Models;

namespace Inventario.Core.Data;

public class InventarioDbContext : DbContext
{
    public InventarioDbContext(DbContextOptions<InventarioDbContext> options) : base(options)
    {
    }

    public DbSet<Produto> Produtos => Set<Produto>();
}