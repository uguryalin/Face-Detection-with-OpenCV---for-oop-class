namespace FaceDetectionApp
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.grpMetrics = new System.Windows.Forms.GroupBox();
            this.lblProcessTime = new System.Windows.Forms.Label();
            this.lblFps = new System.Windows.Forms.Label();
            this.lblEyeCount = new System.Windows.Forms.Label();
            this.lblFaceCount = new System.Windows.Forms.Label();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.numMinNeighbors = new System.Windows.Forms.NumericUpDown();
            this.numScaleFactor = new System.Windows.Forms.NumericUpDown();
            this.lblMinNeighbors = new System.Windows.Forms.Label();
            this.lblScaleFactor = new System.Windows.Forms.Label();
            this.chkEye = new System.Windows.Forms.CheckBox();
            this.chkFace = new System.Windows.Forms.CheckBox();
            this.grpCamera = new System.Windows.Forms.GroupBox();
            this.btnSnapshot = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.comboCameras = new System.Windows.Forms.ComboBox();
            this.consolePanel = new System.Windows.Forms.Panel();
            this.txtLogConsole = new System.Windows.Forms.TextBox();
            this.lblConsoleHeader = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.pictureBoxView = new System.Windows.Forms.PictureBox();
            this.headerPanel.SuspendLayout();
            this.sidePanel.SuspendLayout();
            this.grpMetrics.SuspendLayout();
            this.grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinNeighbors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleFactor)).BeginInit();
            this.grpCamera.SuspendLayout();
            this.consolePanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxView)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(46)))));
            this.headerPanel.Controls.Add(this.lblSubtitle);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1100, 65);
            this.headerPanel.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Silver;
            this.lblSubtitle.Location = new System.Drawing.Point(15, 35);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(465, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "OpenCV Face and Eye Tracking System (Object-Oriented C# Implementation)";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(207, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "AI REAL-TIME DETECTOR";
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(40)))));
            this.sidePanel.Controls.Add(this.grpMetrics);
            this.sidePanel.Controls.Add(this.grpSettings);
            this.sidePanel.Controls.Add(this.grpCamera);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 65);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(320, 685);
            this.sidePanel.TabIndex = 1;
            // 
            // grpMetrics
            // 
            this.grpMetrics.Controls.Add(this.lblProcessTime);
            this.grpMetrics.Controls.Add(this.lblFps);
            this.grpMetrics.Controls.Add(this.lblEyeCount);
            this.grpMetrics.Controls.Add(this.lblFaceCount);
            this.grpMetrics.ForeColor = System.Drawing.Color.White;
            this.grpMetrics.Location = new System.Drawing.Point(15, 385);
            this.grpMetrics.Name = "grpMetrics";
            this.grpMetrics.Size = new System.Drawing.Size(290, 160);
            this.grpMetrics.TabIndex = 2;
            this.grpMetrics.TabStop = false;
            this.grpMetrics.Text = "Diagnostics Dashboard";
            // 
            // lblProcessTime
            // 
            this.lblProcessTime.AutoSize = true;
            this.lblProcessTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProcessTime.Location = new System.Drawing.Point(15, 115);
            this.lblProcessTime.Name = "lblProcessTime";
            this.lblProcessTime.Size = new System.Drawing.Size(86, 17);
            this.lblProcessTime.TabIndex = 3;
            this.lblProcessTime.Text = "Latency: 0 ms";
            // 
            // lblFps
            // 
            this.lblFps.AutoSize = true;
            this.lblFps.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFps.Location = new System.Drawing.Point(15, 85);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(51, 17);
            this.lblFps.TabIndex = 2;
            this.lblFps.Text = "FPS: 0.0";
            // 
            // lblEyeCount
            // 
            this.lblEyeCount.AutoSize = true;
            this.lblEyeCount.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEyeCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblEyeCount.Location = new System.Drawing.Point(15, 55);
            this.lblEyeCount.Name = "lblEyeCount";
            this.lblEyeCount.Size = new System.Drawing.Size(117, 17);
            this.lblEyeCount.TabIndex = 1;
            this.lblEyeCount.Text = "Detected Eyes: 0";
            // 
            // lblFaceCount
            // 
            this.lblFaceCount.AutoSize = true;
            this.lblFaceCount.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFaceCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblFaceCount.Location = new System.Drawing.Point(15, 25);
            this.lblFaceCount.Name = "lblFaceCount";
            this.lblFaceCount.Size = new System.Drawing.Size(121, 17);
            this.lblFaceCount.TabIndex = 0;
            this.lblFaceCount.Text = "Detected Faces: 0";
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.numMinNeighbors);
            this.grpSettings.Controls.Add(this.numScaleFactor);
            this.grpSettings.Controls.Add(this.lblMinNeighbors);
            this.grpSettings.Controls.Add(this.lblScaleFactor);
            this.grpSettings.Controls.Add(this.chkEye);
            this.grpSettings.Controls.Add(this.chkFace);
            this.grpSettings.ForeColor = System.Drawing.Color.White;
            this.grpSettings.Location = new System.Drawing.Point(15, 195);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(290, 175);
            this.grpSettings.TabIndex = 1;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Parameters";
            // 
            // numMinNeighbors
            // 
            this.numMinNeighbors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.numMinNeighbors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMinNeighbors.ForeColor = System.Drawing.Color.White;
            this.numMinNeighbors.Location = new System.Drawing.Point(180, 130);
            this.numMinNeighbors.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numMinNeighbors.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinNeighbors.Name = "numMinNeighbors";
            this.numMinNeighbors.Size = new System.Drawing.Size(95, 23);
            this.numMinNeighbors.TabIndex = 5;
            this.numMinNeighbors.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numMinNeighbors.ValueChanged += new System.EventHandler(this.numMinNeighbors_ValueChanged);
            // 
            // numScaleFactor
            // 
            this.numScaleFactor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.numScaleFactor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numScaleFactor.DecimalPlaces = 2;
            this.numScaleFactor.ForeColor = System.Drawing.Color.White;
            this.numScaleFactor.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numScaleFactor.Location = new System.Drawing.Point(180, 95);
            this.numScaleFactor.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            131072});
            this.numScaleFactor.Minimum = new decimal(new int[] {
            105,
            0,
            0,
            131072});
            this.numScaleFactor.Name = "numScaleFactor";
            this.numScaleFactor.Size = new System.Drawing.Size(95, 23);
            this.numScaleFactor.TabIndex = 4;
            this.numScaleFactor.Value = new decimal(new int[] {
            115,
            0,
            0,
            131072});
            this.numScaleFactor.ValueChanged += new System.EventHandler(this.numScaleFactor_ValueChanged);
            // 
            // lblMinNeighbors
            // 
            this.lblMinNeighbors.AutoSize = true;
            this.lblMinNeighbors.Location = new System.Drawing.Point(15, 132);
            this.lblMinNeighbors.Name = "lblMinNeighbors";
            this.lblMinNeighbors.Size = new System.Drawing.Size(89, 15);
            this.lblMinNeighbors.TabIndex = 3;
            this.lblMinNeighbors.Text = "Min Neighbors:";
            // 
            // lblScaleFactor
            // 
            this.lblScaleFactor.AutoSize = true;
            this.lblScaleFactor.Location = new System.Drawing.Point(15, 97);
            this.lblScaleFactor.Name = "lblScaleFactor";
            this.lblScaleFactor.Size = new System.Drawing.Size(73, 15);
            this.lblScaleFactor.TabIndex = 2;
            this.lblScaleFactor.Text = "Scale Factor:";
            // 
            // chkEye
            // 
            this.chkEye.AutoSize = true;
            this.chkEye.Location = new System.Drawing.Point(15, 55);
            this.chkEye.Name = "chkEye";
            this.chkEye.Size = new System.Drawing.Size(139, 19);
            this.chkEye.TabIndex = 1;
            this.chkEye.Text = "Enable Eye Detection";
            this.chkEye.UseVisualStyleBackColor = true;
            this.chkEye.CheckedChanged += new System.EventHandler(this.chkEye_CheckedChanged);
            // 
            // chkFace
            // 
            this.chkFace.AutoSize = true;
            this.chkFace.Location = new System.Drawing.Point(15, 25);
            this.chkFace.Name = "chkFace";
            this.chkFace.Size = new System.Drawing.Size(145, 19);
            this.chkFace.TabIndex = 0;
            this.chkFace.Text = "Enable Face Detection";
            this.chkFace.UseVisualStyleBackColor = true;
            this.chkFace.CheckedChanged += new System.EventHandler(this.chkFace_CheckedChanged);
            // 
            // grpCamera
            // 
            this.grpCamera.Controls.Add(this.btnSnapshot);
            this.grpCamera.Controls.Add(this.btnStop);
            this.grpCamera.Controls.Add(this.btnStart);
            this.grpCamera.Controls.Add(this.comboCameras);
            this.grpCamera.ForeColor = System.Drawing.Color.White;
            this.grpCamera.Location = new System.Drawing.Point(15, 15);
            this.grpCamera.Name = "grpCamera";
            this.grpCamera.Size = new System.Drawing.Size(290, 165);
            this.grpCamera.TabIndex = 0;
            this.grpCamera.TabStop = false;
            this.grpCamera.Text = "Camera Control";
            // 
            // btnSnapshot
            // 
            this.btnSnapshot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.btnSnapshot.Enabled = false;
            this.btnSnapshot.FlatAppearance.BorderSize = 0;
            this.btnSnapshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnapshot.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSnapshot.Location = new System.Drawing.Point(15, 115);
            this.btnSnapshot.Name = "btnSnapshot";
            this.btnSnapshot.Size = new System.Drawing.Size(260, 32);
            this.btnSnapshot.TabIndex = 3;
            this.btnSnapshot.Text = "Save Photo Snapshot";
            this.btnSnapshot.UseVisualStyleBackColor = false;
            this.btnSnapshot.Click += new System.EventHandler(this.btnSnapshot_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.btnStop.Enabled = false;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStop.Location = new System.Drawing.Point(150, 70);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(125, 35);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop Stream";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(199)))), ((int)(((byte)(89)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStart.Location = new System.Drawing.Point(15, 70);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(125, 35);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start Stream";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // comboCameras
            // 
            this.comboCameras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.comboCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCameras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboCameras.ForeColor = System.Drawing.Color.White;
            this.comboCameras.FormattingEnabled = true;
            this.comboCameras.Location = new System.Drawing.Point(15, 30);
            this.comboCameras.Name = "comboCameras";
            this.comboCameras.Size = new System.Drawing.Size(260, 23);
            this.comboCameras.TabIndex = 0;
            // 
            // consolePanel
            // 
            this.consolePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(20)))));
            this.consolePanel.Controls.Add(this.txtLogConsole);
            this.consolePanel.Controls.Add(this.lblConsoleHeader);
            this.consolePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.consolePanel.Location = new System.Drawing.Point(320, 610);
            this.consolePanel.Name = "consolePanel";
            this.consolePanel.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.consolePanel.Size = new System.Drawing.Size(780, 140);
            this.consolePanel.TabIndex = 2;
            // 
            // txtLogConsole
            // 
            this.txtLogConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(20)))));
            this.txtLogConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLogConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogConsole.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLogConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.txtLogConsole.Location = new System.Drawing.Point(10, 25);
            this.txtLogConsole.Multiline = true;
            this.txtLogConsole.Name = "txtLogConsole";
            this.txtLogConsole.ReadOnly = true;
            this.txtLogConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogConsole.Size = new System.Drawing.Size(760, 105);
            this.txtLogConsole.TabIndex = 1;
            // 
            // lblConsoleHeader
            // 
            this.lblConsoleHeader.AutoSize = true;
            this.lblConsoleHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConsoleHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConsoleHeader.ForeColor = System.Drawing.Color.DarkGray;
            this.lblConsoleHeader.Location = new System.Drawing.Point(10, 5);
            this.lblConsoleHeader.Name = "lblConsoleHeader";
            this.lblConsoleHeader.Size = new System.Drawing.Size(107, 15);
            this.lblConsoleHeader.TabIndex = 0;
            this.lblConsoleHeader.Text = "System Status Log";
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.mainPanel.Controls.Add(this.pictureBoxView);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(320, 65);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(15);
            this.mainPanel.Size = new System.Drawing.Size(780, 545);
            this.mainPanel.TabIndex = 3;
            // 
            // pictureBoxView
            // 
            this.pictureBoxView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(20)))));
            this.pictureBoxView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxView.Location = new System.Drawing.Point(15, 15);
            this.pictureBoxView.Name = "pictureBoxView";
            this.pictureBoxView.Size = new System.Drawing.Size(750, 515);
            this.pictureBoxView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxView.TabIndex = 0;
            this.pictureBoxView.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1100, 750);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.consolePanel);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AI Real-Time Face Tracker (OpenCV & OOP C#)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.sidePanel.ResumeLayout(false);
            this.grpMetrics.ResumeLayout(false);
            this.grpMetrics.PerformLayout();
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinNeighbors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleFactor)).EndInit();
            this.grpCamera.ResumeLayout(false);
            this.consolePanel.ResumeLayout(false);
            this.consolePanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.GroupBox grpCamera;
        private System.Windows.Forms.ComboBox comboCameras;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSnapshot;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.CheckBox chkEye;
        private System.Windows.Forms.CheckBox chkFace;
        private System.Windows.Forms.Label lblMinNeighbors;
        private System.Windows.Forms.Label lblScaleFactor;
        private System.Windows.Forms.NumericUpDown numMinNeighbors;
        private System.Windows.Forms.NumericUpDown numScaleFactor;
        private System.Windows.Forms.GroupBox grpMetrics;
        private System.Windows.Forms.Label lblProcessTime;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.Label lblEyeCount;
        private System.Windows.Forms.Label lblFaceCount;
        private System.Windows.Forms.Panel consolePanel;
        private System.Windows.Forms.TextBox txtLogConsole;
        private System.Windows.Forms.Label lblConsoleHeader;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox pictureBoxView;
    }
}
