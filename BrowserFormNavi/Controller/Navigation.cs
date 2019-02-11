using System;
using System.Threading;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    public class Navigation
    {
        public int OpenPage()
        {
            // Display the new form.  
            if (!Program.browserView.Visible)
                Program.browserView.Show();

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
            Thread t = new Thread(StopTheNavigationLoop);
            t.Start();

            NavigationLoop();
            return 0;
        }

        public void StopTheNavigationLoop()
        {
            MessageBox.Show("Clieck when you want to abort", "Abort", MessageBoxButtons.OK);
            Program.keepTheNavigationLoopRunning = false;
        }

        public int NavigationLoop()
        {
            Program.keepTheNavigationLoopRunning = true;
            // perform all the steps with 5 seconds waithing
            while (Program.keepTheNavigationLoopRunning)
            {
                Thread.Sleep(5000);
                AutoFillInputValue();
                Thread.Sleep(5000);
                CopyFromGridToBrowser();
                Thread.Sleep(5000);
                SaveBrowserFilledValuesToDatabase();
                Thread.Sleep(5000);
                InvokeSubmit();
                Thread.Sleep(5000);
                WriteBrowserFormToGrid();
            }
            return 0;
        }
    }
}
