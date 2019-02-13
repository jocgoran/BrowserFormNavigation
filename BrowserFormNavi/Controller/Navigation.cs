using BrowserFormNavi.View;
using System;
using System.Threading;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    public class Navigation
    {
        public int OpenPage()
        {
            Program.browserView.Dispose();
            Program.browserView.Open();
            if (Program.browserView==null)
            {
                Program.browserView = new BrowserView();
            }

            // Display the new form.  
            if (!Program.browserView.Visible)
            {
                Program.browserView.Show();
            }
            //navigate to you destination 
            Program.browserView.webBrowser1.Navigate(Program.formNavi.comboBox1.Text);
            Program.browserView.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(ExtractForm);

            return 0;
        }

        public void ExtractForm(object sender, EventArgs e)
        {
            if (!Program.browserData.FormExtracted)
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

        public int SaveBrowserFilledValuesToDatabase()
        {
            Program.readingBrowserForm.SaveBrowserValuesToDatabase();
            return 0;
        }

        public int StartTheNavigationLoop()
        {
            NavigationLoop();
            return 0;
        }

        public int StopTheNavigationLoop()
        {
            Program.keepTheNavigationLoopRunning = false;
            return 0;
        }

        public int NavigationLoop()
        {
            Program.keepTheNavigationLoopRunning = true;
            // perform all the steps with 5 seconds waithing
            while (Program.keepTheNavigationLoopRunning)
            {
                Thread.Sleep(5000);
                if (!Program.keepTheNavigationLoopRunning) break;
                AutoFillInputValue();
                Thread.Sleep(5000);
                if (!Program.keepTheNavigationLoopRunning) break;
                CopyFromGridToBrowser();
                Thread.Sleep(5000);
                if (!Program.keepTheNavigationLoopRunning) break;
                SaveBrowserFilledValuesToDatabase();
                Thread.Sleep(5000);
                if (!Program.keepTheNavigationLoopRunning) break;
                InvokeSubmit();
                Thread.Sleep(5000);
                if (!Program.keepTheNavigationLoopRunning) break;
                WriteBrowserFormToGrid();
            }
            return 0;
        }
    }
}
