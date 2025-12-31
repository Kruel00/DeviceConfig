
using Microsoft.AspNetCore.Identity;

namespace DeviceConfigUserData;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? EmployeeId { get; set; }
    
}
