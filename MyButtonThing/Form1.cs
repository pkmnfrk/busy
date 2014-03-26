using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsbHid;
using UsbHid.USB.Classes.Messaging;

namespace MyButtonThing
{
    public partial class Form1 : Form
    {
        CanFocusButton button;
        ActionState currentState = ActionState.None;
        bool closing = false;


        public Form1()
        {
            InitializeComponent();

            button = new CanFocusButton();
            button.State = ButtonState.TalkToMe;
            button.AutoManageButton = false;

            button.ConnectedChanged += button_ConnectedChanged;
            button.ButtonPress += button_ButtonPress;

            btnTryAgain.Visible = !button.IsConnected;

            notifyIcon1.Icon = icons.icoGrey;
        }


        void button_ButtonPress(object sender, EventArgs e)
        {
            if (closing) return;

            Action action = () =>
            {
                using (var picker = new ActionChangeDialog(currentState))
                {

                    var result = picker.ShowDialog(this);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        currentState = picker.NewState;
                    }
                }

                notifyIcon1.Icon = icons.icoGreen;
                button.State = ButtonState.Green;

                UpdateIcon();

            };

            button.State = ButtonState.Red;
            notifyIcon1.Icon = icons.icoRed;

            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        void button_ConnectedChanged(object sender, ConnectedChangedEventArgs e)
        {
            if (closing) return;

            Action action = () =>
                {
                    btnTryAgain.Visible = !e.IsConnected;
                    notifyIcon1.Icon = e.IsConnected ? icons.icoGreen : icons.icoGrey;
                };

            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
            

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            
        }

        protected override void SetVisibleCore(bool value)
        {
            value = false;

            if (!IsHandleCreated)
            {
                CreateHandle();
            }

            base.SetVisibleCore(value);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(SystemBrushes.Control, this.ClientRectangle);
            if (button.IsConnected)
            {
                if (button.State == ButtonState.DoNotDisturb)
                {
                    e.Graphics.FillEllipse(Brushes.Red, this.ClientRectangle);
                }
                else
                {
                    e.Graphics.FillEllipse(Brushes.Green, this.ClientRectangle);
                }
            }
            else
            {
                e.Graphics.FillEllipse(Brushes.Gray, this.ClientRectangle);
            }
        }

        private void btnTryAgain_Click(object sender, EventArgs e)
        {
            button.TryConnecting();
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void UpdateIcon()
        {
            switch (currentState)
            {
                case ActionState.None:
                    notifyIcon1.Text = "Task Switcher";
                    break;
                case ActionState.Ticket:
                    notifyIcon1.Text = "Task Switcher - Working on a ticket";
                    break;
                case ActionState.Meeting:
                    notifyIcon1.Text = "Task Switcher - Attending a meeting";
                    break;
                case ActionState.Lunch:
                    notifyIcon1.Text = "Task Switcher - Having lunch";
                    break;
                case ActionState.Break:
                    notifyIcon1.Text = "Task Switcher - Taking a break";
                    break;
            }
        }

        private void mnuIcon_Opening(object sender, CancelEventArgs e)
        {
            if (button.IsConnected)
            {
                retryConnectionToolStripMenuItem.Visible = false;
                retryConnectionMenuStripSeparator.Visible = false;
            }
            else
            {
                retryConnectionMenuStripSeparator.Visible = true;
                retryConnectionToolStripMenuItem.Visible = true;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closing = true;
            button.Dispose();
            button = null;
            Application.Exit();
        }

        private void retryConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button.TryConnecting();
        }

    }

    
}
