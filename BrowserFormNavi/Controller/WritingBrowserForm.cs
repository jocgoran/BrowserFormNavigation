using System;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    sealed class WritingBrowserForm
    {
     
        public int CopyDataToBrowser()
        {
            // read the form that have to be submitted  
            int iChoosenFormNr = Convert.ToInt32(Program.formNavi.comboBox2.SelectedItem)-1;

            // extract the correct form
            HtmlElementCollection forms = Program.browserView.webBrowser1.Document.GetElementsByTagName("form");
            HtmlElement form = forms[iChoosenFormNr];

            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                string cellValue = "";
                if(row.Cells["value"].Value != null)
                    cellValue = row.Cells["value"].Value.ToString();

                // set the corresponding element in Browser depending on ID
                if (row.Cells["id"].Value != null)
                { 
                    Program.browserView.webBrowser1.Document.GetElementById(row.Cells["id"].Value.ToString()).SetAttribute("value", cellValue);
                }
                // set the corresponding element in Browser depending on ID
                else if (row.Cells["name"].Value != null)
                { 
                    //Program.browserView.webBrowser1.Document.getElementsByName(row.Cells["name"].Value.ToString()).SetAttribute("value", cellValue);
                }

            }

            return 0;
        }

        public int InvokeFormSubmit()
        {
            // reset the Browser loading var
            Program.browserData.FormExtracted = false;
            // clear DataGrid with form data 
            Program.formNavi.dataGridView1.Rows.Clear();
            // clear drop down menu of choosen form
            Program.formNavi.comboBox2.Items.Clear();

            //submit form
            Program.browserView.webBrowser1.Document.GetElementById("LoginButton").InvokeMember("click");
            return 0;
        }

}
}
