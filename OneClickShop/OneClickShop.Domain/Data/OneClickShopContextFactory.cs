using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OneClickShop.Domain.Data
{
    class OneClickShopContextFactory : IDesignTimeDbContextFactory<OneClickSContext>
    {
        public OneClickSContext CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<OneClickSContext>();

            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../OneClickShop.Api"))
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new OneClickSContext(optionsBuilder.Options);
        }
    }
}