using MAUI.AutoDI.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAUI.AutoDI.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ServiceLifetimeAttribute : Attribute
    {
        public ServiceLifetimeType Lifetime { get; }

        public ServiceLifetimeAttribute(ServiceLifetimeType lifetime)
        {
            Lifetime = lifetime;
        }
    }
}
