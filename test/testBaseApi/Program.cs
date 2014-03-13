using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace testBaseApi
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private static void TestSystemSound()
        {
            System.Media.SystemSounds.Beep.Play();
            Console.ReadLine();
        }

        private static void TestTakeShot()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                Color pixel = bitmap.GetPixel(0, 0);
                Console.WriteLine(pixel);
            }
        }

        private static void TestGetResolution()
        {
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            Console.WriteLine(resolution);
            //多屏幕支持 var someScreen = Screen.AllScreens[i];
        }

        private static void TestGetPixelColor()
        {
            Color color = Win32.GetPixelColor(100, 0);
            Console.WriteLine(color);
        }

        private static void TestTimerPixelColor()
        {
            Timer timer = new Timer((state) =>
            {
                Console.WriteLine("Timer:" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
                Console.WriteLine("Timer:" + Thread.CurrentThread.ManagedThreadId + "End");
            }, null, 0, 1000);
            Console.WriteLine("Main:" + Thread.CurrentThread.ManagedThreadId);
            Console.ReadLine();
        }
    }
}
