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

        public Form1()
        {
            InitializeComponent();

            button = new CanFocusButton();
            button.State = ButtonState.TalkToMe;
            button.AutoManageButton = false;

            button.ConnectedChanged += button_ConnectedChanged;
            button.ButtonPress += button_ButtonPress;

            btnTryAgain.Visible = !button.IsConnected;
        }


        void button_ButtonPress(object sender, EventArgs e)
        {
            Action action = () =>
            {
                var picker = new ActionChangeDialog(currentState);
                var result = picker.ShowDialog(this);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    currentState = picker.NewState;
                }

                this.Invalidate();
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

        void button_ConnectedChanged(object sender, ConnectedChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    btnTryAgain.Visible = !e.IsConnected;
                    Debug.WriteLine("Button visible: {0}, IsConnected: {1}", btnTryAgain.Visible, e.IsConnected);
                    this.Invalidate();
                }));
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

    }

    
}
