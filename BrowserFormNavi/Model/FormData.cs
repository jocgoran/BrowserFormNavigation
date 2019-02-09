using System.Windows.Forms;
using System;

namespace BrowserFormNavi.Model
{
    sealed class FormData
    {
        public object GetDomain { get; private set; }

        public int MatchExactInputData()
        {
            // read the form that have to be submitted  
            string ChoosenFormNr = Program.formNavi.comboBox2.SelectedItem.ToString();

            // loop over all the rows of data grid
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                // handle only chooen form data
                if (row.Cells["FormID"].Value.ToString() == ChoosenFormNr)
                {

                    string url = Program.formNavi.comboBox1.Text;
                    string domain = new Uri(Program.formNavi.comboBox1.Text).Host;
                    string tag = row.Cells["Tag"].Value.ToString();
                    string type = row.Cells["Type"].Value.ToString();
                    string name = row.Cells["Name"].Value.ToString();
                    string inputFieldID = row.Cells["ID"].Value.ToString();

                    // insert the input once 
                    int error = Program.dBAccess.insertInputFormData(url, domain, tag, type, name, inputFieldID);

                    // insert not success - data exists
                    string value="", sCheckbox="";
                    Program.dBAccess.retriveExactFormDataValue(url, domain, tag, type, name, inputFieldID, ref value, ref sCheckbox);
                    if (!string.IsNullOrEmpty(value))
                        row.Cells["Value"].Value = value;
                    if (!string.IsNullOrEmpty(sCheckbox))
                        row.Cells["Checkbox"].Value = sCheckbox;

                } // end row enrichment
            } // end DataGrid loop

            return 0;

        }

        public int GetStatisticValue()
        {
            return 0;
        }

        public int SaveHistoricalData()
        {
            //   table Login | domain - login - password
            //table from | domain - tag - type - id - name - value
            //table  AutomatedValue | FormId - value - checked - Count - Error

            return 0;
        }
    }
}
