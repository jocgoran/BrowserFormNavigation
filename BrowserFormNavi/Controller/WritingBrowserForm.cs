using System;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    public class WritingBrowserForm
    {

        public int CopyDataToBrowser()
        {
            // loop over all the rows of data grid
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                // read if the submit is an input or a button
                String tagName = Program.formNavi.GetDataGridCell(row, "TagAttribute");

                // get the Browser document thread safe
                HtmlDocument htmlDocument = Program.browserView.GetHtmlDocument();

                // loop over all the ag elements to find where to copy the value
                HtmlElementCollection tagNameCollection = htmlDocument.GetElementsByTagName(tagName);
                foreach (HtmlElement tagNameElement in tagNameCollection)
                {
                    // if the input match the entry in the DataGrid 
                    if (tagNameElement.GetAttribute("BFN_ID") == Program.formNavi.GetDataGridCell(row, "BFN_ID"))
                    {
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
                        tagNameElement.SetAttribute("value", cellValue);

                        // set checked to the browser
                        tagNameElement.SetAttribute("checked", cellChecked);

                    } // end if BFN_ID
                } // end loop of tagName

            } // end DataGrid loop

            return 0;
        }

        public int InvokeFormSubmit()
        {
            // reset the Browser loading var
            Program.browserData.FormExtracted = false;

            // read the form that have to be submitted  
            string ChoosenBFNID = Program.formNavi.GetComboBoxSelectedItem(Program.formNavi.comboBox2);

            // loop over all the rows of data grid to find submit button
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                // check the row BNF_ID
                if (Program.formNavi.GetDataGridCell(row, "BFN_ID") == ChoosenBFNID)
                {
                    // read the tagName of submit
                    String submitTagName = Program.formNavi.GetDataGridCell(row, "TagAttribute");

                    // get the Browser document thread safe
                    HtmlDocument htmlDocument = Program.browserView.GetHtmlDocument();

                    // get all the forms from browser
                    HtmlElementCollection submitTagNameCollection = htmlDocument.GetElementsByTagName(submitTagName);

                    // loop over all the tags that are same as submit 
                    foreach (HtmlElement submitElement in submitTagNameCollection)
                    {
                        // match the broser tagElement corresponding to DataGrid 
                        if (submitElement.GetAttribute("BFN_ID") == ChoosenBFNID)
                        {
                            // invoke the Submit
                            submitElement.InvokeMember("click");

                        } // end if BFN_ID
                    } // end loop submitElement

                } // end if choosen FormID
            } // end DataGrid loop

            return 0;
        }
    }
}
