namespace _SCREEN_CAPTURE_TOOL
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
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkBox_shift_n = new System.Windows.Forms.CheckBox();
            this.chkBox_alt_n = new System.Windows.Forms.CheckBox();
            this.chkBox_ctrl_n = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_CaptureCursor = new System.Windows.Forms.CheckBox();
            this.checkBox_AutoRun = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showMainWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chkBox_shift_c = new System.Windows.Forms.CheckBox();
            this.chkBox_alt_c = new System.Windows.Forms.CheckBox();
            this.chkBox_ctrl_c = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.chkBox_shift_n);
            this.groupBox1.Controls.Add(this.chkBox_alt_n);
            this.groupBox1.Controls.Add(this.chkBox_ctrl_n);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HotKey_Normal";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(146, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(87, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // chkBox_shift_n
            // 
            this.chkBox_shift_n.AutoSize = true;
            this.chkBox_shift_n.Location = new System.Drawing.Point(95, 17);
            this.chkBox_shift_n.Name = "chkBox_shift_n";
            this.chkBox_shift_n.Size = new System.Drawing.Size(45, 17);
            this.chkBox_shift_n.TabIndex = 2;
            this.chkBox_shift_n.Text = "shift";
            this.chkBox_shift_n.UseVisualStyleBackColor = true;
            // 
            // chkBox_alt_n
            // 
            this.chkBox_alt_n.AutoSize = true;
            this.chkBox_alt_n.Location = new System.Drawing.Point(52, 17);
            this.chkBox_alt_n.Name = "chkBox_alt_n";
            this.chkBox_alt_n.Size = new System.Drawing.Size(37, 17);
            this.chkBox_alt_n.TabIndex = 1;
            this.chkBox_alt_n.Text = "alt";
            this.chkBox_alt_n.UseVisualStyleBackColor = true;
            // 
            // chkBox_ctrl_n
            // 
            this.chkBox_ctrl_n.AutoSize = true;
            this.chkBox_ctrl_n.Location = new System.Drawing.Point(6, 17);
            this.chkBox_ctrl_n.Name = "chkBox_ctrl_n";
            this.chkBox_ctrl_n.Size = new System.Drawing.Size(40, 17);
            this.chkBox_ctrl_n.TabIndex = 0;
            this.chkBox_ctrl_n.Text = "ctrl";
            this.chkBox_ctrl_n.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_CaptureCursor);
            this.groupBox2.Controls.Add(this.checkBox_AutoRun);
            this.groupBox2.Location = new System.Drawing.Point(12, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 44);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other";
            // 
            // checkBox_CaptureCursor
            // 
            this.checkBox_CaptureCursor.AutoSize = true;
            this.checkBox_CaptureCursor.Location = new System.Drawing.Point(110, 14);
            this.checkBox_CaptureCursor.Name = "checkBox_CaptureCursor";
            this.checkBox_CaptureCursor.Size = new System.Drawing.Size(93, 17);
            this.checkBox_CaptureCursor.TabIndex = 1;
            this.checkBox_CaptureCursor.Text = "CaptureCursor";
            this.checkBox_CaptureCursor.UseVisualStyleBackColor = true;
            // 
            // checkBox_AutoRun
            // 
            this.checkBox_AutoRun.AutoSize = true;
            this.checkBox_AutoRun.Location = new System.Drawing.Point(36, 14);
            this.checkBox_AutoRun.Name = "checkBox_AutoRun";
            this.checkBox_AutoRun.Size = new System.Drawing.Size(68, 17);
            this.checkBox_AutoRun.TabIndex = 0;
            this.checkBox_AutoRun.Text = "AutoRun";
            this.checkBox_AutoRun.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "setting";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ScreenCapture";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMainWindowToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 48);
            // 
            // showMainWindowToolStripMenuItem
            // 
            this.showMainWindowToolStripMenuItem.Name = "showMainWindowToolStripMenuItem";
            this.showMainWindowToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.showMainWindowToolStripMenuItem.Text = "Show MainWindow";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.chkBox_shift_c);
            this.groupBox3.Controls.Add(this.chkBox_alt_c);
            this.groupBox3.Controls.Add(this.chkBox_ctrl_c);
            this.groupBox3.Location = new System.Drawing.Point(12, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 49);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "HotKey_FromClipBoard";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(146, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(87, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // chkBox_shift_c
            // 
            this.chkBox_shift_c.AutoSize = true;
            this.chkBox_shift_c.Location = new System.Drawing.Point(95, 16);
            this.chkBox_shift_c.Name = "chkBox_shift_c";
            this.chkBox_shift_c.Size = new System.Drawing.Size(45, 17);
            this.chkBox_shift_c.TabIndex = 2;
            this.chkBox_shift_c.Text = "shift";
            this.chkBox_shift_c.UseVisualStyleBackColor = true;
            // 
            // chkBox_alt_c
            // 
            this.chkBox_alt_c.AutoSize = true;
            this.chkBox_alt_c.Location = new System.Drawing.Point(52, 16);
            this.chkBox_alt_c.Name = "chkBox_alt_c";
            this.chkBox_alt_c.Size = new System.Drawing.Size(37, 17);
            this.chkBox_alt_c.TabIndex = 1;
            this.chkBox_alt_c.Text = "alt";
            this.chkBox_alt_c.UseVisualStyleBackColor = true;
            // 
            // chkBox_ctrl_c
            // 
            this.chkBox_ctrl_c.AutoSize = true;
            this.chkBox_ctrl_c.Location = new System.Drawing.Point(6, 16);
            this.chkBox_ctrl_c.Name = "chkBox_ctrl_c";
            this.chkBox_ctrl_c.Size = new System.Drawing.Size(40, 17);
            this.chkBox_ctrl_c.TabIndex = 0;
            this.chkBox_ctrl_c.Text = "ctrl";
            this.chkBox_ctrl_c.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 204);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ScreenCapture";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chkBox_shift_n;
        private System.Windows.Forms.CheckBox chkBox_alt_n;
        private System.Windows.Forms.CheckBox chkBox_ctrl_n;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showMainWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_CaptureCursor;
        private System.Windows.Forms.CheckBox checkBox_AutoRun;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox chkBox_shift_c;
        private System.Windows.Forms.CheckBox chkBox_alt_c;
        private System.Windows.Forms.CheckBox chkBox_ctrl_c;
    }
}

