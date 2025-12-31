using DeviceConfigDeviceData;
using Microsoft.AspNetCore.Mvc;

namespace DeviceConfigApi;

public class DeviceController : ControllerBase
{

private readonly DeviceDataContext _context;

    public DeviceController(DeviceDataContext context)
    {
        _context = context;
    }


    [HttpGet("{id}")]
    public IActionResult GetDeviceById(int id)
    {
        var device = _context.Devices.Find(id);
        if (device == null)
        {
            return NotFound();
        }
        return Ok(device);
    }

    [HttpPost("NewDevice")]
    public async Task<IActionResult> Create(Device device)
    {
        _context.Devices.Add(device);
        await _context.SaveChangesAsync();
        return Ok(device);
    }   

}
