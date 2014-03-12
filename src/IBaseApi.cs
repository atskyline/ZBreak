using System;
using System.Drawing;

namespace ZBreak
{
    interface IBaseApi
    {
        Rectangle GetPrimaryScreenResolution();
        Color GetPixelColor(Int32 x, Int32 y);
    }
}
