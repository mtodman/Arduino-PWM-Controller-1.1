namespace Arduino_PWM_Controller
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.m_serial = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cmbComm = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbPresets = new System.Windows.Forms.ComboBox();
            this.btnPresets = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblPWMValue = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.cmbComm);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(137, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arduino Comms";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Comm Port";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(30, 63);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cmbComm
            // 
            this.cmbComm.FormattingEnabled = true;
            this.cmbComm.Location = new System.Drawing.Point(7, 38);
            this.cmbComm.Name = "cmbComm";
            this.cmbComm.Size = new System.Drawing.Size(121, 21);
            this.cmbComm.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbPresets);
            this.groupBox2.Location = new System.Drawing.Point(165, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 49);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PWM Presets";
            // 
            // cmbPresets
            // 
            this.cmbPresets.FormattingEnabled = true;
            this.cmbPresets.Location = new System.Drawing.Point(6, 20);
            this.cmbPresets.Name = "cmbPresets";
            this.cmbPresets.Size = new System.Drawing.Size(388, 21);
            this.cmbPresets.TabIndex = 0;
            this.cmbPresets.SelectedIndexChanged += new System.EventHandler(this.cmbPresets_SelectedIndexChanged);
            // 
            // btnPresets
            // 
            this.btnPresets.Location = new System.Drawing.Point(571, 41);
            this.btnPresets.Name = "btnPresets";
            this.btnPresets.Size = new System.Drawing.Size(75, 42);
            this.btnPresets.TabIndex = 12;
            this.btnPresets.Text = "Configure Presets";
            this.btnPresets.UseVisualStyleBackColor = true;
            this.btnPresets.Click += new System.EventHandler(this.btnPresets_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(571, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblPWMValue
            // 
            this.lblPWMValue.AutoSize = true;
            this.lblPWMValue.Location = new System.Drawing.Point(320, 103);
            this.lblPWMValue.Name = "lblPWMValue";
            this.lblPWMValue.Size = new System.Drawing.Size(13, 13);
            this.lblPWMValue.TabIndex = 10;
            this.lblPWMValue.Text = "0";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(16, 125);
            this.hScrollBar1.Maximum = 255;
            this.hScrollBar1.Minimum = 1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(633, 17);
            this.hScrollBar1.TabIndex = 9;
            this.hScrollBar1.Value = 1;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 166);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnPresets);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblPWMValue);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Arduino PWM Controller 1.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort m_serial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cmbComm;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbPresets;
        private System.Windows.Forms.Button btnPresets;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblPWMValue;
        private System.Windows.Forms.HScrollBar hScrollBar1;
    }
}

