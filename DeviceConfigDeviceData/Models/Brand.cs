using System.ComponentModel.DataAnnotations;

namespace DeviceConfigDeviceData;

public class Brand
{
    [Key]
    public int Id { get; set;}
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
