using BrowserFormNavi.Model;
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
            Program.browserView.webBrowser1.Navigate(Program.formNavi.navigationURL.Text);
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
            Program.writingBrowserForm.CopyDataToInvokeComboBox();
            Program.formNavi.SetPropertyValue(Program.formNavi.CopyToBrowser, "BackColor", Color.LightGray);
            return 0;
        }

        public int InvokeSubmit()
        {
            Program.formNavi.SetPropertyValue(Program.formNavi.Submit, "BackColor", Color.Green);
            Program.writingBrowserForm.InvoikeSubmitValue();
            Program.formNavi.SetPropertyValue(Program.formNavi.Submit, "BackColor", Color.LightGray);
            return 0;
        }

        public int AutoFillInputValue()
        {
            Program.formNavi.SetPropertyValue(Program.formNavi.FillAutoGenertedData, "BackColor", Color.Green);
            Program.automation.AutoFillInputValue();
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
                try
                {
                    // Start the Data Mining
                    Program.formNavi.SetPropertyValue(Program.formNavi.ExtractFormFromBrowser, "BackColor", Color.Green);
                    int waitEfb = Convert.ToInt32(Program.formNavi.GetPropertyValue(Program.formNavi.timerExtractFromBrowser, "SelectedItem"));
                    Thread.Sleep(Program.rnd.Next(800 * waitEfb, 1200 * waitEfb));
                    if (!Program.keepTheNavigationLoopRunning) break;
                    WriteBrowserFormToGrid();

                    // Start the automated Form filler
                    Program.formNavi.SetPropertyValue(Program.formNavi.FillAutoGenertedData, "BackColor", Color.Green);
                    int waitFd = Convert.ToInt32(Program.formNavi.GetPropertyValue(Program.formNavi.timerFillData, "SelectedItem"));
                    Thread.Sleep(Program.rnd.Next(800 * waitFd, 1200 * waitFd));
                    if (!Program.keepTheNavigationLoopRunning) break;
                    AutoFillInputValue();

                    // Copy from Grid to Browser
                    Program.formNavi.SetPropertyValue(Program.formNavi.CopyToBrowser, "BackColor", Color.Green);
                    int waitCfb = Convert.ToInt32(Program.formNavi.GetPropertyValue(Program.formNavi.timerCopyToBrowser, "SelectedItem"));
                    Thread.Sleep(Program.rnd.Next(800 * waitCfb, 1200 * waitCfb));
                    if (!Program.keepTheNavigationLoopRunning) break;
                    CopyFromGridToBrowser();
                    
                    // save historical data
                    Program.formNavi.SetPropertyValue(Program.formNavi.SaveBrowserValuesToDB, "BackColor", Color.Green);
                    int waitSd = Convert.ToInt32(Program.formNavi.GetPropertyValue(Program.formNavi.timerSaveData, "SelectedItem"));
                    Thread.Sleep(Program.rnd.Next(800 * waitSd, 1200 * waitSd));
                    if (!Program.keepTheNavigationLoopRunning) break;
                    SaveBrowserFilledValuesToDatabase();

                    // Invoke the correct submit
                    Program.formNavi.SetPropertyValue(Program.formNavi.Submit, "BackColor", Color.Green);
                    Thread.Sleep(Program.rnd.Next(800, 1200));
                    if (!Program.keepTheNavigationLoopRunning) break;
                    InvokeSubmit();

                    if ((bool)Program.formNavi.GetPropertyValue(Program.formNavi.performLoop, "Checked") == false)
                    {
                        Program.keepTheNavigationLoopRunning = false;
                    }
                }
                catch (Exception ex)
                {
                    // Extract some information from this exception, and then 
                    if (ex.Source != null)
                        LogWriter.LogWrite("IOException source: " + ex.Source);

                    // if loop stop without user decision, restart the program
                    if (Program.keepTheNavigationLoopRunning && (bool)Program.formNavi.GetPropertyValue(Program.formNavi.autoRestart, "Checked"))
                    {
                        NavigationLoop();
                    }
                    // throw it to the parent method.
                    throw;
                }
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
            string domain = (string)Program.formNavi.GetPropertyValue(Program.formNavi.domains, "SelectedItem");

            // get the settings from database
            Program.dBAccess.GetDBData("DomainSettings",new object[] {domain});
            HashSet<string> tagsAndAttributesToExport = new HashSet<string>();
            Program.dBAccess.ColToHashSet("tagAndAttribute", ref tagsAndAttributesToExport);

            // loop and fill the TreeView
            TreeNodeCollection nodes = (TreeNodeCollection)Program.formNavi.GetPropertyValue(Program.formNavi.treeView1, "Nodes");
            foreach (TreeNode node in nodes)
            {
                // check defined and uncheck not defined nodes
                node.Checked = tagsAndAttributesToExport.Contains(node.Name) ? true : false;

                foreach (TreeNode child in node.Nodes)
                {
                    // check defined and uncheck not defined nodes
                    child.Checked = tagsAndAttributesToExport.Contains(child.Name) ? true : false;
                }
            }

            // Select the navigation URL 
            ComboBox.ObjectCollection navigationURLs = (ComboBox.ObjectCollection)Program.formNavi.GetPropertyValue(Program.formNavi.navigationURL, "Items");

            // loop over all entries in the combobox
            foreach (string item in navigationURLs)
            {
                string ComboBoxDomain = new Uri(item).Host;
                // compare the choosen domain with the domain in ComboBox
                if (ComboBoxDomain == domain)
                {
                    // select the choose domain's url
                    Program.formNavi.SetPropertyValue(Program.formNavi.navigationURL, "SelectedItem", item);
                    break;
                }
            }
            return 0;
        }
    }
}
