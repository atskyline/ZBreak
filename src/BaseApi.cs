using System.Drawing;
using System.Windows.Forms;

namespace ZBreak
{
    class BaseApi : IBaseApi
    {
        public Rectangle GetPrimaryScreenResolution()
        {
            return Screen.PrimaryScreen.Bounds;
        }

        public Color GetPixelColor(int x, int y)
        {
            return Win32.GetPixelColor(x, y);
        }
    }
}
