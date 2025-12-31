using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceConfigApi;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class SecureController 
{
   
    [HttpGet("SecureData")]
    public string Get() => "This is secure data accessible only to authenticated users.";

}
