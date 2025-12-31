using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceConfigDeviceData;

public class Device
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? SerialNumber { get; set; }
    public string? Model { get; set; }
    public int BrandId { get; set; }
    [ForeignKey("BrandId")]
    public virtual Brand? Brand { get; set; }
}
