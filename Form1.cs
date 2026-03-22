using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace autoclick
{
    public partial class Form1 : Form
    {
        // Timer clic automatique
        private System.Windows.Forms.Timer timer1;

        // Timer animation CPS
        private System.Windows.Forms.Timer animationTimer;

        // Glow CPS
        private int glow = 0;
        private bool glowUp = true;

        // CPS compteur
        private int clickCount = 0;
        private DateTime lastTime;

        // Pour le clic souris
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        const int LEFTDOWN = 0x02;
        const int LEFTUP = 0x04;
        const int RIGHTDOWN = 0x08;
        const int RIGHTUP = 0x10;

        // Hotkey F6 global
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int HOTKEY_ID = 9000;

        public Form1()
        {
            InitializeComponent();
            lastTime = DateTime.Now;

            // 🔴 Design rouge gaming
            this.BackColor = Color.FromArgb(18, 18, 18);

            // Boutons START/STOP
            buttonStart.BackColor = Color.FromArgb(200, 30, 30);
            buttonStart.ForeColor = Color.White;
            buttonStart.FlatStyle = FlatStyle.Flat;
            buttonStart.FlatAppearance.BorderSize = 0;

            buttonStop.BackColor = Color.FromArgb(120, 20, 20);
            buttonStop.ForeColor = Color.White;
            buttonStop.FlatStyle = FlatStyle.Flat;
            buttonStop.FlatAppearance.BorderSize = 0;

            // ComboBox
            comboBoxButton.BackColor = Color.FromArgb(30, 30, 30);
            comboBoxButton.ForeColor = Color.White;

            // NumericUpDown
            numericUpDown1.BackColor = Color.FromArgb(30, 30, 30);
            numericUpDown1.ForeColor = Color.White;

            // Label CPS
            labelCPS.ForeColor = Color.Red;
            labelCPS.Font = new Font("Segoe UI", 18, FontStyle.Bold);

            // Setup ComboBox clic gauche/droit
            comboBoxButton.Items.Add("Gauche");
            comboBoxButton.Items.Add("Droite");
            comboBoxButton.SelectedIndex = 0;

            // Timer clic automatique
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += timer1_Tick;

            // Timer animation CPS
            animationTimer = new Timer();
            animationTimer.Interval = 40;
            animationTimer.Tick += AnimateGlow;
            animationTimer.Start();

            // Hover boutons
            buttonStart.MouseEnter += ButtonHover;
            buttonStart.MouseLeave += ButtonLeave;
            buttonStop.MouseEnter += ButtonHover;
            buttonStop.MouseLeave += ButtonLeave;

            // Hotkey F6
            RegisterHotKey(this.Handle, HOTKEY_ID, 0, Keys.F6);
            this.FormClosing += Form1_FormClosing;
        }

        // Bouton START
        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDown1.Value;
            timer1.Start();
        }

        // Bouton STOP
        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        // Timer clic automatique
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBoxButton.SelectedItem.ToString() == "Gauche")
            {
                mouse_event(LEFTDOWN, 0, 0, 0, 0);
                mouse_event(LEFTUP, 0, 0, 0, 0);
            }
            else
            {
                mouse_event(RIGHTDOWN, 0, 0, 0, 0);
                mouse_event(RIGHTUP, 0, 0, 0, 0);
            }

            clickCount++;
            if ((DateTime.Now - lastTime).TotalSeconds >= 1)
            {
                labelCPS.Text = "CPS : " + clickCount;
                clickCount = 0;
                lastTime = DateTime.Now;
            }
        }

        // Changer vitesse
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDown1.Value;
        }

        // Animation glow CPS
        private void AnimateGlow(object sender, EventArgs e)
        {
            if (glowUp) glow += 5; else glow -= 5;
            if (glow >= 80) glowUp = false;
            if (glow <= 0) glowUp = true;
            labelCPS.ForeColor = Color.FromArgb(255, 200, glow, glow);
        }

        // Hover boutons
        private void ButtonHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null) btn.BackColor = Color.FromArgb(255, 50, 50);
        }

        private void ButtonLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if (btn == buttonStart) btn.BackColor = Color.FromArgb(200, 30, 30);
                else btn.BackColor = Color.FromArgb(120, 20, 20);
            }
        }

        // Hotkey F6
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
                timer1.Enabled = !timer1.Enabled;
            base.WndProc(ref m);
        }

        // Désenregistrer hotkey
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, HOTKEY_ID);
        }
    }
}