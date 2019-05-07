using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BrowserFormNavi.Model
{
    public class PredictedData
    {
        // conditions
        public Dictionary<string, List<double>> conditionsResults;

        // actions
        public Dictionary<string, List<double>> ruleActionInvokeResults;
        public Dictionary<string, List<double>> ruleActionRefresh;
        public Dictionary<string, List<double>> ruleActionStop;

        // form filler
        //value venctor?
        //checkbox

        public PredictedData()
        {

            //create the new dictionaries
            conditionsResults = new Dictionary<string, List<double>>();
            ruleActionInvokeResults = new Dictionary<string, List<double>>();
            ruleActionRefresh = new Dictionary<string, List<double>>();
            ruleActionStop = new Dictionary<string, List<double>>();

            // loop over all the rows of data grid
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                string BFN_ID = row.Cells["BFN_ID"].Value.ToString();

                // initialize the data prediction holder
                conditionsResults.Add(BFN_ID, new List<double>());
                ruleActionInvokeResults.Add(BFN_ID, new List<double>());
                ruleActionRefresh.Add(BFN_ID, new List<double>());
                ruleActionStop.Add(BFN_ID, new List<double>());
            }
        }

        public int AddFuzzyConditionResultToActionInvokeResults()
        {
            // loop over all the rows of data grid
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                string BFN_ID = row.Cells["BFN_ID"].Value.ToString();
                double predicted = FuzzyConditionsResult(BFN_ID);
                ruleActionInvokeResults[BFN_ID].Add(predicted);
            }
            return 0;
        }


        public int AddFuzzyConditionResultToActionRefreshResults()
        {
            // loop over all the rows of data grid
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                string BFN_ID = row.Cells["BFN_ID"].Value.ToString();
                double predicted = FuzzyConditionsResult(BFN_ID);
                ruleActionRefresh[BFN_ID].Add(predicted);
            }
            return 0;
        }
        
        public int AddFuzzyConditionResultToActionStopResults()
        {
            // loop over all the rows of data grid
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                string BFN_ID = row.Cells["BFN_ID"].Value.ToString();
                double predicted = FuzzyConditionsResult(BFN_ID);
                ruleActionStop[BFN_ID].Add(predicted);
            }
            return 0;
        }

        public int ConsolidateAllFuzzyOfRulesAction()
        {
            // loop over all the rows of data grid
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                string BFN_ID = row.Cells["BFN_ID"].Value.ToString();
                double predicted;
                
                // 
                predicted=ruleActionInvokeResults[BFN_ID].Sum()/ruleActionInvokeResults[BFN_ID].Count;
                ruleActionInvokeResults[BFN_ID].Clear();
                ruleActionInvokeResults[BFN_ID].Add(predicted);

                predicted = ruleActionRefresh[BFN_ID].Sum() / ruleActionRefresh[BFN_ID].Count;
                ruleActionRefresh[BFN_ID].Clear();
                ruleActionRefresh[BFN_ID].Add(predicted);

                predicted = ruleActionStop[BFN_ID].Sum() / ruleActionStop[BFN_ID].Count;
                ruleActionStop[BFN_ID].Clear();
                ruleActionStop[BFN_ID].Add(predicted);
            }

            return 0;
        }


        private double FuzzyConditionsResult(string BFN_ID)
        {
            List<double> conditionsResult = conditionsResults[BFN_ID];

            // calculate the fuzzy of each line
            double sum = conditionsResult.Sum();
            double prediction = sum / conditionsResult.Count;

            // clear the calculated result for the next run
            conditionsResults[BFN_ID].Clear();

            return prediction;
        }


        

    }
}
