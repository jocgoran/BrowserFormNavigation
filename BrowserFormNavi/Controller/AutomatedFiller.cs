using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    public class AutomatedFiller
    {

        public int SaveHistoricData()
        {
            return 0;
        }

        public int AutoFillInputValue()
        {
            // read the form that have to be submitted  
            string ChoosenFormNr = Program.formNavi.comboBox2.SelectedItem.ToString();

            // loop over all the rows of data grid
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                // handle only chooen form data
                if (row.Cells["FormID"].Value.ToString() == ChoosenFormNr)
                {
                    // add input and try to retrieve exact match
                    int success = Program.formData.MatchExactInputData(row);

                    // if exact match not works, use most reliable data
                    if(success>0)
                        success = Program.formData.GetMostReliableValue();

                } // end row enrichment
            } // end DataGrid loop

            return 0;
        }
    }
}
