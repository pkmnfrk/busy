using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbHid;
using UsbHid.USB.Classes.Messaging;

namespace MyButtonThing
{
    public class CanFocusButton
    {
        private static readonly ButtonMessage DNDMessage = new ButtonMessage(ButtonState.DoNotDisturb);
        private static readonly ButtonMessage TTMMessage = new ButtonMessage(ButtonState.TalkToMe);

        private UsbHidDevice device;

        public event EventHandler<ConnectedChangedEventArgs> ConnectedChanged;
        public event EventHandler<ButtonEventArgs> Button;
        public event EventHandler ButtonPress;

        private ButtonState state;


        public CanFocusButton()
        {
            AutoManageButton = true;

            device = new UsbHidDevice(0x0483, 0x0035);

            device.OnConnected += device_OnConnected;
            device.OnDisConnected += device_OnDisConnected;
            device.DataReceived += device_DataReceived;

            device.Connect();

            
        }

        void device_DataReceived(byte[] data)
        {
            if (data.Length == 9)
            {
                if (data[3] == 0x00)
                {
                    OnButton(true);
                }
                else if (data[3] == 0x80)
                {
                    OnButton(false);
                }
            }
        }



        void device_OnDisConnected()
        {
            OnConnectedChanged(false);
        }

        void device_OnConnected()
        {
            OnConnectedChanged(true);
            PushState();
        }

        public void TryConnecting()
        {
            device.Connect();
        }

        public void ToggleLight()
        {
            if (state == ButtonState.DoNotDisturb)
            {
                state = ButtonState.TalkToMe;
            }
            else
            {
                state = ButtonState.DoNotDisturb;
            }

            PushState();
        }

        protected virtual void OnConnectedChanged(bool isConnected)
        {
            var evt = ConnectedChanged;
            if(evt != null)
            {
                evt(this, new ConnectedChangedEventArgs(isConnected));
            }
        }

        protected virtual void OnButton(bool isDown)
        {
            var evt = Button;
            if (evt != null)
            {
                evt(this, new ButtonEventArgs(isDown));
            }

            if (!isDown)
            {

                if (AutoManageButton)
                {
                    ToggleLight();
                }

                OnButtonPress();
            }
        }

        protected virtual void OnButtonPress()
        {
            var evt = ButtonPress;
            if (evt != null)
            {
                evt(this, new EventArgs());
            }
        }

        public bool IsConnected
        {
            get
            {
                return device.IsDeviceConnected;
            }
        }

        public bool AutoManageButton
        {
            get;
            set;
        }

        public ButtonState State
        {
            get
            {
                return state;
            }
            set
            {
                if (state == value) return;

                state = value;

                PushState();
            }
        }

        private void PushState()
        {
            if (!device.IsDeviceConnected) return;

            switch (state)
            {
                case ButtonState.DoNotDisturb:
                    device.SendMessage(DNDMessage);
                    break;
                case ButtonState.TalkToMe:
                    device.SendMessage(TTMMessage);
                    break;
            }
        }
        

    }

    public class ConnectedChangedEventArgs : EventArgs {
        public readonly bool IsConnected;
        public ConnectedChangedEventArgs(bool isConnected) {
            IsConnected = isConnected;
        }
    }

    class ButtonMessage : IMesage
    {
        private byte[] data;


        public byte[] MessageData
        {
            get
            {
                return data;
            }
        }


        public ButtonMessage(ButtonState state)
        {
            data = new byte[9];
            if (state == ButtonState.DoNotDisturb)
            {
                data[1] = 0x01;
            }
        }

        
    }
}
