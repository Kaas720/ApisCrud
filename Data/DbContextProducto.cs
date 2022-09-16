using ApisCrud.Model;
using Microsoft.EntityFrameworkCore;

namespace ApisCrud.Data
{
    public class DbContextProducto : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextProducto(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<Producto> producto { get; set; }
        public DbSet<Mascotas> mascotas { get; set; }
    }
}
