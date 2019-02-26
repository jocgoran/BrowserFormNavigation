using BrowserFormNavi.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    public class Navigation
    {
        public int OpenPage()
        {
            // reset the page var
            Program.browserData.FormExtracted = false;

            // recreate if the form was closed by user
            if (Program.browserView.IsDisposed)
            {
                Program.browserView = new BrowserView();
            }

            // Display the new form.  
            if (!Program.browserView.Visible)
            {
                Program.browserView.ShowBrowserView();
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
            Program.formNavi.SetPropertyValue(Program.formNavi.ExtractFormFromBrowser, "BackColor", Color.Green);
            Program.readingBrowserForm.ExtractBrowserForm();
            Program.formNavi.SetPropertyValue(Program.formNavi.ExtractFormFromBrowser, "BackColor", Color.LightGray);
            return 0;
        }

        public int CopyFromGridToBrowser()
        {
            Program.formNavi.SetPropertyValue(Program.formNavi.CopyToBrowser, "BackColor", Color.Green);
            Program.writingBrowserForm.CopyDataToBrowser();
            Program.formNavi.SetPropertyValue(Program.formNavi.CopyToBrowser, "BackColor", Color.LightGray);
            return 0;
        }

        public int InvokeSubmit()
        {
            Program.formNavi.SetPropertyValue(Program.formNavi.Submit, "BackColor", Color.Green);
            Program.writingBrowserForm.InvokeFormSubmit();
            Program.formNavi.SetPropertyValue(Program.formNavi.Submit, "BackColor", Color.LightGray);
            return 0;
        }

        public int AutoFillInputValue()
        {
            Program.formNavi.SetPropertyValue(Program.formNavi.FillAutoGenertedData, "BackColor", Color.Green);
            Program.automatedFiller.AutoFillInputValue();
            Program.formNavi.SetPropertyValue(Program.formNavi.FillAutoGenertedData, "BackColor", Color.LightGray);
            return 0;
        }

        public int SaveBrowserFilledValuesToDatabase()
        {
            Program.formNavi.SetPropertyValue(Program.formNavi.SaveBrowserValuesToDB, "BackColor", Color.Green);
            Program.readingBrowserForm.SaveBrowserValuesToDatabase();
            Program.formNavi.SetPropertyValue(Program.formNavi.SaveBrowserValuesToDB, "BackColor", Color.LightGray);
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

            while (Program.keepTheNavigationLoopRunning)
            {
                Program.formNavi.SetPropertyValue(Program.formNavi.ExtractFormFromBrowser, "BackColor", Color.Green);
                int waitEfb = Convert.ToInt32(Program.formNavi.GetPropertyValue(Program.formNavi.timerExtractFromBrowser, "SelectedItem"));
                Thread.Sleep(Program.rnd.Next(800*waitEfb, 1200*waitEfb));
                if (!Program.keepTheNavigationLoopRunning) break;
                WriteBrowserFormToGrid();
                
                Program.formNavi.SetPropertyValue(Program.formNavi.FillAutoGenertedData, "BackColor", Color.Green);
                int waitFd = Convert.ToInt32(Program.formNavi.GetPropertyValue(Program.formNavi.timerFillData, "SelectedItem"));
                Thread.Sleep(Program.rnd.Next(800 * waitFd, 1200 * waitFd));
                if (!Program.keepTheNavigationLoopRunning) break;
                AutoFillInputValue();

                Program.formNavi.SetPropertyValue(Program.formNavi.CopyToBrowser, "BackColor", Color.Green);
                int waitCfb = Convert.ToInt32(Program.formNavi.GetPropertyValue(Program.formNavi.timerCopyToBrowser, "SelectedItem"));
                Thread.Sleep(Program.rnd.Next(800 * waitCfb, 1200 * waitCfb));
                if (!Program.keepTheNavigationLoopRunning) break;
                CopyFromGridToBrowser();

                Program.formNavi.SetPropertyValue(Program.formNavi.SaveBrowserValuesToDB, "BackColor", Color.Green);
                int waitSd = Convert.ToInt32(Program.formNavi.GetPropertyValue(Program.formNavi.timerSaveData, "SelectedItem"));
                Thread.Sleep(Program.rnd.Next(800 * waitSd, 1200 * waitSd));
                if (!Program.keepTheNavigationLoopRunning) break;
                SaveBrowserFilledValuesToDatabase();

                // Select the Index 5
                Program.formNavi.SetPropertyValue(Program.formNavi.comboBox2, "SelectedItem", 6);

                Program.formNavi.SetPropertyValue(Program.formNavi.Submit, "BackColor", Color.Green);
                Thread.Sleep(Program.rnd.Next(800, 1200));
                if (!Program.keepTheNavigationLoopRunning) break;
                InvokeSubmit();

            }
            return 0;
        }

        public int SubmitSpecial()
        {
            Program.specialSubmitter.LikeEverytingOnFacebook(); 
            return 0;
        }

        public int LoadDomainSettings()
        {
            // get the saved setting on click
            string domain = (string)Program.formNavi.GetPropertyValue(Program.formNavi.listBox1, "SelectedItem");

            // get the settings from database
            HashSet<string> tagsAndAttributesToExport = new HashSet<string>();
            Program.dBAccess.GetDomainSettings(domain, ref tagsAndAttributesToExport);

            // loop and fill the TreeView
            TreeNodeCollection nodes = (TreeNodeCollection)Program.formNavi.GetPropertyValue(Program.formNavi.treeView1, "Nodes");
            foreach (TreeNode node in nodes)
            {
                node.Checked = tagsAndAttributesToExport.Contains(node.Name) ? true : false;

                foreach (TreeNode child in node.Nodes)
                {
                    child.Checked = tagsAndAttributesToExport.Contains(child.Name) ? true : false;
                }
                    
            }
            return 0;
        }
    }
}
