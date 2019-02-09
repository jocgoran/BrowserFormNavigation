using System.Windows.Forms;

namespace BrowserFormNavi.Model
{
    sealed class FormData
    {

        public int GetHistoricalData()
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
                    string domain = Program.formNavi.comboBox1.Text;
                    string formPageSpecificID = row.Cells["FormID"].Value.ToString();
                    string tag = row.Cells["Tag"].Value.ToString();
                    string type = row.Cells["Type"].Value.ToString();
                    string name = row.Cells["Name"].Value.ToString();
                    string inputFieldID = row.Cells["ID"].Value.ToString();

                    Program.dBAccess.retriveExactValue(url, domain, formPageSpecificID, tag, type, name, inputFieldID);
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
