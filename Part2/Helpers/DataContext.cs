
using ProductsWebApplication.Entities;

namespace ProductsWebApplication.Helpers;

using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionString = Configuration.GetConnectionString("WebApiDatabase");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}