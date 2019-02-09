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
                WriteBrowserFormToGrid();
        }

        public int WriteBrowserFormToGrid()
        {
            Program.readingBrowserForm.ExtractBrowserForm();
            return 0;
        }

        public int CopyFromGridToBrowser()
        {
            Program.writingBrowserForm.CopyDataToBrowser(); 
            return 0;
        }

        public int InvokeSubmit()
        {
            Program.writingBrowserForm.InvokeFormSubmit();
            return 0;
        }

        public int AutoFillInputValue()
        {
            Program.automatedFiller.AutoFillInputValue();
            return 0;
        }
    }
}
