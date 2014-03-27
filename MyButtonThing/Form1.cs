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

using Genome;
using Microsoft.Win32;

namespace MyButtonThing
{
    public partial class Form1 : Form
    {
        CanFocusButton button;
        ActionState currentState = ActionState.None;
        bool closing = false;

        DateTime? startDate;

        UserContext userContext;


        public Form1()
        {
            InitializeComponent();

            button = new CanFocusButton();
            button.State = ButtonState.Red;
            button.AutoManageButton = false;

            button.ConnectedChanged += button_ConnectedChanged;
            button.ButtonPress += button_ButtonPress;
            
            notifyIcon1.Icon = button.IsConnected ? icons.icoRed : icons.icoGrey;
            
            using (var regKey = Registry.CurrentUser.CreateSubKey(registryKey, RegistryKeyPermissionCheck.ReadWriteSubTree))
            {

                var tmp = regKey.GetValue("StartDate", DateTime.MinValue.ToBinary());

                if (tmp != null)
                {
                    var start = DateTime.FromBinary((long)tmp);
                    var action = (string)regKey.GetValue("ActionState", "");

                    if (start.Date == DateTime.Now.Date)
                    {
                        var result = MessageBox.Show("Would you like to continue the " + action + " that you started at " + start + "?", "Resume task", MessageBoxButtons.YesNo);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            startDate = start;
                            currentState = (ActionState)Enum.Parse(typeof(ActionState), action);
                            UpdateIcon();
                        }

                    }
                }

                var ctx = (string)regKey.GetValue("UserContext", null);
                if (ctx != null)
                {
                    userContext = new UserContext(ctx);

                    //validate that the context is still good
                    var currentUser = User.GetCurrentUser(userContext);
                    if (currentUser == null) //nope
                        userContext = null;
                }

                if(userContext == null)
                {
                    using (var dlg = new Genome.LoginForm())
                    {
                        var result = dlg.ShowDialog();

                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            userContext = dlg.UserContext;
                            regKey.SetValue("UserContext", userContext.ToString());
                        }

                    }
                }

                
            }

            button.State = ButtonState.Green;
            notifyIcon1.Icon = button.IsConnected ? icons.icoGreen : icons.icoGrey;
        }

        private bool alreadyShowing = false;

        void button_ButtonPress(object sender, EventArgs e)
        {
            if (closing) return;

            Action action = () =>
            {
                if (alreadyShowing) return;
                alreadyShowing = true;
                try
                {
                    using (var picker = new ActionChangeDialog(currentState))
                    {

                        button.State = ButtonState.Red;
                        notifyIcon1.Icon = icons.icoRed;

                        var result = picker.ShowDialog(this);
                        if (closing) return;

                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            StopTracking();
                            currentState = picker.NewState;
                            StartTracking();

                        }
                    }

                    notifyIcon1.Icon = icons.icoGreen;
                    button.State = ButtonState.Green;

                    UpdateIcon();
                }
                finally
                {
                    alreadyShowing = false;
                }


            };

            

            if (this.InvokeRequired)
            {
                this.BeginInvoke(action);
            }
            else
            {
                action();
            }
        }

        private string registryRoot = "HKEY_CURRENT_USER";
        private string registryKey = @"Software\Klick\TaskSwitcher";

        private void StartTracking()
        {
            startDate = DateTime.Now;

            if (currentState != ActionState.None)
            {

                Registry.SetValue(registryRoot + "\\" + registryKey, "StartDate", startDate.Value.ToBinary(), RegistryValueKind.QWord);
                Registry.SetValue(registryRoot + "\\" + registryKey, "ActionState", currentState.ToString());
            }
        }

        private void StopTracking()
        {
            //Registry.CurrentUser.DeleteSubKey(registryKey, false);

            using (var key = Registry.CurrentUser.OpenSubKey(registryKey, RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                key.DeleteValue("StartDate", false);
                key.DeleteValue("ActionState", false);
            }

            if (currentState == ActionState.None) return;

            var timeDiff = DateTime.Now - startDate.Value;

            timeDiff = new TimeSpan(timeDiff.Ticks * 60); //fudge-factor for testing (1 second = 1 minute)

            var request = new TimeEntryPostRequest();

            request.Date = startDate.Value;
            request.Duration = (int)timeDiff.TotalMinutes;
            request.UserID = 4517;
            request.Type = "Schedule-Note";
            request.Note = currentState.ToString();
            request.userFriendlyDuration = (DateTime.Now - startDate).ToString();

            request.Send(userContext);

            currentState = ActionState.None;
        }

        void button_ConnectedChanged(object sender, ConnectedChangedEventArgs e)
        {
            if (closing) return;

            Action action = () =>
                {
                    notifyIcon1.Icon = e.IsConnected ? icons.icoGreen : icons.icoGrey;
                };

            if (this.InvokeRequired)
            {
                this.BeginInvoke(action);
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
