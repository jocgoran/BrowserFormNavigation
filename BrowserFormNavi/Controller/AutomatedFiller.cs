using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    public class AutomatedFiller
    {
        public int AutoFillInputValue()
        {
            // loop over all the rows of data grid
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                // add input and try to retrieve exact match
                int success = Program.formData.MatchExactInputData(row);

                // if exact match not works, use most reliable data
                if(success>0)
                    success = Program.formData.GetMostReliableValue();

            } // end DataGrid loop

            return 0;
        }
    }
}
