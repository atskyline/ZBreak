using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ZBreak
{
    class ActiveChecker : IDisposable
    {

        private Pixel[] _data;
        private Rectangle _resolution;
        private Bitmap _bitmap;
        public ActiveChecker()
        {
            _resolution = Screen.PrimaryScreen.Bounds;
            _data = new Pixel[Config.CollectPixelCount];
            InitData();
            _bitmap = new Bitmap(_resolution.Width, _resolution.Height);
        }

        private void InitData()
        {
            var random = new Random();
            for (int i = 0; i < _data.Length; i++)
            {
                int randomX = random.Next(0, _resolution.Width);
                int randomY = random.Next(0, _resolution.Height);
                _data[i].X = randomX;
                _data[i].Y = randomY;
            }
        }

        /// <summary>
        /// 截屏到_bitmap
        /// </summary>
        private void ScreenShot()
        {

            using (Graphics g = Graphics.FromImage(_bitmap))
            {
                try
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, _resolution.Size);
                }
                catch (Exception)
                {
                    //这里的try-catch主要是为了跳过在锁屏状态下，因为没有桌面（即没有桌面句柄）而调用失败的情况
                    //锁屏状态下会引发System.ComponentModel.Win32Exception (0x80004005): The handle is invalid
                }
            }

        }

        /// <summary>
        /// 根据之前和当前的截图状态，判断是否有大变化（即当前属于活动状态）
        /// </summary>
        public Boolean Check()
        {
            ScreenShot();
            int changePixelCount = 0;
            for (int i = 0; i < _data.Length; i++)
            {
                var newColor = _bitmap.GetPixel(_data[i].X, _data[i].Y);
                if (newColor != _data[i].Color)
                {
                    changePixelCount++;
                }
                _data[i].Color = newColor;
            }
            Debug.WriteLine(((Double)changePixelCount / Config.CollectPixelCount) * 100 + "%");
            return ((Double)changePixelCount / Config.CollectPixelCount) > Config.DecidePercent;
        }

        public void Dispose()
        {
            _bitmap.Dispose();
        }
    }
}
