using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceConfigDeviceData.Interfaces
{
    public interface IConfigItem
    {
        string Name { get; }
        object GetValue();
    }
}
