using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genome
{
    public partial class LoginForm : Form
    {

        public UserContext UserContext { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            web.Url = new Uri("http://genome.klick.com/login/", UriKind.Absolute);
        }

        private void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.Host == "genome.klick.com")
            {
                var cookie = NativeApi.GetUriCookies(e.Url);
                if (cookie.Contains("SessionID"))
                {
                    UserContext = new UserContext(cookie);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
