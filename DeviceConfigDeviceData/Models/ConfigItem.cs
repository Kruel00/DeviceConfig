using DeviceConfigDeviceData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceConfigDeviceData.Models
{
    public class ConfigItem<T> : IConfigItem
    {
        public string Name { get; set; }
        public T Value { get; set; }

        public ConfigItem(string name, T value)
        {
            Name = name;
            Value = value;
        }

        public object GetValue() => Value;
        
    }
    
}
