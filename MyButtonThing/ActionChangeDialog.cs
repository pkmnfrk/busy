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

        public ActionChangeDialog(ActionState currentState)
        {
            InitializeComponent();

            ExistingState = currentState;
            NewState = currentState;
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.Close(ActionState.Break);
        }

        private void btnMeeting_Click(object sender, EventArgs e)
        {
            this.Close(ActionState.Meeting);
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
            this.Close(ActionState.Ticket);
        }

    }
}
