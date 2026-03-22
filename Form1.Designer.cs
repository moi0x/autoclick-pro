namespace autoclick
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox comboBoxButton;
        private System.Windows.Forms.Timer timer1;
        
        

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            buttonStart = new Button();
            buttonStop = new Button();
            numericUpDown1 = new NumericUpDown();
            comboBoxButton = new ComboBox();
            timer1 = new System.Windows.Forms.Timer(components);
            checkBoxHold = new CheckBox();
            labelCPS = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.ForeColor = Color.Red;
            buttonStart.Location = new Point(3, 220);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(100, 40);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "START (F6)";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonStop
            // 
            buttonStop.ForeColor = Color.Red;
            buttonStop.Location = new Point(109, 220);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(100, 40);
            buttonStop.TabIndex = 1;
            buttonStop.Text = "STOP (F6)";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.ForeColor = Color.Red;
            numericUpDown1.Location = new Point(273, 201);
            numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 2;
            numericUpDown1.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // comboBoxButton
            // 
            comboBoxButton.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxButton.ForeColor = Color.Red;
            comboBoxButton.FormattingEnabled = true;
            comboBoxButton.Location = new Point(243, 230);
            comboBoxButton.Name = "comboBoxButton";
            comboBoxButton.Size = new Size(150, 23);
            comboBoxButton.TabIndex = 3;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // checkBoxHold
            // 
            checkBoxHold.AutoSize = true;
            checkBoxHold.ForeColor = Color.Red;
            checkBoxHold.Location = new Point(61, 199);
            checkBoxHold.Name = "checkBoxHold";
            checkBoxHold.Size = new Size(110, 19);
            checkBoxHold.TabIndex = 4;
            checkBoxHold.Text = "Maintenir le clic";
            checkBoxHold.UseVisualStyleBackColor = true;
            // 
            // labelCPS
            // 
            labelCPS.AutoSize = true;
            labelCPS.Font = new Font("Microsoft Sans Serif", 8.25F);
            labelCPS.ForeColor = Color.Red;
            labelCPS.Location = new Point(12, 201);
            labelCPS.Name = "labelCPS";
            labelCPS.Size = new Size(43, 13);
            labelCPS.TabIndex = 5;
            labelCPS.Text = "CPS : 0";
            labelCPS.Click += labelCPS_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(405, 265);
            Controls.Add(labelCPS);
            Controls.Add(checkBoxHold);
            Controls.Add(buttonStart);
            Controls.Add(buttonStop);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBoxButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "Form1";
            Text = "AutoClicker X";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBoxHold;
        private Label labelCPS;
    }
}