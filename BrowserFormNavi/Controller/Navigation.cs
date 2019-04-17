using BrowserFormNavi.Model;
using BrowserFormNavi.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static BrowserFormNavi.Program;

namespace BrowserFormNavi.Controller
{
    public class Navigation
    {

        private int CreateWebBrowser()
        {
            Program.browserView = new BrowserView();
            return 0;
        }

        public int OpenPage()
        {
            // recreate if the form was closed by user
            if (Program.browserView == null || (bool)Program.browserView.GetPropertyValue(Program.browserView, "IsDisposed"))
            {
                Thread wBThread = new Thread(() => CreateWebBrowser());
                wBThread.SetApartmentState(ApartmentState.STA);
                wBThread.Start();
                wBThread.Join();
            }

            // Display the new form.  
            if (!(bool)Program.browserView.GetPropertyValue(Program.browserView, "Visible"))
            {
                Program.browserView.ShowBrowserView();
            }

            // recreate if the form was closed by user
            if (Program.browserView.webBrowser1 == null || (bool)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "IsDisposed"))
            {
                Program.browserView.InitializeWebBrowser();
            }
            Thread.Sleep(500);

            //navigate to you destination 
            string url = (string)Program.formNavi.GetPropertyValue(Program.formNavi.navigationURL, "Text");

            //start the navigation in a new thread
            //Thread thread = new Thread(() => Program.browserView.webBrowser1.Navigate(url));
            //thread.SetApartmentState(ApartmentState.STA);
            //thread.Start();
            Program.browserView.WebBrowserNavigate(url);

            return 0;
        }

        public int WriteBrowserFormToGrid()
        {
            Program.formNavi.SetPropertyValue(Program.formNavi.ExtractFormFromBrowser, "BackColor", Color.Green);
            Program.htmlDoc.ExtractBrowserForm();
            Program.formNavi.SetPropertyValue(Program.formNavi.ExtractFormFromBrowser, "BackColor", Color.LightGray);
            return 0;
        }

        public int CopyFromGridToBrowser()
        {
            Program.formNavi.SetPropertyValue(Program.formNavi.CopyToBrowser, "BackColor", Color.Green);
            Program.dataGrid.PushDataToBrowser();
            Program.formNavi.SetPropertyValue(Program.formNavi.CopyToBrowser, "BackColor", Color.LightGray);
            return 0;
        }

        public int InvokeSubmit()
        {
            Program.formNavi.SetPropertyValue(Program.formNavi.Submit, "BackColor", Color.Green);
            Program.dataGrid.InvoikeSubmitValue();
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
            Program.htmlDoc.SaveBrowserValuesToDatabase();
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
                    if (!Program.keepTheNavigationLoopRunning) break;
                    int waitEfb = Convert.ToInt32(Program.formNavi.GetPropertyValue(Program.formNavi.timerExtractFromBrowser, "SelectedItem"));
                    Thread.Sleep(Program.rnd.Next((1000 * waitEfb), (1000 * waitEfb)+500));
                    WriteBrowserFormToGrid();

                    // Start the automated Form filler
                    Program.formNavi.SetPropertyValue(Program.formNavi.FillAutoGenertedData, "BackColor", Color.Green);
                    if (!Program.keepTheNavigationLoopRunning) break;
                    int waitFd = Convert.ToInt32(Program.formNavi.GetPropertyValue(Program.formNavi.timerFillData, "SelectedItem"));
                    Thread.Sleep(Program.rnd.Next((1000 * waitFd), (1000 * waitFd) + 500));
                    AutoFillInputValue();

                    // Copy from Grid to Browser
                    Program.formNavi.SetPropertyValue(Program.formNavi.CopyToBrowser, "BackColor", Color.Green);
                    if (!Program.keepTheNavigationLoopRunning) break;
                    int waitCfb = Convert.ToInt32(Program.formNavi.GetPropertyValue(Program.formNavi.timerCopyToBrowser, "SelectedItem"));
                    Thread.Sleep(Program.rnd.Next((1000 * waitCfb), (1000 * waitCfb) + 500));
                    CopyFromGridToBrowser();

                    // save historical data
                    Program.formNavi.SetPropertyValue(Program.formNavi.SaveBrowserValuesToDB, "BackColor", Color.Green);
                    if (!Program.keepTheNavigationLoopRunning) break;
                    int waitSd = Convert.ToInt32(Program.formNavi.GetPropertyValue(Program.formNavi.timerSaveData, "SelectedItem"));
                    Thread.Sleep(Program.rnd.Next((1000 * waitSd), (1000 * waitSd) + 500));
                    SaveBrowserFilledValuesToDatabase();

                    // Invoke the correct submit
                    Program.formNavi.SetPropertyValue(Program.formNavi.Submit, "BackColor", Color.Green);
                    if (!Program.keepTheNavigationLoopRunning) break;
                    InvokeSubmit();
                }
                catch (Exception ex)
                {
                    // Extract some information from this exception, and then 
                    LogWriter.LogWrite(LogLevel.Error, "Catch Exception source: " + ex.InnerException);
                    LogWriter.LogWrite(LogLevel.Error, "Catch Exception source: " + ex.Message);

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

        public int LoadDomainSettings()
        {
            // get the saved setting on click
            string domain = (string)Program.formNavi.GetPropertyValue(Program.formNavi.domains, "SelectedItem");

            // get the settings from database
            DataTable domainSettings = new DataTable();
            Program.dBAccess.GetDBData("DomainSettings",new object[] {domain}, ref domainSettings);
            //create HashSet
            HashSet<string> tagsAndAttributesToExport = new HashSet<string>();
            foreach (DataRow domainSetting in domainSettings.Rows)
            {
                // fill data into HashSet
                tagsAndAttributesToExport.Add(domainSetting["tagAndAttribute"].ToString());
            }

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

            // dispose the DataTable
            domainSettings.Dispose();
            return 0;
        }
    }
}
