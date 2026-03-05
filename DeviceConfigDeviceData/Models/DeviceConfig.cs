using DeviceConfigDeviceData.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeviceConfigDeviceData.Models
{
    public class DeviceConfig
    {
        [Key]
        public int Index { get; set; }

        [NotMapped]
        public List<IConfigItem> Items { get; set; } = new();

    }
}
