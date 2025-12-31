using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DeviceConfigUserData;

public class IdentityDbFactory 
    : IDesignTimeDbContextFactory<IdentityDb>
{
    public IdentityDb CreateDbContext(string[] args)
    {
       var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<IdentityDb>();
        
        optionsBuilder.UseNpgsql(
            configuration.GetConnectionString("IdentityDb") 
            ?? "Server=127.0.0.1;Database=UserData;User Id=postgres;Password=postgres;" 
        );

        return new IdentityDb(optionsBuilder.Options);
    }
}
