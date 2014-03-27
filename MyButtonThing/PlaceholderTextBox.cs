using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MyButtonThing
{
    public partial class PlaceholderTextBox : TextBox
    {
        private const uint ECM_FIRST = 0x1500;
        private const uint EM_SETCUEBANNER = ECM_FIRST + 1;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);


        private string _placeholder;

        public string Placeholder
        {
            get
            {
                return _placeholder;
            }
            set
            {
                _placeholder = value;
                SetPlaceholder(_placeholder);
            }
        }

        public PlaceholderTextBox() : base()
        {
            InitializeComponent();
        }

        private void SetPlaceholder(string text)
        {
            SendMessage(this.Handle, EM_SETCUEBANNER, 0, text);
        }

    }
}
