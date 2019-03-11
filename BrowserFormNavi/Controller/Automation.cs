using System;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    public class Automation
    {
        public int AutoFillInputValue()
        {
            // loop over all the rows of data grid
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                // add input and try to retrieve exact match
                int success = Program.statisticalPrediction.MatchExactInputData(row);

                // if exact match not works, use most reliable data
                //if(success>0)
                //    success = Program.formData.GetMostReliableValue();

            } // end DataGrid loop

            return 0;
        }


        public int InvoikeAutoSubmitValue()
        {
            // reset the Browser loading var
            Program.browserData.FormExtracted = false;

            // read the form that have to be submitted  
            object SelectedItem = Program.formNavi.GetPropertyValue(Program.formNavi.comboBox2, "SelectedItem");
            string ChoosenBFNID = String.Concat(SelectedItem);

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
