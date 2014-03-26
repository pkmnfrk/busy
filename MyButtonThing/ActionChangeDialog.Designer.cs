namespace MyButtonThing
{
    partial class ActionChangeDialog
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMeeting = new System.Windows.Forms.Button();
            this.btnTicket = new System.Windows.Forms.Button();
            this.btnLunch = new System.Windows.Forms.Button();
            this.btnBreak = new System.Windows.Forms.Button();
            this.btnNothing = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnMeeting);
            this.flowLayoutPanel1.Controls.Add(this.btnTicket);
            this.flowLayoutPanel1.Controls.Add(this.btnLunch);
            this.flowLayoutPanel1.Controls.Add(this.btnBreak);
            this.flowLayoutPanel1.Controls.Add(this.btnNothing);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(284, 262);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnMeeting
            // 
            this.btnMeeting.Location = new System.Drawing.Point(3, 3);
            this.btnMeeting.Name = "btnMeeting";
            this.btnMeeting.Size = new System.Drawing.Size(281, 35);
            this.btnMeeting.TabIndex = 2;
            this.btnMeeting.Text = "Going to a Meeting";
            this.btnMeeting.UseVisualStyleBackColor = true;
            this.btnMeeting.Click += new System.EventHandler(this.btnMeeting_Click);
            // 
            // btnTicket
            // 
            this.btnTicket.Location = new System.Drawing.Point(3, 44);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(281, 35);
            this.btnTicket.TabIndex = 1;
            this.btnTicket.Text = "Working on a Ticket";
            this.btnTicket.UseVisualStyleBackColor = true;
            this.btnTicket.Click += new System.EventHandler(this.btnTicket_Click);
            // 
            // btnLunch
            // 
            this.btnLunch.Location = new System.Drawing.Point(3, 85);
            this.btnLunch.Name = "btnLunch";
            this.btnLunch.Size = new System.Drawing.Size(281, 35);
            this.btnLunch.TabIndex = 3;
            this.btnLunch.Text = "Heading for Lunch";
            this.btnLunch.UseVisualStyleBackColor = true;
            this.btnLunch.Click += new System.EventHandler(this.btnLunch_Click);
            // 
            // btnBreak
            // 
            this.btnBreak.Location = new System.Drawing.Point(3, 126);
            this.btnBreak.Name = "btnBreak";
            this.btnBreak.Size = new System.Drawing.Size(281, 35);
            this.btnBreak.TabIndex = 4;
            this.btnBreak.Text = "Taking a Break";
            this.btnBreak.UseVisualStyleBackColor = true;
            this.btnBreak.Click += new System.EventHandler(this.btnBreak_Click);
            // 
            // btnNothing
            // 
            this.btnNothing.Location = new System.Drawing.Point(3, 167);
            this.btnNothing.Name = "btnNothing";
            this.btnNothing.Size = new System.Drawing.Size(281, 35);
            this.btnNothing.TabIndex = 0;
            this.btnNothing.Text = "Not working (stop timing)";
            this.btnNothing.UseVisualStyleBackColor = true;
            this.btnNothing.Click += new System.EventHandler(this.btnNothing_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(281, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ActionChangeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActionChangeDialog";
            this.Text = "What\'s happening?";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnNothing;
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Button btnMeeting;
        private System.Windows.Forms.Button btnLunch;
        private System.Windows.Forms.Button btnBreak;
        private System.Windows.Forms.Button btnCancel;
    }
}