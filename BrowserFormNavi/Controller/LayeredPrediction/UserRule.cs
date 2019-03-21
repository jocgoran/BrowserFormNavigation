using System;
using System.Collections.Generic;
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
                Program.dBAccess.GetDBData("RuleOfAppliance", new object[] { checkedRuleAppliance });

                // put RulesSetID
                HashSet<string> ruleIds = new HashSet<string>();
                Program.dBAccess.ColToHashSet("id", ref ruleIds);

                //loop over each RulesSet
                foreach (string ruleId in ruleIds)
                {
                    // select the selected rules and its UIComponents
                    Program.dBAccess.GetDBData("ConditionOfRuleId", new object[] { ruleId });

                    // put rules into table array
                    string[] colNames = {"tagName","attributeName","attributeValue"};
                    string[,] conditionToEvaluete= new string[0,3];
                    Program.dBAccess.TableToStringArray(colNames, ref conditionToEvaluete);

                    // loop over all the rows of data grid and apply the find the matching submit button
                    foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
                    {
                        //count the rowNr of Rules
                        int totRowNr = conditionToEvaluete.Length / colNames.Length;

                        bool DataGridRow_MatchWithRules = false;
                        //loop over each RulesSet
                        for (int rowNr = 0; rowNr < totRowNr; rowNr++)
                        {
                            string tagName = conditionToEvaluete[rowNr, 0];
                            string attributeName = conditionToEvaluete[rowNr, 1];
                            string attributeValue = conditionToEvaluete[rowNr, 2];

                            // "tag", "class", "dataTestid", "ariaPressed", "role", "type", "name", "inputFieldID"
                            if (string.Equals(row.Cells["TagAttribute"].Value.ToString(), tagName, StringComparison.OrdinalIgnoreCase)
                                &&
                                string.Equals(row.Cells[attributeName].Value.ToString(), attributeValue, StringComparison.OrdinalIgnoreCase))
                            {

                                DataGridRow_MatchWithRules = true;
                            }
                            else
                            {
                                // if one rule is false, break the matching
                                DataGridRow_MatchWithRules = false;
                                break;
                            }
                        } // loop over the rules

                        if(DataGridRow_MatchWithRules)
                        { 
                            // finally evaluate the rule match and check which algo to increment
                            Program.dBAccess.GetDBData("ActionOfRuleId", new object[] { ruleId });
                            int actionId = 0;
                            Program.dBAccess.ColToInt("id", ref actionId);

                            switch (actionId)
                            {
                                // calculate the invoke
                                case 3:
                                    {
                                        string MatchingBFNID = Program.formNavi.GetDataGridCell(row, "BFN_ID");
                                        string AlgoInvoke = Program.formNavi.GetDataGridCell(row, "AlgoInvoke");
                                        int newValue = (Convert.ToInt32(AlgoInvoke) + 100) / 2;
                                        Program.formNavi.SetDataGridCell(row, "AlgoInvoke", newValue.ToString());
                                        break;
                                    }
                            }
                        } // end the correct match

                    } // loop over a data Grid
                } // loop over a rule set
            }// loop over appliance
        return 0;
        }
    }
}
