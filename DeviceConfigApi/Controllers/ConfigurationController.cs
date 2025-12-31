using DeviceConfigDeviceData;
using Microsoft.AspNetCore.Mvc;

namespace DeviceConfigApi;

[ApiController]
[Route("[controller]")]
public class ConfigurationController  : ControllerBase
{

    private readonly DeviceDataContext _context;

    public ConfigurationController(DeviceDataContext context)
    {
        _context = context;
    }
    

    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        return Ok("Configuration API is running.");
    }

    

}
