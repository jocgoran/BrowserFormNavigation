using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserFormNavi.View
{
    public partial class WebBrowser : Form
    {
        public WebBrowser()
        {
            InitializeComponent();
        }

        public int Go()
        {
            //navigate to you destination 
            webBrowser1.Navigate("https://sdp.newaccess.ch");
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);

            return 0;
        }
        bool is_sec_page = false;

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!is_sec_page)
            {
                //get page element with id
                webBrowser1.Document.GetElementById("username").InnerText = "tunisia";
                webBrowser1.Document.GetElementById("password").InnerText = "tunisia";
                //login in to account(fire a login button promagatelly)
                webBrowser1.Document.GetElementById("LoginButton").InvokeMember("click");
                is_sec_page = true;
            }
            //secound page(if correctly aotanticate
            else
            {
                //intract with sec page elements with theire ids and so on
            }

        }
    }
}
