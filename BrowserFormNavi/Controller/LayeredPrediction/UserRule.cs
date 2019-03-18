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
                Program.dBAccess.GetDBData("RulesSetOfAppliance", new object[] { checkedRuleAppliance });

                // put RulesSetID
                HashSet<string> rulesSetIds = new HashSet<string>();
                Program.dBAccess.ColToHashSet("id", ref rulesSetIds);

                //loop over each RulesSet
                foreach (string rulesSetId in rulesSetIds)
                {
                    // select the selected rules and its UIComponents
                    Program.dBAccess.GetDBData("RulesOfRulesSetId", new object[] { rulesSetId });

                    // put RulesSetID
                    HashSet<string> ruleIds = new HashSet<string>();
                    Program.dBAccess.ColToHashSet("rule_id", ref ruleIds);

                    //loop over each RulesSet
                    foreach (string ruleId in ruleIds)
                    {
                        // select the selected rules and its UIComponents
                        Program.dBAccess.GetDBData("UIComponentsOfRuleId", new object[] { ruleId });

                        // copy dataTable to array
                        string[] values = new string[8];
                        Program.dBAccess.ColsToStringArray(new string[] { "tag", "class", "dataTestid", "ariaPressed", "role", "type", "name", "inputFieldID"}, ref values);

                        // loop over all the rows of data grid and apply the find the matching submit button
                        foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
                        {

                            if (string.Equals(row.Cells["TagAttribute"].Value.ToString(), values[0], StringComparison.OrdinalIgnoreCase)
                                &&
                                string.Equals(row.Cells["ClassAttribute"].Value.ToString(), values[1], StringComparison.OrdinalIgnoreCase)
                                &&
                                string.Equals(row.Cells["DataTestIdAttribute"].Value.ToString(), values[2], StringComparison.OrdinalIgnoreCase)
                                &&
                                string.Equals(row.Cells["AriaPressed"].Value.ToString(), values[3], StringComparison.OrdinalIgnoreCase)
                                &&
                                string.Equals(row.Cells["RoleAttribute"].Value.ToString(), values[4], StringComparison.OrdinalIgnoreCase)
                                &&
                                string.Equals(row.Cells["TypeAttribute"].Value.ToString(), values[5], StringComparison.OrdinalIgnoreCase)
                                &&
                                string.Equals(row.Cells["NameAttribute"].Value.ToString(), values[6], StringComparison.OrdinalIgnoreCase)
                                &&
                                string.Equals(row.Cells["IDAttribute"].Value.ToString(), values[7], StringComparison.OrdinalIgnoreCase))
                            {
                                // the rule match and check which algo to increment
                                Program.dBAccess.GetDBData("ActionOfRuleSetId", new object[] { rulesSetId });
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
                            }
                        }
                    }

                }

            }

            return 0;
        }
    }
}
