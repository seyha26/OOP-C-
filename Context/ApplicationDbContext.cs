using Microsoft.EntityFrameworkCore;
using WebStockManagement.Entities;

namespace WebStockManagement.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Category { get; set; }
}