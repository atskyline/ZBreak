using System;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace ZBreak
{
    public class ActiveMonitor
    {
        public static void Run()
        {
            new ActiveMonitor();
        }


        private readonly ActiveChecker _checker;
        private readonly RemindForm _remindForm;
        //允许的活动时间，初期为FirstAlarmTime，用户可每次叠加一个MoreTime
        private TimeSpan _allowActiveTimeSpan;
        //上一次休息的时间点
        private DateTime _lastBreakTime;
        //检测器连续检测到休息状态（即屏幕没变化）的次数
        private Int32 _checkerCount;

        private ActiveMonitor()
        {
            _checker = new ActiveChecker();
            _remindForm = new RemindForm(this);
            _remindForm.Show();
            _remindForm.Hide();
            this.Reset();
            InitTimer();
        }

        private void InitTimer()
        {
            Timer timer = new Timer(Config.TimerInterval);
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            UpdateRemindForm();
            if (_checker.Check())
            {
                //用户在工作
                _checkerCount = 0;
                var activeTime = DateTime.Now - _lastBreakTime;
                if (activeTime >= _allowActiveTimeSpan)
                {
                    ShowRemind();
                }
            }
            else
            {
                //用户正在休息
                _checkerCount += 1;
                //TimerInterval * _checkerCount为用户已经休息的时间
                if (TimeSpan.FromMilliseconds(Config.TimerInterval * _checkerCount) >= TimeSpan.FromMinutes(Config.MinBreakTime))
                {
                    //用户完成一次休息
                    _lastBreakTime = DateTime.Now;
                    _allowActiveTimeSpan = TimeSpan.FromMinutes(Config.FirstAlarmTime);
                    _checkerCount = 0;
                    CloseRemind();
                }
            }
        }

        #region 提示窗口
        /// <summary>
        /// 更新提示窗体的状态
        /// </summary>
        private void UpdateRemindForm()
        {
            _remindForm.Invoke(new Action(delegate()
            {
                _remindForm.Update((DateTime.Now - _lastBreakTime).Minutes);
            }));
        }

        /// <summary>
        /// 弹出提示窗体
        /// </summary>
        private void ShowRemind()
        {
            _remindForm.Invoke(new Action(delegate()
            {
                if (!_remindForm.Visible)
                {
                    _remindForm.Show();
                }
            }));
            System.Media.SystemSounds.Beep.Play();
        }

        private void CloseRemind()
        {
            _remindForm.Invoke(new Action(delegate()
            {
                if (_remindForm.Visible)
                {
                    _remindForm.Close();
                }
            }));
        }
        #endregion

        /// <summary>
        /// 延迟提醒，延迟一个MoreTime
        /// </summary>
        public void Delay()
        {
            _allowActiveTimeSpan = DateTime.Now - _lastBreakTime + TimeSpan.FromMinutes(Config.MoreTime);
        }

        /// <summary>
        /// 重置监视器
        /// </summary>
        public void Reset()
        {
            _checkerCount = 0;
            _lastBreakTime = DateTime.Now;
            _allowActiveTimeSpan = TimeSpan.FromMinutes(Config.FirstAlarmTime);
        }
    }
}
