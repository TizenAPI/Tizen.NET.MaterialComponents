using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NET.MaterialComponents
{
    public interface IColorSchemeComponent
    {
        void OnColorSchemeChanged(bool fromConstructor = false);
    }
}
