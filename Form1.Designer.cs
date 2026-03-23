namespace autoclick
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            
            this.grpInterval = new System.Windows.Forms.GroupBox();
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.lblHours = new System.Windows.Forms.Label();
            this.numMins = new System.Windows.Forms.NumericUpDown();
            this.lblMins = new System.Windows.Forms.Label();
            this.numSecs = new System.Windows.Forms.NumericUpDown();
            this.lblSecs = new System.Windows.Forms.Label();
            this.numMs = new System.Windows.Forms.NumericUpDown();
            this.lblMs = new System.Windows.Forms.Label();
            this.numTargetCps = new System.Windows.Forms.NumericUpDown();
            this.lblTargetCps = new System.Windows.Forms.Label();

            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.comboMouseBtn = new System.Windows.Forms.ComboBox();
            this.lblMouseBtn = new System.Windows.Forms.Label();
            this.comboClickType = new System.Windows.Forms.ComboBox();
            this.lblClickType = new System.Windows.Forms.Label();

            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblHotkey = new System.Windows.Forms.Label();

            this.pnlCps = new System.Windows.Forms.Panel();
            this.lblCps = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();

            this.pnlTitleBar.SuspendLayout();
            this.grpInterval.SuspendLayout();
            this.grpOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSecs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMs)).BeginInit();
            this.pnlCps.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblVersion.ForeColor = System.Drawing.Color.Gray;
            this.lblVersion.Location = new System.Drawing.Point(12, 315);
            this.lblVersion.Text = "v1.0.0.0";

            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.Controls.Add(this.lblTitle);
            this.pnlTitleBar.Controls.Add(this.btnMinimize);
            this.pnlTitleBar.Controls.Add(this.btnClose);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Height = 35;
            this.pnlTitleBar.Name = "pnlTitleBar";

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 8);
            this.lblTitle.Text = "AutoClicker Pro";

            // btnClose
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Width = 35;
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // btnMinimize
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.Width = 35;
            this.btnMinimize.Text = "—";
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);

            // 
            // grpInterval
            // 
            this.grpInterval.ForeColor = System.Drawing.Color.LightGray;
            this.grpInterval.Location = new System.Drawing.Point(20, 50);
            this.grpInterval.Size = new System.Drawing.Size(460, 80);
            this.grpInterval.Text = "Click Interval";

            this.grpInterval.Controls.Add(this.numHours);
            this.grpInterval.Controls.Add(this.lblHours);
            this.grpInterval.Controls.Add(this.numMins);
            this.grpInterval.Controls.Add(this.lblMins);
            this.grpInterval.Controls.Add(this.numSecs);
            this.grpInterval.Controls.Add(this.lblSecs);
            this.grpInterval.Controls.Add(this.numMs);
            this.grpInterval.Controls.Add(this.lblMs);
            this.grpInterval.Controls.Add(this.numTargetCps);
            this.grpInterval.Controls.Add(this.lblTargetCps);

            int xOff = 10, yOff = 30;
            this.numHours.Location = new System.Drawing.Point(xOff, yOff); this.numHours.Width = 45; this.numHours.Maximum = 999;
            this.lblHours.Location = new System.Drawing.Point(xOff + 48, yOff + 3); this.lblHours.Text = "h"; this.lblHours.AutoSize = true;

            xOff = 80;
            this.numMins.Location = new System.Drawing.Point(xOff, yOff); this.numMins.Width = 45; this.numMins.Maximum = 59;
            this.lblMins.Location = new System.Drawing.Point(xOff + 48, yOff + 3); this.lblMins.Text = "m"; this.lblMins.AutoSize = true;

            xOff = 150;
            this.numSecs.Location = new System.Drawing.Point(xOff, yOff); this.numSecs.Width = 45; this.numSecs.Maximum = 59;
            this.lblSecs.Location = new System.Drawing.Point(xOff + 48, yOff + 3); this.lblSecs.Text = "s"; this.lblSecs.AutoSize = true;

            xOff = 220;
            this.numMs.Location = new System.Drawing.Point(xOff, yOff); this.numMs.Width = 55; this.numMs.Maximum = 999; this.numMs.Value = 100;
            this.lblMs.Location = new System.Drawing.Point(xOff + 58, yOff + 3); this.lblMs.Text = "ms"; this.lblMs.AutoSize = true;
            this.numMs.ValueChanged += new System.EventHandler(this.numMs_ValueChanged);

            xOff = 320;
            this.numTargetCps.Location = new System.Drawing.Point(xOff, yOff); this.numTargetCps.Width = 50; this.numTargetCps.Maximum = 1000; this.numTargetCps.Value = 10;
            this.lblTargetCps.Location = new System.Drawing.Point(xOff + 53, yOff + 3); this.lblTargetCps.Text = "CPS (Target)"; this.lblTargetCps.AutoSize = true;
            this.numTargetCps.ValueChanged += new System.EventHandler(this.numTargetCps_ValueChanged);

            // 
            // grpOptions
            // 
            this.grpOptions.ForeColor = System.Drawing.Color.LightGray;
            this.grpOptions.Location = new System.Drawing.Point(20, 140);
            this.grpOptions.Size = new System.Drawing.Size(220, 110);
            this.grpOptions.Text = "Click Options";

            this.grpOptions.Controls.Add(this.comboMouseBtn);
            this.grpOptions.Controls.Add(this.lblMouseBtn);
            this.grpOptions.Controls.Add(this.comboClickType);
            this.grpOptions.Controls.Add(this.lblClickType);

            this.lblMouseBtn.Location = new System.Drawing.Point(15, 30); this.lblMouseBtn.Text = "Mouse Button:"; this.lblMouseBtn.AutoSize = true;
            this.comboMouseBtn.Location = new System.Drawing.Point(100, 27); this.comboMouseBtn.Width = 100;
            this.comboMouseBtn.Items.AddRange(new object[] { "Left", "Right", "Middle" });

            this.lblClickType.Location = new System.Drawing.Point(15, 70); this.lblClickType.Text = "Click Type:"; this.lblClickType.AutoSize = true;
            this.comboClickType.Location = new System.Drawing.Point(100, 67); this.comboClickType.Width = 100;
            this.comboClickType.Items.AddRange(new object[] { "Single", "Double" });

            // 
            // pnlCps
            // 
            this.pnlCps.BackColor = System.Drawing.Color.FromArgb(24, 24, 30);
            this.pnlCps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCps.Location = new System.Drawing.Point(260, 140);
            this.pnlCps.Size = new System.Drawing.Size(220, 110);
            
            this.pnlCps.Controls.Add(this.lblCps);
            this.pnlCps.Controls.Add(this.lblStatus);

            this.lblCps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCps.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCps.ForeColor = System.Drawing.Color.Gray;
            this.lblCps.Text = "0 CPS";

            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Text = "Status: IDLE";
            this.lblStatus.Height = 25;

            // 
            // Buttons
            // 
            this.btnStart.Location = new System.Drawing.Point(20, 270);
            this.btnStart.Size = new System.Drawing.Size(150, 45);
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnStart.Text = "START";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            this.btnStop.Location = new System.Drawing.Point(190, 270);
            this.btnStop.Size = new System.Drawing.Size(150, 45);
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnStop.Text = "STOP";
            this.btnStop.Enabled = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);

            this.lblHotkey.Location = new System.Drawing.Point(360, 280);
            this.lblHotkey.ForeColor = System.Drawing.Color.Gray;
            this.lblHotkey.AutoSize = true;
            this.lblHotkey.Text = "Hotkey: F6";
            this.lblHotkey.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(500, 340);
            this.Controls.Add(this.pnlTitleBar);
            this.Controls.Add(this.grpInterval);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.pnlCps);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblHotkey);
            this.Controls.Add(this.lblVersion);
            this.Name = "Form1";
            this.Text = "AutoClicker Pro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.grpInterval.ResumeLayout(false);
            this.grpInterval.PerformLayout();
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSecs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMs)).EndInit();
            this.pnlCps.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblVersion;

        private System.Windows.Forms.GroupBox grpInterval;
        private System.Windows.Forms.NumericUpDown numHours;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.NumericUpDown numMins;
        private System.Windows.Forms.Label lblMins;
        private System.Windows.Forms.NumericUpDown numSecs;
        private System.Windows.Forms.Label lblSecs;
        private System.Windows.Forms.NumericUpDown numMs;
        private System.Windows.Forms.Label lblMs;
        private System.Windows.Forms.NumericUpDown numTargetCps;
        private System.Windows.Forms.Label lblTargetCps;

        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.ComboBox comboMouseBtn;
        private System.Windows.Forms.Label lblMouseBtn;
        private System.Windows.Forms.ComboBox comboClickType;
        private System.Windows.Forms.Label lblClickType;

        private System.Windows.Forms.Panel pnlCps;
        private System.Windows.Forms.Label lblCps;
        private System.Windows.Forms.Label lblStatus;

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblHotkey;
    }
}
