using Microsoft.EntityFrameworkCore;

namespace DOTNET_Training.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions <DataContext> options) : base (options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress; Database=EcommerceDB; Trusted_Connection=true; TrustServerCertificate=true;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
