using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyButtonThing
{
    public partial class ActionChangeDialog : Form
    {

        public ActionState ExistingState { get; private set; }
        public ActionState NewState { get; private set; }
        public string ExtraInfo { get; private set; }

        public ActionChangeDialog(ActionState currentState)
        {
            InitializeComponent();

            ExistingState = currentState;
            NewState = currentState;
            ExtraInfo = "";

        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.Close(ActionState.Break);
        }

        private void btnMeeting_Click(object sender, EventArgs e)
        {
            //this.Close(ActionState.Meeting);
            btnMeeting.Visible = false;
            txtMeeting.Visible = true;
            //txtMeeting.Focus();
        }

        private void Close(ActionState reason)
        {
            NewState = reason;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnNothing_Click(object sender, EventArgs e)
        {
            this.Close(ActionState.None);
        }

        private void btnLunch_Click(object sender, EventArgs e)
        {
            this.Close(ActionState.Lunch);
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            //this.Close(ActionState.Ticket);
            btnTicket.Visible = false;
            txtTicketNumber.Visible = true;
            //txtTicketNumber.Focus();
        }

        private void txtMeeting_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n' || e.KeyChar == '\r')
            {
                ExtraInfo = txtMeeting.Text;
                this.Close(ActionState.Meeting);
            }
        }

        private void txtTicketNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n' || e.KeyChar == '\r')
            {
                ExtraInfo = txtTicketNumber.Text;
                this.Close(ActionState.Ticket);
            }
        }

        public void Dismiss()
        {
            Action action = () =>
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            };

            action();

        }
    }
}
