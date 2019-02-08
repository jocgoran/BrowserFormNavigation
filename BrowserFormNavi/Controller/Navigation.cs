using System;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    sealed class Navigation
    {
        public int OpenPage()
        {
            // Display the new form.  
            Program.browserView.Show();

            //navigate to you destination 
            Program.browserView.webBrowser1.Navigate(Program.formNavi.comboBox1.Text);
            Program.browserView.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(ExtractForm);

            return 0;
        }

        public void ExtractForm(object sender, EventArgs e)
        {
            if(!Program.browserData.FormExtracted)
                Program.readingBrowserForm.ExtractBrowserForm();
        }

        public int WriteToGrid()
        {
            return 0;
        }

        public int CopyFromGridToBrowser()
        {
            return 0;
        }

        public int InvokeSubmit()
        {
            return 0;
        }

    }
}
