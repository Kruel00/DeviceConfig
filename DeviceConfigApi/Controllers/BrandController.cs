using DeviceConfigDeviceData;
using Microsoft.AspNetCore.Mvc;

namespace DeviceConfigApi;

[ApiController]
[Route("[controller]")]
public class BrandController: Controller
{
    private readonly DeviceDataContext _context;

    public BrandController(DeviceDataContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public IActionResult GetBrandById(int id)
    {
        var brand = _context.Brands.Find(id);
        if (brand == null)
        {
            return NotFound();
        }
        return Ok(brand);
    }
    
    [HttpPost("NewBrand")]
    public async Task<IActionResult> Create(Brand brand)
    {
        _context.Brands.Add(brand);
        await _context.SaveChangesAsync();
        return Ok(brand);
    }
}
