namespace OBDII_SerialTest
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.commCloseBTN = new bcLib.VistaButton();
            this.commOpenBTN = new bcLib.VistaButton();
            this.serialELM = new System.IO.Ports.SerialPort(this.components);
            this.elmTimer = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.glossiness = new System.Windows.Forms.HScrollBar();
            this.pic_oil = new System.Windows.Forms.PictureBox();
            this.pic_batt = new System.Windows.Forms.PictureBox();
            this.LBL_CLOCK = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LBL_SPEED = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LBL_LOAD = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LBL_TEMP = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LBL_BATT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RPMGauge = new AquaControls.AquaGauge();
            this.panel1 = new System.Windows.Forms.Panel();
            this.B = new System.Windows.Forms.CheckBox();
            this.G = new System.Windows.Forms.CheckBox();
            this.R = new System.Windows.Forms.CheckBox();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.checktimer2 = new System.Windows.Forms.CheckBox();
            this.checkGaugeTrans = new System.Windows.Forms.CheckBox();
            this.btn_settimer = new bcLib.VistaButton();
            this.textTimer2 = new System.Windows.Forms.TextBox();
            this.textTimer1 = new System.Windows.Forms.TextBox();
            this.comboBAUD = new System.Windows.Forms.ComboBox();
            this.comboPORT = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_readtimeout = new System.Windows.Forms.TextBox();
            this.checktimer1 = new System.Windows.Forms.CheckBox();
            this.btn_sendcommand = new bcLib.VistaButton();
            this.txt_command = new System.Windows.Forms.TextBox();
            this.rxtxTB = new System.Windows.Forms.TextBox();
            this.txt_protocol = new System.Windows.Forms.TextBox();
            this.FastTimer = new System.Windows.Forms.Timer(this.components);
            this.checkBatt = new System.Windows.Forms.CheckBox();
            this.batttimer = new System.Windows.Forms.Timer(this.components);
            this.timer_clock = new System.Windows.Forms.Timer(this.components);
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_oil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_batt)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // commCloseBTN
            // 
            this.commCloseBTN.BackColor = System.Drawing.Color.Transparent;
            this.commCloseBTN.BaseColor = System.Drawing.Color.Red;
            this.commCloseBTN.ButtonText = "Close Port";
            this.commCloseBTN.CornerRadius = 2;
            this.commCloseBTN.GlowColor = System.Drawing.Color.Silver;
            this.commCloseBTN.Location = new System.Drawing.Point(3, 98);
            this.commCloseBTN.Name = "commCloseBTN";
            this.commCloseBTN.Size = new System.Drawing.Size(85, 24);
            this.commCloseBTN.TabIndex = 7;
            this.commCloseBTN.Click += new System.EventHandler(this.commCloseBTN_Click);
            // 
            // commOpenBTN
            // 
            this.commOpenBTN.BackColor = System.Drawing.Color.Transparent;
            this.commOpenBTN.BaseColor = System.Drawing.Color.Red;
            this.commOpenBTN.ButtonText = "Open PORT";
            this.commOpenBTN.CornerRadius = 2;
            this.commOpenBTN.GlowColor = System.Drawing.Color.Silver;
            this.commOpenBTN.Location = new System.Drawing.Point(9, 12);
            this.commOpenBTN.Name = "commOpenBTN";
            this.commOpenBTN.Size = new System.Drawing.Size(85, 24);
            this.commOpenBTN.TabIndex = 1;
            this.commOpenBTN.Click += new System.EventHandler(this.commOpenBTN_Click);
            // 
            // serialELM
            // 
            this.serialELM.BaudRate = 115200;
            this.serialELM.DiscardNull = true;
            this.serialELM.PortName = "COM3";
            this.serialELM.ReceivedBytesThreshold = 2;
            this.serialELM.WriteBufferSize = 4048;
            this.serialELM.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialELM_ErrorReceived);
            this.serialELM.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialELM_DataRecieved);
            // 
            // elmTimer
            // 
            this.elmTimer.Interval = 50;
            this.elmTimer.Tick += new System.EventHandler(this.elmTimer_Tick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.glossiness);
            this.panel4.Controls.Add(this.pic_oil);
            this.panel4.Controls.Add(this.pic_batt);
            this.panel4.Controls.Add(this.LBL_CLOCK);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.LBL_SPEED);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.LBL_LOAD);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.LBL_TEMP);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.LBL_BATT);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.RPMGauge);
            this.panel4.Font = new System.Drawing.Font("Courier New", 12F);
            this.panel4.Location = new System.Drawing.Point(100, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(697, 425);
            this.panel4.TabIndex = 31;
            // 
            // glossiness
            // 
            this.glossiness.Location = new System.Drawing.Point(423, 327);
            this.glossiness.Name = "glossiness";
            this.glossiness.Size = new System.Drawing.Size(86, 13);
            this.glossiness.TabIndex = 46;
            this.glossiness.Value = 30;
            this.glossiness.Scroll += new System.Windows.Forms.ScrollEventHandler(this.glossiness_Scroll);
            // 
            // pic_oil
            // 
            this.pic_oil.Image = ((System.Drawing.Image)(resources.GetObject("pic_oil.Image")));
            this.pic_oil.Location = new System.Drawing.Point(606, 382);
            this.pic_oil.Name = "pic_oil";
            this.pic_oil.Size = new System.Drawing.Size(86, 42);
            this.pic_oil.TabIndex = 45;
            this.pic_oil.TabStop = false;
            this.pic_oil.Visible = false;
            // 
            // pic_batt
            // 
            this.pic_batt.Image = ((System.Drawing.Image)(resources.GetObject("pic_batt.Image")));
            this.pic_batt.Location = new System.Drawing.Point(249, 374);
            this.pic_batt.Name = "pic_batt";
            this.pic_batt.Size = new System.Drawing.Size(62, 42);
            this.pic_batt.TabIndex = 44;
            this.pic_batt.TabStop = false;
            this.pic_batt.Visible = false;
            // 
            // LBL_CLOCK
            // 
            this.LBL_CLOCK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.LBL_CLOCK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LBL_CLOCK.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LBL_CLOCK.ForeColor = System.Drawing.Color.Blue;
            this.LBL_CLOCK.Location = new System.Drawing.Point(43, 39);
            this.LBL_CLOCK.Name = "LBL_CLOCK";
            this.LBL_CLOCK.Size = new System.Drawing.Size(175, 49);
            this.LBL_CLOCK.TabIndex = 42;
            this.LBL_CLOCK.Text = "0";
            this.LBL_CLOCK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LBL_CLOCK.Click += new System.EventHandler(this.LBL_CLOCK_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(41, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 19);
            this.label8.TabIndex = 41;
            this.label8.Text = "SPEED km/H";
            // 
            // LBL_SPEED
            // 
            this.LBL_SPEED.BackColor = System.Drawing.Color.Green;
            this.LBL_SPEED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_SPEED.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LBL_SPEED.ForeColor = System.Drawing.Color.White;
            this.LBL_SPEED.Location = new System.Drawing.Point(43, 125);
            this.LBL_SPEED.Name = "LBL_SPEED";
            this.LBL_SPEED.Size = new System.Drawing.Size(175, 49);
            this.LBL_SPEED.TabIndex = 40;
            this.LBL_SPEED.Text = "0";
            this.LBL_SPEED.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(41, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 19);
            this.label6.TabIndex = 39;
            this.label6.Text = "ENGINE Load %";
            // 
            // LBL_LOAD
            // 
            this.LBL_LOAD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LBL_LOAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_LOAD.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LBL_LOAD.ForeColor = System.Drawing.Color.Yellow;
            this.LBL_LOAD.Location = new System.Drawing.Point(43, 287);
            this.LBL_LOAD.Name = "LBL_LOAD";
            this.LBL_LOAD.Size = new System.Drawing.Size(175, 49);
            this.LBL_LOAD.TabIndex = 38;
            this.LBL_LOAD.Text = "0";
            this.LBL_LOAD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(41, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 19);
            this.label4.TabIndex = 37;
            this.label4.Text = "ENGINE Temp C ˚";
            // 
            // LBL_TEMP
            // 
            this.LBL_TEMP.BackColor = System.Drawing.Color.Green;
            this.LBL_TEMP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_TEMP.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LBL_TEMP.ForeColor = System.Drawing.Color.White;
            this.LBL_TEMP.Location = new System.Drawing.Point(43, 206);
            this.LBL_TEMP.Name = "LBL_TEMP";
            this.LBL_TEMP.Size = new System.Drawing.Size(175, 49);
            this.LBL_TEMP.TabIndex = 36;
            this.LBL_TEMP.Text = "0";
            this.LBL_TEMP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(41, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 19);
            this.label3.TabIndex = 35;
            this.label3.Text = "BATTERY Voltage";
            // 
            // LBL_BATT
            // 
            this.LBL_BATT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LBL_BATT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_BATT.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LBL_BATT.Location = new System.Drawing.Point(43, 367);
            this.LBL_BATT.Name = "LBL_BATT";
            this.LBL_BATT.Size = new System.Drawing.Size(175, 49);
            this.LBL_BATT.TabIndex = 34;
            this.LBL_BATT.Text = "0V";
            this.LBL_BATT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.YellowGreen;
            this.label1.Location = new System.Drawing.Point(41, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 19);
            this.label1.TabIndex = 33;
            this.label1.Text = "OBDII TÜRKAY BİLİYOR";
            // 
            // RPMGauge
            // 
            this.RPMGauge.AutoSize = true;
            this.RPMGauge.BackColor = System.Drawing.Color.Transparent;
            this.RPMGauge.DialColor = System.Drawing.Color.DarkGreen;
            this.RPMGauge.DialText = "RPM X 100";
            this.RPMGauge.EnableTransparentBackground = true;
            this.RPMGauge.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RPMGauge.ForeColor = System.Drawing.Color.White;
            this.RPMGauge.Glossiness = 30F;
            this.RPMGauge.Location = new System.Drawing.Point(249, -2);
            this.RPMGauge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RPMGauge.MaxValue = 60F;
            this.RPMGauge.MinValue = 0F;
            this.RPMGauge.Name = "RPMGauge";
            this.RPMGauge.NoOfDivisions = 6;
            this.RPMGauge.NoOfSubDivisions = 1;
            this.RPMGauge.RecommendedValue = 25F;
            this.RPMGauge.Size = new System.Drawing.Size(426, 426);
            this.RPMGauge.TabIndex = 29;
            this.RPMGauge.ThresholdPercent = 33F;
            this.RPMGauge.Value = 0F;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.panel1.Controls.Add(this.B);
            this.panel1.Controls.Add(this.G);
            this.panel1.Controls.Add(this.R);
            this.panel1.Controls.Add(this.hScrollBar1);
            this.panel1.Controls.Add(this.checktimer2);
            this.panel1.Controls.Add(this.checkGaugeTrans);
            this.panel1.Controls.Add(this.btn_settimer);
            this.panel1.Controls.Add(this.textTimer2);
            this.panel1.Controls.Add(this.textTimer1);
            this.panel1.Controls.Add(this.comboBAUD);
            this.panel1.Controls.Add(this.comboPORT);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_readtimeout);
            this.panel1.Controls.Add(this.checktimer1);
            this.panel1.Controls.Add(this.commCloseBTN);
            this.panel1.Controls.Add(this.btn_sendcommand);
            this.panel1.Controls.Add(this.txt_command);
            this.panel1.Location = new System.Drawing.Point(5, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(93, 425);
            this.panel1.TabIndex = 32;
            // 
            // B
            // 
            this.B.AutoSize = true;
            this.B.BackColor = System.Drawing.Color.Black;
            this.B.Location = new System.Drawing.Point(63, 403);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(33, 19);
            this.B.TabIndex = 43;
            this.B.Text = "B";
            this.B.UseVisualStyleBackColor = false;
            this.B.CheckedChanged += new System.EventHandler(this.B_CheckedChanged);
            // 
            // G
            // 
            this.G.AutoSize = true;
            this.G.BackColor = System.Drawing.Color.Black;
            this.G.Checked = true;
            this.G.CheckState = System.Windows.Forms.CheckState.Checked;
            this.G.Location = new System.Drawing.Point(33, 403);
            this.G.Name = "G";
            this.G.Size = new System.Drawing.Size(33, 19);
            this.G.TabIndex = 42;
            this.G.Text = "G";
            this.G.UseVisualStyleBackColor = false;
            this.G.CheckedChanged += new System.EventHandler(this.G_CheckedChanged);
            // 
            // R
            // 
            this.R.AutoSize = true;
            this.R.BackColor = System.Drawing.Color.Black;
            this.R.Location = new System.Drawing.Point(2, 403);
            this.R.Name = "R";
            this.R.Size = new System.Drawing.Size(33, 19);
            this.R.TabIndex = 41;
            this.R.Text = "R";
            this.R.UseVisualStyleBackColor = false;
            this.R.CheckedChanged += new System.EventHandler(this.R_CheckedChanged);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(2, 382);
            this.hScrollBar1.Maximum = 255;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(86, 15);
            this.hScrollBar1.TabIndex = 35;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // checktimer2
            // 
            this.checktimer2.AutoSize = true;
            this.checktimer2.BackColor = System.Drawing.Color.Black;
            this.checktimer2.Checked = true;
            this.checktimer2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checktimer2.Location = new System.Drawing.Point(4, 279);
            this.checktimer2.Name = "checktimer2";
            this.checktimer2.Size = new System.Drawing.Size(68, 19);
            this.checktimer2.TabIndex = 40;
            this.checktimer2.Text = "Timer2";
            this.checktimer2.UseVisualStyleBackColor = false;
            this.checktimer2.CheckedChanged += new System.EventHandler(this.checktimer2_CheckedChanged);
            // 
            // checkGaugeTrans
            // 
            this.checkGaugeTrans.AutoSize = true;
            this.checkGaugeTrans.BackColor = System.Drawing.Color.Black;
            this.checkGaugeTrans.Checked = true;
            this.checkGaugeTrans.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkGaugeTrans.Location = new System.Drawing.Point(4, 360);
            this.checkGaugeTrans.Name = "checkGaugeTrans";
            this.checkGaugeTrans.Size = new System.Drawing.Size(89, 19);
            this.checkGaugeTrans.TabIndex = 39;
            this.checkGaugeTrans.Text = "Gauge Trs";
            this.checkGaugeTrans.UseVisualStyleBackColor = false;
            this.checkGaugeTrans.CheckedChanged += new System.EventHandler(this.checkGaugeTrans_CheckedChanged);
            // 
            // btn_settimer
            // 
            this.btn_settimer.BackColor = System.Drawing.Color.Transparent;
            this.btn_settimer.BaseColor = System.Drawing.Color.Red;
            this.btn_settimer.ButtonText = "Set Timers";
            this.btn_settimer.CornerRadius = 2;
            this.btn_settimer.GlowColor = System.Drawing.Color.Silver;
            this.btn_settimer.Location = new System.Drawing.Point(3, 226);
            this.btn_settimer.Name = "btn_settimer";
            this.btn_settimer.Size = new System.Drawing.Size(86, 22);
            this.btn_settimer.TabIndex = 38;
            this.btn_settimer.Click += new System.EventHandler(this.btn_settimer_Click);
            // 
            // textTimer2
            // 
            this.textTimer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textTimer2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textTimer2.ForeColor = System.Drawing.Color.White;
            this.textTimer2.Location = new System.Drawing.Point(2, 332);
            this.textTimer2.Name = "textTimer2";
            this.textTimer2.Size = new System.Drawing.Size(86, 22);
            this.textTimer2.TabIndex = 37;
            this.textTimer2.Text = "5";
            // 
            // textTimer1
            // 
            this.textTimer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textTimer1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textTimer1.ForeColor = System.Drawing.Color.White;
            this.textTimer1.Location = new System.Drawing.Point(2, 304);
            this.textTimer1.Name = "textTimer1";
            this.textTimer1.Size = new System.Drawing.Size(86, 22);
            this.textTimer1.TabIndex = 35;
            this.textTimer1.Text = "50";
            // 
            // comboBAUD
            // 
            this.comboBAUD.BackColor = System.Drawing.Color.White;
            this.comboBAUD.FormattingEnabled = true;
            this.comboBAUD.Items.AddRange(new object[] {
            "9600",
            "38400",
            "115200"});
            this.comboBAUD.Location = new System.Drawing.Point(4, 69);
            this.comboBAUD.Name = "comboBAUD";
            this.comboBAUD.Size = new System.Drawing.Size(84, 23);
            this.comboBAUD.TabIndex = 34;
            this.comboBAUD.Text = "115200";
            this.comboBAUD.SelectedIndexChanged += new System.EventHandler(this.comboBAUD_SelectedIndexChanged);
            // 
            // comboPORT
            // 
            this.comboPORT.BackColor = System.Drawing.Color.White;
            this.comboPORT.FormattingEnabled = true;
            this.comboPORT.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.comboPORT.Location = new System.Drawing.Point(4, 40);
            this.comboPORT.Name = "comboPORT";
            this.comboPORT.Size = new System.Drawing.Size(84, 23);
            this.comboPORT.TabIndex = 33;
            this.comboPORT.Text = "COM5";
            this.comboPORT.SelectedIndexChanged += new System.EventHandler(this.comboPORT_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 33;
            this.label2.Text = "ReadTimeout";
            // 
            // txt_readtimeout
            // 
            this.txt_readtimeout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_readtimeout.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_readtimeout.ForeColor = System.Drawing.Color.White;
            this.txt_readtimeout.Location = new System.Drawing.Point(3, 142);
            this.txt_readtimeout.Name = "txt_readtimeout";
            this.txt_readtimeout.Size = new System.Drawing.Size(86, 22);
            this.txt_readtimeout.TabIndex = 16;
            this.txt_readtimeout.Text = "3000";
            // 
            // checktimer1
            // 
            this.checktimer1.AutoSize = true;
            this.checktimer1.BackColor = System.Drawing.Color.Black;
            this.checktimer1.Checked = true;
            this.checktimer1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checktimer1.Location = new System.Drawing.Point(4, 254);
            this.checktimer1.Name = "checktimer1";
            this.checktimer1.Size = new System.Drawing.Size(68, 19);
            this.checktimer1.TabIndex = 15;
            this.checktimer1.Text = "Timer1";
            this.checktimer1.UseVisualStyleBackColor = false;
            this.checktimer1.CheckedChanged += new System.EventHandler(this.checktimer1_CheckedChanged);
            // 
            // btn_sendcommand
            // 
            this.btn_sendcommand.BackColor = System.Drawing.Color.Transparent;
            this.btn_sendcommand.BaseColor = System.Drawing.Color.Red;
            this.btn_sendcommand.ButtonText = "Send Comm";
            this.btn_sendcommand.CornerRadius = 2;
            this.btn_sendcommand.GlowColor = System.Drawing.Color.Silver;
            this.btn_sendcommand.Location = new System.Drawing.Point(3, 170);
            this.btn_sendcommand.Name = "btn_sendcommand";
            this.btn_sendcommand.Size = new System.Drawing.Size(86, 22);
            this.btn_sendcommand.TabIndex = 2;
            this.btn_sendcommand.Click += new System.EventHandler(this.btn_sendcommand_Click);
            // 
            // txt_command
            // 
            this.txt_command.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_command.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_command.ForeColor = System.Drawing.Color.White;
            this.txt_command.Location = new System.Drawing.Point(2, 198);
            this.txt_command.Name = "txt_command";
            this.txt_command.Size = new System.Drawing.Size(86, 22);
            this.txt_command.TabIndex = 0;
            this.txt_command.Text = "0100";
            // 
            // rxtxTB
            // 
            this.rxtxTB.BackColor = System.Drawing.Color.Black;
            this.rxtxTB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rxtxTB.ForeColor = System.Drawing.Color.White;
            this.rxtxTB.Location = new System.Drawing.Point(5, 428);
            this.rxtxTB.Name = "rxtxTB";
            this.rxtxTB.Size = new System.Drawing.Size(144, 21);
            this.rxtxTB.TabIndex = 33;
            // 
            // txt_protocol
            // 
            this.txt_protocol.BackColor = System.Drawing.Color.Black;
            this.txt_protocol.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_protocol.ForeColor = System.Drawing.Color.Lime;
            this.txt_protocol.Location = new System.Drawing.Point(142, 428);
            this.txt_protocol.Name = "txt_protocol";
            this.txt_protocol.Size = new System.Drawing.Size(573, 21);
            this.txt_protocol.TabIndex = 34;
            // 
            // FastTimer
            // 
            this.FastTimer.Interval = 5;
            this.FastTimer.Tick += new System.EventHandler(this.fastTimer_Tick);
            // 
            // checkBatt
            // 
            this.checkBatt.AutoSize = true;
            this.checkBatt.BackColor = System.Drawing.Color.Black;
            this.checkBatt.Location = new System.Drawing.Point(721, 429);
            this.checkBatt.Name = "checkBatt";
            this.checkBatt.Size = new System.Drawing.Size(75, 19);
            this.checkBatt.TabIndex = 47;
            this.checkBatt.Text = "BattMod";
            this.checkBatt.UseVisualStyleBackColor = false;
            this.checkBatt.CheckedChanged += new System.EventHandler(this.checkBatt_CheckedChanged);
            // 
            // batttimer
            // 
            this.batttimer.Interval = 500;
            this.batttimer.Tick += new System.EventHandler(this.batttimer_Tick);
            // 
            // timer_clock
            // 
            this.timer_clock.Enabled = true;
            this.timer_clock.Interval = 500;
            this.timer_clock.Tick += new System.EventHandler(this.timer_clock_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(798, 451);
            this.Controls.Add(this.checkBatt);
            this.Controls.Add(this.txt_protocol);
            this.Controls.Add(this.rxtxTB);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.commOpenBTN);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(8, 450);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ODB-II TURKAY";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_oil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_batt)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private bcLib.VistaButton commOpenBTN;
        private System.IO.Ports.SerialPort serialELM;
        private bcLib.VistaButton commCloseBTN;
        private System.Windows.Forms.Timer elmTimer;
        private System.Windows.Forms.Panel panel4;
        private AquaControls.AquaGauge RPMGauge;
        private System.Windows.Forms.Panel panel1;
        private bcLib.VistaButton btn_sendcommand;
        private System.Windows.Forms.TextBox txt_command;
        private System.Windows.Forms.CheckBox checktimer1;
        private System.Windows.Forms.TextBox rxtxTB;
        private System.Windows.Forms.TextBox txt_protocol;
        private System.Windows.Forms.TextBox txt_readtimeout;
        private System.Windows.Forms.ComboBox comboBAUD;
        private System.Windows.Forms.ComboBox comboPORT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer FastTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBL_BATT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LBL_TEMP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LBL_SPEED;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LBL_LOAD;
        private System.Windows.Forms.TextBox textTimer2;
        private System.Windows.Forms.TextBox textTimer1;
        private bcLib.VistaButton btn_settimer;
        private System.Windows.Forms.CheckBox checkGaugeTrans;
        private System.Windows.Forms.PictureBox pic_batt;
        private System.Windows.Forms.PictureBox pic_oil;
        private System.Windows.Forms.CheckBox checktimer2;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.CheckBox B;
        private System.Windows.Forms.CheckBox G;
        private System.Windows.Forms.CheckBox R;
        private System.Windows.Forms.HScrollBar glossiness;
        private System.Windows.Forms.CheckBox checkBatt;
        private System.Windows.Forms.Timer batttimer;
        private System.Windows.Forms.Label LBL_CLOCK;
        private System.Windows.Forms.Timer timer_clock;
    }
}

