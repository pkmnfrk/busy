namespace MyButtonThing
{
    partial class MainHiddenForm
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
            this.btnTryAgain = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.retryConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retryConnectionMenuStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTryAgain
            // 
            this.btnTryAgain.Location = new System.Drawing.Point(178, 227);
            this.btnTryAgain.Name = "btnTryAgain";
            this.btnTryAgain.Size = new System.Drawing.Size(94, 23);
            this.btnTryAgain.TabIndex = 0;
            this.btnTryAgain.Text = "Try connecting";
            this.btnTryAgain.UseVisualStyleBackColor = true;
            this.btnTryAgain.Click += new System.EventHandler(this.btnTryAgain_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.mnuIcon;
            this.notifyIcon1.Text = "Task Switcher";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // mnuIcon
            // 
            this.mnuIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.retryConnectionToolStripMenuItem,
            this.retryConnectionMenuStripSeparator,
            this.quitToolStripMenuItem});
            this.mnuIcon.Name = "mnuIcon";
            this.mnuIcon.Size = new System.Drawing.Size(167, 54);
            this.mnuIcon.Opening += new System.ComponentModel.CancelEventHandler(this.mnuIcon_Opening);
            // 
            // retryConnectionToolStripMenuItem
            // 
            this.retryConnectionToolStripMenuItem.Name = "retryConnectionToolStripMenuItem";
            this.retryConnectionToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.retryConnectionToolStripMenuItem.Text = "Retry Connection";
            this.retryConnectionToolStripMenuItem.Click += new System.EventHandler(this.retryConnectionToolStripMenuItem_Click);
            // 
            // retryConnectionMenuStripSeparator
            // 
            this.retryConnectionMenuStripSeparator.Name = "retryConnectionMenuStripSeparator";
            this.retryConnectionMenuStripSeparator.Size = new System.Drawing.Size(163, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnTryAgain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainHiddenForm_Load);
            this.mnuIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTryAgain;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip mnuIcon;
        private System.Windows.Forms.ToolStripMenuItem retryConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator retryConnectionMenuStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
    }
}

