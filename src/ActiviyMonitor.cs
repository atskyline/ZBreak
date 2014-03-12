using System;
using System.Threading;

namespace ZBreak
{
    /// <summary>
    /// 使用IBaseApi，基于对屏幕颜色的随机采集，监视屏幕是否处于活动状态
    /// </summary>
    class ActiviyMonitor : IDisposable
    {
        //采集间隔，单位毫秒
        private const long CollectInterval = 5 * 1000;
        private const int CollectPixelCount = 1000;
        //两次采集的像素有超过一定百分比不同，则认为屏幕属于活动状态
        private const double DecidePercent = 0.30;
        
        private Pixel[] _data;
        private IBaseApi _baseApi;
        private Timer _timer;
        private Boolean _isActive;
        public Boolean IsActive
        {
            get
            {
                return _isActive;
            }
        }

        public ActiviyMonitor()
        {
            _baseApi = new BaseApi();
            _isActive = false;
            _timer = new Timer(TimerCallBack);
            _data = new Pixel[CollectPixelCount];
            InitData();
            //开启计时器
            _timer.Change(0, CollectInterval);
        }

        private void InitData()
        {
            var resolution = _baseApi.GetPrimaryScreenResolution();
            var random = new Random();
            for (int i = 0; i < _data.Length; i++)
            {
                int randomY = random.Next(0, resolution.Width);
                int randomX = random.Next(0, resolution.Height);
                _data[i].X = randomX;
                _data[i].Y = randomY;
            }
        }

        private void TimerCallBack(object state)
        {
            //在回调函数中暂停计时器主要是为了防止，有两个线程在同时调用UpdateActiveState
            //暂停计时器
            _timer.Change(Timeout.Infinite, Timeout.Infinite);

            UpdateActiveState();

            //回复计时器
            _timer.Change(0, CollectInterval);
        }

        private void UpdateActiveState()
        {
            int changePixelCount = 0;
            for (int i = 0; i < _data.Length; i++)
            {
                var newColor = _baseApi.GetPixelColor(_data[i].X, _data[i].Y);
                if (newColor != _data[i].Color)
                {
                    changePixelCount++;
                }
                _data[i].Color = newColor;
            }
            _isActive = ((Double)changePixelCount / CollectPixelCount) < DecidePercent;
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
