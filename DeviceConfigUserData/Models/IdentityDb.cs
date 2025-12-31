using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DeviceConfigUserData;

public class IdentityDb : IdentityDbContext<User>
{

    public IdentityDb(DbContextOptions<IdentityDb> options) 
        : base(options)
    {
        
    }
}
