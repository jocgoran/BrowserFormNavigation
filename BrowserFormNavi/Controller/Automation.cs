using BrowserFormNavi.Model;
using System;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    public class Automation
    {
        public int AutoFillInputValue()
        {
            Program.predictedData = new PredictedData();

            //call the user Rule algorithm
            Program.userRule.ApplySelectedRuleAppliance();
            DispatchAllRulesResults();

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
            Program.dataGrid.CopyDataToInvokeComboBox();
            return 0;
        }

        public int DispatchAllRulesResults()
        {
            double refreshable=0;
            double stoppable=0;

            // loop over all the rows of data grid
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {

                string BFN_ID = row.Cells["BFN_ID"].Value.ToString();

                // add results to each line 
                double invocable = Program.predictedData.ruleActionInvokeResults[BFN_ID][0];
                Program.formNavi.SetDataGridCell(row, "AlgoInvoke", invocable.ToString());

                // sum the table values
                refreshable = refreshable + Program.predictedData.ruleActionRefresh[BFN_ID][0];
                stoppable = stoppable + Program.predictedData.ruleActionStop[BFN_ID][0];
            }

            //write result to FormNavi field
            refreshable = refreshable/ Program.formNavi.dataGridView1.RowCount;
            Program.formNavi.SetPropertyValue(Program.formNavi.refreshable, "Text", String.Format("{0:0.00}", refreshable));

            stoppable = stoppable / Program.formNavi.dataGridView1.RowCount;
            Program.formNavi.SetPropertyValue(Program.formNavi.stoppable, "Text", stoppable.ToString());

            //clear the dictionaries
            Program.predictedData.ruleActionInvokeResults.Clear();
            Program.predictedData.ruleActionRefresh.Clear();
            Program.predictedData.ruleActionStop.Clear();

            return 0;
        }
    }
}
