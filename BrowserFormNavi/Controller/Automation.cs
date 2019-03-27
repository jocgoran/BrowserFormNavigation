using System;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    public class Automation
    {
        public int AutoFillInputValue()
        {
            //call the user Rule algorithm
            Program.userRule.ApplySelectedRuleAppliance();

            // loop over all the rows of data grid
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                // add input and try to retrieve exact match
                Program.statisticalPrediction.MatchExactInputData(row);

                // if exact match not works, use most reliable data
                //if(success>0)
                //    success = Program.formData.GetMostReliableValue();

            } // end DataGrid loop


            // at the end, write data to invoke
            Program.writingBrowserForm.CopyDataToInvokeComboBox();
            return 0;
        }

    }
}
