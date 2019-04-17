using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller.LayeredPrediction
{
    public class UserRule
    {

        public int ApplySelectedRuleAppliance()
        {

            // get all checked RuleAppliances
            CheckedListBox.CheckedItemCollection checkedRuleAppliances = (CheckedListBox.CheckedItemCollection)Program.formNavi.GetPropertyValue(Program.formNavi.ruleAppliance, "CheckedItems");
            foreach (string checkedRuleAppliance in checkedRuleAppliances)
            {

                // select the selected RulesSet
                DataTable rules = new DataTable();
                Program.dBAccess.GetDBData("RuleOfAppliance", new object[] { checkedRuleAppliance }, ref rules);

                //loop over each RulesSet
                foreach (DataRow ruleRow in rules.Rows)
                {
                    // select the conditions
                    DataTable conditions = new DataTable();
                    Program.dBAccess.GetDBData("ConditionOfRuleId", new object[] { ruleRow["id"] }, ref conditions);

                    //loop over each condition
                    foreach (DataRow conditionRow in conditions.Rows)
                    {
                        // check each condition on all data grid rows
                        CheckCondition(conditionRow);
                    } // loop over the conditions

                    // add fuzzy result to a specific set
                    switch (ruleRow["ruleAction_id"])
                    {
                        // setValue
                        case 1:
                        {
                            break;
                        }
                        // setChecked
                        case 2:
                        {
                            break;
                        }
                        // invoke
                        case 3:
                        {
                            // add result to the defined action
                            Program.predictedData.AddFuzzyConditionResultToActionInvokeResults();
                            break;
                        }
                        // refresh
                        case 4:
                        {
                            // add result to the defined action
                            Program.predictedData.AddFuzzyConditionResultToActionRefreshResults();
                            break;
                        }
                        // stop
                        case 5:
                        {
                            // add result to the defined action
                            Program.predictedData.AddFuzzyConditionResultToActionStopResults();
                            break;
                        }

                    } // end switch

                    // add caluculated values to the GUI for special condition
                    foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
                    {
                        string BFN_ID = row.Cells["BFN_ID"].Value.ToString();
                        double predicted;
                        // invoke
                        predicted = Program.predictedData.ruleActionInvokeResults[BFN_ID].Sum() / Program.predictedData.ruleActionInvokeResults[BFN_ID].Count;
                        Program.formNavi.SetDataGridCell(row, "AlgoInvoke", predicted.ToString());

                        //// refresh
                        //predicted = Program.predictedData.ruleActionRefresh[BFN_ID].Sum() / Program.predictedData.ruleActionRefresh[BFN_ID].Count;

                        //// Stop
                        //predicted = Program.predictedData.ruleActionStop[BFN_ID].Sum() / Program.predictedData.ruleActionStop[BFN_ID].Count;

                        // value
                        // checkbox
                    }

                } // loop over a rule

            }// loop over appliance

            // consolidate all fuzzy of all Appliances's rules
            Program.predictedData.ConsolidateAllFuzzyOfRulesAction();

            return 0;
        }

        public int CheckCondition(DataRow conditionRow)
        {
            // value that we have to match
            string attributeName = conditionRow["attributeName"].ToString();
            string conditionValue = conditionRow["attributeValue"].ToString();

            // compare DataGrid value and condition with correct operator
            switch (conditionRow["operator"])
            {
                // setValue
                case "is":
                {
                    // loop over all the rows of data grid
                    foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
                    {
                        string dataGridValue = row.Cells[attributeName].Value.ToString();
                        string BFN_ID = row.Cells["BFN_ID"].Value.ToString();

                        // check if match the condition
                        if (string.Equals(dataGridValue, conditionValue, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            // if true: add 1 to listArray
                            Program.predictedData.conditionsResults[BFN_ID].Add(1);
                        }
                        else
                        {
                            // IF different: add 0 to listArray
                            Program.predictedData.conditionsResults[BFN_ID].Add(0);
                        }
                    } // loop over a DataGrid
                    break;
                }
                case "is not":
                {
                    // loop over all the rows of data grid
                    foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
                    {
                        string dataGridValue = row.Cells[attributeName].Value.ToString();
                        string BFN_ID = row.Cells["BFN_ID"].Value.ToString();

                        // check if match the condition
                        if (string.Equals(dataGridValue, conditionValue, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            // if true: add 0 to listArray
                            Program.predictedData.conditionsResults[BFN_ID].Add(0);
                        }
                        else
                        {
                            // IF different: add 1 to listArray
                            Program.predictedData.conditionsResults[BFN_ID].Add(1);
                        }
                    } // loop over a DataGrid
                    break;
                }
                case "have all":
                {
                    List<int> conditionMatch = new List<int>();

                    // loop over all the rows of data grid
                    foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
                    {
                        string dataGridValue = row.Cells[attributeName].Value.ToString();

                        // check if match the condition
                        if (string.Equals(dataGridValue, conditionValue, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            // IF equal: match is true
                            conditionMatch.Add(1);

                        }
                        else
                        {
                            // IF one is different: match is false
                            conditionMatch.Add(0);
                        }
                    }

                    // fuzzy of "ALL" conditional match
                    double predicted=(double)conditionMatch.Sum()/conditionMatch.Count;

                    // if no one is different: add 1 to each row's listArray
                    foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
                    {
                         Program.predictedData.conditionsResults[row.Cells["BFN_ID"].Value.ToString()].Add(predicted);
                    }
                    break;
                } // end case

                case "have no one":
                {
                    List<int> conditionMatch = new List<int>();

                    // loop over all the rows of data grid
                    foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
                    {
                        string dataGridValue = row.Cells[attributeName].Value.ToString();

                        // check if perhaps one match the condition
                        if (string.Equals(dataGridValue, conditionValue, StringComparison.OrdinalIgnoreCase)==true)
                        {
                            // IF one match: condition is wrong
                            conditionMatch.Add(0);
                        }
                        else
                        {
                            // IF NO match: condition is true
                            conditionMatch.Add(1);
                        }
                    }

                    // fuzzy of "ALL" conditional match
                    double predicted = (double)conditionMatch.Sum() / conditionMatch.Count;

                    // add result to each row
                    foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
                    {
                        Program.predictedData.conditionsResults[row.Cells["BFN_ID"].Value.ToString()].Add(predicted);
                    }
                    break;
                } // end case

                case "was once":
                {

                    // loop over all the rows of data grid and apply the find the matching submit button
                    foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
                    {
                        string dataGridValue = row.Cells[attributeName].Value.ToString();
                        string BFN_ID = row.Cells["BFN_ID"].Value.ToString();
                        bool conditionMatch = false;

                        // get HistoricData ot AttributeName
                        DataTable historicData = new DataTable();
                        Program.dBAccess.GetDBData("HistoricDataOfAttributeName", new object[] { dataGridValue }, ref historicData);

                        //loop over each historicData
                        foreach (DataRow historicDataRow in historicData.Rows)
                        {
                            // check the match of condition match     
                            string invoked = historicDataRow[conditionValue].ToString();

                            // check if once
                            if (string.Equals(invoked, "1", StringComparison.OrdinalIgnoreCase) == true)
                            {
                                Program.predictedData.conditionsResults[BFN_ID].Add(1);
                                conditionMatch = true;
                                break;
                            }
                        }

                        // really never
                        if (conditionMatch==false)
                            Program.predictedData.conditionsResults[BFN_ID].Add(0);

                        }// loop over a DataGrid

                    break;
                }//end case

                case "was never":
                {

                    // loop over all the rows of data grid and apply the find the matching submit button
                    foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
                    {
                        string dataGridValue = row.Cells[attributeName].Value.ToString();
                        string BFN_ID = row.Cells["BFN_ID"].Value.ToString();
                        bool conditionMatch = true;

                        // get HistoricData ot AttributeName
                        DataTable historicData = new DataTable();
                        Program.dBAccess.GetDBData("HistoricDataOfAttributeName", new object[] { dataGridValue }, ref historicData);

                        //loop over each historicData
                        foreach (DataRow historicDataRow in historicData.Rows)
                        {
                            // check the match of condition match     
                            string invoked = historicDataRow[conditionValue].ToString();

                            // check if once
                            if (string.Equals(invoked, "1", StringComparison.OrdinalIgnoreCase) == true)
                            {
                                Program.predictedData.conditionsResults[BFN_ID].Add(0);
                                conditionMatch = false;
                                break;
                            }
                        }

                        // really never
                        if(conditionMatch)
                            Program.predictedData.conditionsResults[BFN_ID].Add(1);

                    }// loop over a DataGrid

                    break;
                }//end case
            } //endswitch
        return 0;
        } // end of CheckCondition

    }
}
