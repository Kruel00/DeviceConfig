using Microsoft.EntityFrameworkCore;

namespace DeviceConfigDeviceData;

public class DeviceDataContext : DbContext
{
     public DeviceDataContext(DbContextOptions<DeviceDataContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Device> Devices => Set<Device>();
}
