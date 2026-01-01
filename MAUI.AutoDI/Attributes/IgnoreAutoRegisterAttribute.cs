using System;
using System.Collections.Generic;
using System.Text;

namespace MAUI.AutoDI.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class IgnoreAutoRegisterAttribute : Attribute
    {
    }
}
