using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using AutoUpdaterDotNET;

namespace autoclick
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer clickTimer;
        private System.Windows.Forms.Timer cpsTimer;
        
        private int clickCount = 0;
        private int currentCps = 0;
        private bool isRunning = false;
        
        private int glow = 0;
        private bool glowUp = true;
        
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        const int LEFTDOWN = 0x02;
        const int LEFTUP = 0x04;
        const int RIGHTDOWN = 0x08;
        const int RIGHTUP = 0x10;
        const int MIDDLEDOWN = 0x20;
        const int MIDDLEUP = 0x40;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int HOTKEY_ID = 9000;
        private Keys currentHotkey = Keys.F6;
        
        // Custom Titlebar drag
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();
            SetupCustomUI();

            // Intégration de la vérification de mise à jour avec AutoUpdater.NET
            AutoUpdater.Start("https://raw.githubusercontent.com/moi0x/autoclick-pro/master/update.xml");

            clickTimer = new System.Windows.Forms.Timer();
            clickTimer.Tick += ClickTimer_Tick;

            cpsTimer = new System.Windows.Forms.Timer();
            cpsTimer.Interval = 1000;
            cpsTimer.Tick += CpsTimer_Tick;
            
            System.Windows.Forms.Timer uiTimer = new System.Windows.Forms.Timer();
            uiTimer.Interval = 40;
            uiTimer.Tick += UiTimer_Tick;
            uiTimer.Start();

            RegisterHotKey(this.Handle, HOTKEY_ID, 0, currentHotkey);
            this.FormClosing += Form1_FormClosing;
        }

        private void SetupCustomUI()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(20, 20, 24);

            // Custom Title Bar
            pnlTitleBar.BackColor = Color.FromArgb(30, 30, 36);
            pnlTitleBar.MouseDown += TitleBar_MouseDown;
            lblTitle.MouseDown += TitleBar_MouseDown;

            SetupComboBox(comboMouseBtn);
            SetupComboBox(comboClickType);
            comboMouseBtn.SelectedIndex = 0;
            comboClickType.SelectedIndex = 0;

            ApplyNumericUpDownStyle(numHours);
            ApplyNumericUpDownStyle(numMins);
            ApplyNumericUpDownStyle(numSecs);
            ApplyNumericUpDownStyle(numMs);

            btnStart.BackColor = Color.FromArgb(40, 150, 80);
            btnStop.BackColor = Color.FromArgb(180, 50, 50);

            // Hover animations
            btnStart.MouseEnter += (s, e) => { if (btnStart.Enabled) btnStart.BackColor = Color.FromArgb(50, 180, 100); };
            btnStart.MouseLeave += (s, e) => btnStart.BackColor = Color.FromArgb(40, 150, 80);
            btnStop.MouseEnter += (s, e) => { if (btnStop.Enabled) btnStop.BackColor = Color.FromArgb(210, 60, 60); };
            btnStop.MouseLeave += (s, e) => btnStop.BackColor = Color.FromArgb(180, 50, 50);

            btnClose.MouseEnter += (s, e) => btnClose.BackColor = Color.FromArgb(220, 50, 50);
            btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.Transparent;
            btnMinimize.MouseEnter += (s, e) => btnMinimize.BackColor = Color.FromArgb(60, 60, 70);
            btnMinimize.MouseLeave += (s, e) => btnMinimize.BackColor = Color.Transparent;

            // Set version
            lblVersion.Text = $"v{Application.ProductVersion}";
        }

        private void SetupComboBox(ComboBox cb)
        {
            cb.BackColor = Color.FromArgb(40, 40, 48);
            cb.ForeColor = Color.White;
            cb.FlatStyle = FlatStyle.Flat;
        }
        
        private void ApplyNumericUpDownStyle(NumericUpDown nud)
        {
            nud.BackColor = Color.FromArgb(40, 40, 48);
            nud.ForeColor = Color.White;
            nud.BorderStyle = BorderStyle.FixedSingle;
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartClicker();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopClicker();
        }

        private void StartClicker()
        {
            if (isRunning) return;
            
            int interval = (int)(numHours.Value * 3600000 + numMins.Value * 60000 + numSecs.Value * 1000 + numMs.Value);
            if (interval <= 0) interval = 10;
            
            clickTimer.Interval = interval;
            clickTimer.Start();
            cpsTimer.Start();
            
            isRunning = true;
            lblStatus.Text = "Status: RUNNING";
            lblStatus.ForeColor = Color.FromArgb(80, 200, 100);
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            
            clickCount = 0;
            currentCps = 0;
            lblCps.Text = "0 CPS";
        }

        private void StopClicker()
        {
            if (!isRunning) return;
            
            clickTimer.Stop();
            cpsTimer.Stop();
            
            isRunning = false;
            lblStatus.Text = "Status: IDLE";
            lblStatus.ForeColor = Color.Gray;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void ClickTimer_Tick(object sender, EventArgs e)
        {
            int btnIdx = comboMouseBtn.SelectedIndex;
            int typeIdx = comboClickType.SelectedIndex;

            int down = LEFTDOWN;
            int up = LEFTUP;

            if (btnIdx == 1) { down = RIGHTDOWN; up = RIGHTUP; }
            else if (btnIdx == 2) { down = MIDDLEDOWN; up = MIDDLEUP; }

            mouse_event(down, 0, 0, 0, 0);
            mouse_event(up, 0, 0, 0, 0);
            clickCount++;

            if (typeIdx == 1) // Double click
            {
                mouse_event(down, 0, 0, 0, 0);
                mouse_event(up, 0, 0, 0, 0);
                clickCount++;
            }
        }

        private void CpsTimer_Tick(object sender, EventArgs e)
        {
            currentCps = clickCount;
            lblCps.Text = $"{currentCps} CPS";
            clickCount = 0;
        }

        private void UiTimer_Tick(object sender, EventArgs e)
        {
            if (!isRunning) 
            {
                lblCps.ForeColor = Color.Gray;
                return;
            }

            if (glowUp) glow += 10; else glow -= 10;
            if (glow >= 255) 
            {
                glow = 255;
                glowUp = false;
            }
            if (glow <= 100) 
            {
                glow = 100;
                glowUp = true;
            }

            lblCps.ForeColor = Color.FromArgb(glow, 200, 100);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
            {
                if (isRunning) StopClicker();
                else StartClicker();
            }
            base.WndProc(ref m);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, HOTKEY_ID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 15;
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();
                this.Region = new Region(path);

                using (Pen pen = new Pen(Color.FromArgb(60, 60, 70), 2))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}
