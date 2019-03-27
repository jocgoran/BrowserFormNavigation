using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    public class WritingDataGridForm
    {
        //this is to reduce the memory leak in the WebBrowser
        [DllImport("KERNEL32.DLL", EntryPoint = "SetProcessWorkingSetSize", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool SetProcessWorkingSetSize(IntPtr pProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

        [DllImport("KERNEL32.DLL", EntryPoint = "GetCurrentProcess", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr GetCurrentProcess();

        public int CopyDataToBrowser()
        {
            // get the Browser document thread safe
            HtmlDocument htmlDocument = (HtmlDocument)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "Document");

            // get over the whole doc
            HtmlElementCollection tagElements = htmlDocument.All;

            // loop over all the rows of data grid
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                // Get the index of DOM element
                int indexOfTagElement = Convert.ToInt32(Program.formNavi.GetDataGridCell(row, "BFN_ID"));

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
                tagElements[indexOfTagElement].SetAttribute("value", cellValue);

                // set checked to the browser
                tagElements[indexOfTagElement].SetAttribute("checked", cellChecked);

            } // end DataGrid loop

            return 0;
        }

        public int CopyDataToInvokeComboBox()
        {
            int maxAlgoInvoke = 0;
            string BFNIDToInvoke = "";
            // loop over all the rows of data grid and apply the find the matching submit button
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                int AlgoInvoke = Convert.ToInt32(row.Cells["AlgoInvoke"].Value);
                if (AlgoInvoke == 1)
                {
                    BFNIDToInvoke = row.Cells["BFN_ID"].Value.ToString();
                    break;
                }
                else if (AlgoInvoke > maxAlgoInvoke)
                { 
                    maxAlgoInvoke = AlgoInvoke;
                    BFNIDToInvoke = row.Cells["BFN_ID"].Value.ToString();
                }
            }

            //set if there is at least one value that return a small probability to be correct
          //  if (maxAlgoInvoke>0)
                Program.formNavi.SetPropertyValue(Program.formNavi.BFN_IDInvoke, "SelectedItem", BFNIDToInvoke);

            return 0;
        }

        public int InvoikeSubmitValue()
        {
            // read the form that have to be submitted  
            object SelectedItem = Program.formNavi.GetPropertyValue(Program.formNavi.BFN_IDInvoke, "SelectedItem");

            //handle the nothing to submit
            if (SelectedItem == null)
            {   // reload if nothing to invoke
                if ((bool)Program.formNavi.GetPropertyValue(Program.formNavi.relaodIFNoInvoke, "Checked") == true)
                {
                    // collect object garbage
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    Program.browserView.webBrowser1.Refresh(WebBrowserRefreshOption.Completely);
                    //Program.browserView.GetMethod(Program.browserView.webBrowser1, "Refresh", new object[] { });
                }
                return 0;
            }
            
            // convert to indexID
            int ChoosenBFNID = Convert.ToInt32(SelectedItem);

            // get the Browser document thread safe
            HtmlDocument htmlDocument = (HtmlDocument)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "Document");

            // extract all the tag elements
            HtmlElementCollection tagElements = htmlDocument.All;

            //start the navigation in a new thread 
            Thread thread = new Thread(() => tagElements[ChoosenBFNID].InvokeMember("click"));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            // Count the invokations 
            object invokationsCount = Program.formNavi.GetPropertyValue(Program.formNavi.InvokationDone, "Text");
            int iInvokationsCount = 0;
            if(!string.IsNullOrEmpty(invokationsCount.ToString())) iInvokationsCount=Convert.ToInt32(invokationsCount);
            ++iInvokationsCount;
            Program.formNavi.SetPropertyValue(Program.formNavi.InvokationDone, "Text", iInvokationsCount.ToString());

            // reduce the memory of WebBrowser
            IntPtr pHandle = GetCurrentProcess();
            SetProcessWorkingSetSize(pHandle, -1, -1);

            return 0;
        }

    }
}
