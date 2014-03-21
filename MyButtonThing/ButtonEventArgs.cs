using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyButtonThing
{
    public class ButtonEventArgs : EventArgs
    {
        public readonly bool IsDown;

        public ButtonEventArgs(bool isDown)
        {
            IsDown = isDown;
        }
    }

}
