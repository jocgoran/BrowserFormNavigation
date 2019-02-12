using System;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    public class WritingBrowserForm
    {

        public int CopyDataToBrowser()
        {
            if (string.IsNullOrEmpty(Program.formNavi.GetComboBoxSelectedItem(Program.formNavi.comboBox2)))
            {
                MessageBox.Show("Choose a form", "Missong data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 1;
            }

            // read the form that have to be submitted  
            string ChoosenFormNr = Program.formNavi.GetComboBoxSelectedItem(Program.formNavi.comboBox2);

            // loop over all the rows of data grid
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                // handle only chooen form data
                if (Program.formNavi.GetDataGridCell(row, "FormID") == ChoosenFormNr)
                {
                    // loop over all the input to find where to copy the value
                    HtmlElementCollection forms = Program.browserView.webBrowser1.Document.GetElementsByTagName("form");
                    foreach (HtmlElement form in forms)
                    {
                        HtmlElementCollection inputs = form.GetElementsByTagName("input");
                        foreach (HtmlElement input in inputs)
                        {
                            // if the input match the entry in the DataGrid 
                            if (input.GetAttribute("BFN_ID") == row.Cells["BFN_ID"].Value.ToString())
                            {
                                string cellValue = "";
                                if(row.Cells["value"].Value!=null) cellValue=row.Cells["value"].Value.ToString();
                                string cellChecked = "";
                                if(row.Cells["checked"].Value!=null) cellChecked=row.Cells["checked"].Value.ToString();

                                // set value to the browser
                                input.SetAttribute("value", cellValue);

                                // set checked to the browser
                                input.SetAttribute("checked", cellChecked);

                            } // end if BFN_ID
                        } // end loop input
                    } // end loop form
                } // end if choosen FormID
            } // end DataGrid loop

            // needed to see the new values
            Program.browserView.webBrowser1.Update();

            return 0;
        }

        public int InvokeFormSubmit()
        {
            // reset the Browser loading var
            Program.browserData.FormExtracted = false;

            // read the form that have to be submitted  
            string ChoosenFormNr = Program.formNavi.comboBox2.SelectedItem.ToString();
                       
            // loop over all the rows of data grid to find submit button
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                // last row is empty
                if (row.Cells["FormID"].Value == null) continue;
                if (row.Cells["TypeAttribute"].Value == null) continue;

                string formType = row.Cells["TypeAttribute"].Value.ToString();

                // handle only chooen form data and the type=submit
                if (row.Cells["FormID"].Value.ToString() == ChoosenFormNr
                   && formType.ToLower() == "submit")
                {
                    // loop over all the input to find where the submit type is
                    HtmlElementCollection forms = Program.browserView.webBrowser1.Document.GetElementsByTagName("form");
                    foreach (HtmlElement form in forms)
                    {
                        HtmlElementCollection inputs = form.GetElementsByTagName("input");
                        foreach (HtmlElement input in inputs)
                        {
                            if (input.GetAttribute("BFN_ID") == row.Cells["BFN_ID"].Value.ToString())
                            {
                                // invoke the Submit
                                input.InvokeMember("click");

                            } // end if BFN_ID
                        } // end loop input
                    } // end loop form
                } // end if choosen FormID
            } // end DataGrid loop

            // needed to see the new values
            Program.browserView.webBrowser1.Update();
            return 0;
        }

}
}
