using System;
using System.Windows.Forms;

namespace ZBreak
{
    public partial class RemindForm : Form
    {
        //活动状态监测间隔，单位毫秒
        private const Int32 TimerInterval = 10*1000;
        //最少连续MinBreakCount次检测都为休息状态才认为是休息
        //即每次休息至少TimerInterval × MinBreakCount 毫秒
        private const Int32 MinBreakCount = 5;
        //第一次提示基本时间，单位分钟
        private const double BaseRemindMinutes = 120;
        //每一次累加时间，单位分钟
        private const double MoreMinutes = 10;


        private readonly ActiveChecker _checker;
        private TimeSpan _remindSpan;
        private DateTime _lastBreakTime;
        private Int32 _continueBreakCount;
        

        public RemindForm()
        {
            _checker = new ActiveChecker();
            _remindSpan = TimeSpan.FromMinutes(BaseRemindMinutes);
            _lastBreakTime = DateTime.Now;
            _continueBreakCount = 0;

            InitializeComponent();
            InitNotifyIconMenu();
            this.timer.Interval = TimerInterval;
            this.WindowState = FormWindowState.Minimized;
        }

        private void InitNotifyIconMenu()
        {
            var contextMenu = new ContextMenu();
            var exitMenuItem = new MenuItem("退出程序");
            exitMenuItem.Click += (o, e) => Application.Exit();
            contextMenu.MenuItems.Add(exitMenuItem);
            notifyIcon.ContextMenu = contextMenu;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _lastBreakTime = DateTime.Now;
            _remindSpan = TimeSpan.FromMinutes(BaseRemindMinutes);
            this.Hide();
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            _remindSpan += TimeSpan.FromMinutes(MoreMinutes);
            this.Hide();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (_checker.Check() == false)
            {
                _continueBreakCount += 1;
                if (_continueBreakCount >= MinBreakCount)
                {
                    _lastBreakTime = DateTime.Now;
                    _continueBreakCount = 0;
                }
            }
            else
            {
                _continueBreakCount = 0;
            }

            var activeTime = DateTime.Now - _lastBreakTime;
            this.notifyIcon.Text = "您已连续" + activeTime.Minutes + "分钟没有休息了～";

            if (activeTime > _remindSpan)
            {
                ShowRemind(activeTime);
            }
        }

        private void ShowRemind(TimeSpan activeTime)
        {
            this.label.Text = "您已连续" + activeTime.Minutes + "分钟没有休息了～";
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.Show();
            System.Media.SystemSounds.Beep.Play();
        }

    }
}
