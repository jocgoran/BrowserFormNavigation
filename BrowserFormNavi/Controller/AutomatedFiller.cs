using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    public class AutomatedFiller
    {
        public int AutoFillInputValue()
        {
            // read the form that have to be submitted  
            string ChoosenFormNr = Program.formNavi.GetComboBoxSelectedItem(Program.formNavi.comboBox2);

            // loop over all the rows of data grid
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                // handle only chooen form data
                if (Program.formNavi.GetDataGridCell(row, "FormID") == ChoosenFormNr)
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
