namespace ZBreak
{
    partial class RemindForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            //手动资源释放
            _checker.Dispose();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemindForm));
            this.label = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(9, 23);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(253, 13);
            this.label.TabIndex = 0;
            this.label.Text = "您已经60分钟没有休息了，请至少休息5分钟！";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 52);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "我知道了啦！";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMore
            // 
            this.btnMore.Location = new System.Drawing.Point(148, 52);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(114, 30);
            this.btnMore.TabIndex = 2;
            this.btnMore.Text = "让我再干10分钟！";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "您已经0分钟没有休息了。";
            this.notifyIcon.Visible = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 30000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 88);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(250, 30);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "我休息好了，马上给我重置计时器！";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // RemindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 131);
            this.ControlBox = false;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(295, 170);
            this.MinimumSize = new System.Drawing.Size(295, 170);
            this.Name = "RemindForm";
            this.ShowInTaskbar = false;
            this.Text = "ZBreak";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnReset;
    }
}

