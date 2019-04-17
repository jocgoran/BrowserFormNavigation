using BrowserFormNavi.Model;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BrowserFormNavi.Program;

namespace BrowserFormNavi.Controller
{
    public class DataGrid
    {
        //this is to reduce the memory leak in the WebBrowser
        [DllImport("KERNEL32.DLL", EntryPoint = "SetProcessWorkingSetSize", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool SetProcessWorkingSetSize(IntPtr pProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

        [DllImport("KERNEL32.DLL", EntryPoint = "GetCurrentProcess", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr GetCurrentProcess();

        public int PushDataToBrowser()
        {
            // get the Browser document thread safe
            HtmlDocument htmlDocument = (HtmlDocument)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "Document");

            // loop over htmlElements
            HtmlElementCollection htmlElements = htmlDocument.All;
            Parallel.For(0, htmlElements.Count, i =>
            {
                // elements can be changed dynamically - prevent outOfIndex
                if (i >= htmlElements.Count) return;

                // prevent outOfIndex
                try
                {
                    // elaborate only htmlElments with BFN_ID values
                    if (string.IsNullOrEmpty(htmlElements[i].GetAttribute("BFN_ID"))) return;

                    // loop over all the rows of data grid
                    foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
                    {
                        // skip row that don't are same BFN_ID
                        if (string.Equals(Program.formNavi.GetDataGridCell(row, "BFN_ID"), htmlElements[i].GetAttribute("BFN_ID")) == false) continue;

                        string cellValue = "";
                        if (string.IsNullOrEmpty(Program.formNavi.GetDataGridCell(row, "valueAttribute")) == false)
                        {
                            cellValue = Program.formNavi.GetDataGridCell(row, "valueAttribute");
                        }
                        string cellChecked = "";
                        if (string.IsNullOrEmpty(Program.formNavi.GetDataGridCell(row, "checkedAttribute")) == false)
                        {
                            cellChecked = Program.formNavi.GetDataGridCell(row, "checkedAttribute");
                        }

                        // set value to the browser
                        htmlElements[i].SetAttribute("value", cellValue);

                        // set checked to the browser
                        htmlElements[i].SetAttribute("checked", cellChecked);

                    } // end htmlElements loop
                }
                catch (Exception e)
                {
                    LogWriter.LogWrite(LogLevel.Warning, "In DataGrid, not found element: " + i.ToString());
                    LogWriter.LogWrite(LogLevel.Error, "Exception caught." + e);
                    return;
                }

            });
            return 0;
        }

        public int PushDataToInvokeComboBox()
        {
            double maxAlgoInvoke = 0;
            string BFNIDToInvoke = "";

            // loop over all the rows of data grid and apply the find the matching submit button
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                double AlgoInvoke = Convert.ToDouble(row.Cells["AlgoInvoke"].Value);
                if (AlgoInvoke == 1)
                {
                    maxAlgoInvoke = AlgoInvoke;
                    BFNIDToInvoke = row.Cells["BFN_ID"].Value.ToString();
                    break;
                }
                else if (AlgoInvoke > maxAlgoInvoke)
                { 
                    maxAlgoInvoke = AlgoInvoke;
                    BFNIDToInvoke = row.Cells["BFN_ID"].Value.ToString();
                }
            }

            //checkif exact match is requested
            bool exactMatch = false;
            if ( (exactMatch && maxAlgoInvoke == 1)
                || !exactMatch)
            {
                //set invoke of biggest probability to be correct
                Program.formNavi.SetPropertyValue(Program.formNavi.BFN_IDInvoke, "SelectedItem", BFNIDToInvoke);
            }
            
            return 0;
        }

        public int InvoikeSubmitValue()
        {

            // reload if rule says so
            if ((string)Program.formNavi.GetPropertyValue(Program.formNavi.refreshable, "Text") == "1.00")
            {
                Program.browserView.CleanUp();
                Program.navigation.OpenPage();
                //Program.browserView.webBrowser1.Refresh(WebBrowserRefreshOption.Completely);
                //Program.browserView.GetMethod(Program.browserView.webBrowser1, "Refresh", new object[] { });
                return 0;
            }

            // read the form that have to be submitted  
            string ChoosenBFNID = (string)Program.formNavi.GetPropertyValue(Program.formNavi.BFN_IDInvoke, "SelectedItem");

            //handle the nothing to submit
            if (string.IsNullOrEmpty(ChoosenBFNID))
            {
                Program.keepTheNavigationLoopRunning = false;
                return 0;
            }

            // get the Browser document thread safe
            HtmlDocument htmlDocument = (HtmlDocument)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "Document");

            // loop over htmlElements
            HtmlElementCollection htmlElements = htmlDocument.All;
            Parallel.For(0, htmlElements.Count, i =>
            {
                // elements can be changed dynamically - prevent outOfIndex
                if (i >= htmlElements.Count) return;

                // prevent outOfIndex
                try
                {
                    // elaborate only htmlElments with BFN_ID
                    if (string.IsNullOrEmpty(htmlElements[i].GetAttribute("BFN_ID"))) return;

                    // reset id of row that don't contain the invoked BFN_ID
                    if (string.Equals(ChoosenBFNID, htmlElements[i].GetAttribute("BFN_ID")) == false)
                        {
                        htmlElements[i].SetAttribute("BFN_ID", "");
                        return;
                        }

                    // invoke (we are already in a thread)
                    htmlElements[i].InvokeMember("click");

                    // invoke can shift elements, avoid another "wrong" invoke
                    ChoosenBFNID = "-1";

                    // Count the invokations 
                    object invokationsCount = Program.formNavi.GetPropertyValue(Program.formNavi.InvokationDone, "Text");
                    int iInvokationsCount = 0;
                    if (!string.IsNullOrEmpty(invokationsCount.ToString())) iInvokationsCount = Convert.ToInt32(invokationsCount);
                    ++iInvokationsCount;
                    Program.formNavi.SetPropertyValue(Program.formNavi.InvokationDone, "Text", iInvokationsCount.ToString());

                    // reset id of row that contain the invoked BFN_ID
                    htmlElements[i].SetAttribute("BFN_ID", "");

                }
                catch (Exception e)
                {
                    LogWriter.LogWrite(LogLevel.Warning, "In Invoke, not found element: " + i.ToString());
                    LogWriter.LogWrite(LogLevel.Error, "Exception caught." + e);
                    return;
                }
            });

            // reduce the memory of WebBrowser
            IntPtr pHandle = GetCurrentProcess();
            SetProcessWorkingSetSize(pHandle, -1, -1);

            return 0;
        }

    }
}
