using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZBreak
{
    public partial class Form1 : Form
    {
        private ActiviyMonitor _activiyMonitor;

        public Form1()
        {
            InitializeComponent();
            _activiyMonitor = new ActiviyMonitor();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label.Text = _activiyMonitor.IsActive ? "Active" : "Inactive";
        }
    }
}
