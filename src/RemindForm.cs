using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ZBreak
{
    public partial class RemindForm : Form
    {

        private readonly ActiveMonitor _monitor;

        public RemindForm(ActiveMonitor monitor)
        {
            InitializeComponent();
            InitNotifyIconMenu();
            _monitor = monitor;
        }

        private void InitNotifyIconMenu()
        {
            var contextMenu = new ContextMenu();
            var exitMenuItem = new MenuItem("退出程序");
            exitMenuItem.Click += (o, e) => Application.Exit();
            contextMenu.MenuItems.Add(exitMenuItem);
            notifyIcon.ContextMenu = contextMenu;
        }

        private void btnDelay_Click(object sender, EventArgs e)
        {
            _monitor.Delay();
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _monitor.Reset();
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public void Update(Int32 activeTime)
        {
            this.label.Text = "您已经" + activeTime + "分钟没有休息了，请至少休息" + Config.MinBreakTime + "分钟！";
            this.notifyIcon.Text = "您已经" + activeTime + "分钟没有休息了。";
        }

    }
}
