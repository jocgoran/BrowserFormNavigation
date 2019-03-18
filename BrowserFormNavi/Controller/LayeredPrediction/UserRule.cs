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
                HashSet<string> rulesSetIdAppliances = new HashSet<string>();
                Program.dBAccess.ColToHashSet("id", ref rulesSetIdAppliances);

                //loop over each RulesSet
                foreach (string rulesSetId in rulesSetIdAppliances)
                {
                    // get all the rules
                    // select the selected RulesSet
                    Program.dBAccess.GetDBData("UIComponentsOfRulesSetId", new object[] { rulesSetId });

                    // copy dataTable to array
                    string[] values = new string[3];
                    Program.dBAccess.ColsToStringArray(new string[] { "tag", "class", "role" }, ref values);

                    // loop over all the rows of data grid and apply the find the matching submit button
                    foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
                    {
                        
                        if (string.Equals(row.Cells["TagAttribute"].Value.ToString(), values[0], StringComparison.OrdinalIgnoreCase)
                            &&
                            string.Equals(row.Cells["ClassAttribute"].Value.ToString(), values[1], StringComparison.OrdinalIgnoreCase)
                            &&
                            string.Equals(row.Cells["RoleAttribute"].Value.ToString(), values[2], StringComparison.OrdinalIgnoreCase))
                        {
                            string MatchingBFNID = Program.formNavi.GetDataGridCell(row, "BFN_ID");
                            Program.formNavi.SetPropertyValue(Program.formNavi.BFN_IDInvoke, "SelectedItem", MatchingBFNID);
                        }
                    }

                }

            }

            return 0;
        }
    }
}
