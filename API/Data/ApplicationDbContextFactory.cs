using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-PQS7IE6\\SQLEXPRESS;Database=bookstore;Trusted_Connection=True;TrustServerCertificate=true;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
