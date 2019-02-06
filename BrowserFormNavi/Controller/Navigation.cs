using BrowserFormNavi.View;
using BrowserFormNavi.Model;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    sealed class Navigation
    {
        public int OpenPage()
        {
            Program.browserData.URLToLoad = FormNavi.comboBox1.Text;

            if (Program.browserView == null)
            {
                Program.browserView = new BrowserView();
                // Display the new form.  
                Program.browserView.Show();
            }

            //navigate to you destination 
            Program.browserView.webBrowser1.Navigate(Program.browserData.URLToLoad);
            Program.browserView.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            return 0;
        }

        bool is_sec_page = false;
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!is_sec_page)
            {
                //get page element with id
                Program.browserView.webBrowser1.Document.GetElementById("username").InnerText = "tunisia";
                Program.browserView.webBrowser1.Document.GetElementById("password").InnerText = "tunisia";
                //login in to account(fire a login button promagatelly)
                Program.browserView.webBrowser1.Document.GetElementById("LoginButton").InvokeMember("click");
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
