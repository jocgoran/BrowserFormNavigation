using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller.LayeredPrediction
{
    public class UserRule
    {

        public int ApplySelectedRuleAppliance()
        {
            // loop over all the rows of data grid and apply the find the matching submit button
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
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
                        // all the rules and coditions have to return true
                        int fuzzyForConditions = 0;

                        // select the conditions
                        DataTable conditions = new DataTable();
                        Program.dBAccess.GetDBData("ConditionOfRuleId", new object[] { ruleRow["id"] }, ref conditions);

                        //loop over each condition
                        foreach (DataRow conditionRow in conditions.Rows)
                        {
                            // value that is correct
                            string tagName = conditionRow["tagName"].ToString();
                            string attributeName = conditionRow["attributeName"].ToString();
                            string attributeValue = conditionRow["attributeValue"].ToString();

                            // "tag", "class", "dataTestid", "ariaPressed", "role", "type", "name", "inputFieldID"
                            if (string.Equals(row.Cells["TagAttribute"].Value.ToString(), tagName, StringComparison.OrdinalIgnoreCase)
                                &&
                                string.Equals(row.Cells[attributeName].Value.ToString(), attributeValue, StringComparison.OrdinalIgnoreCase))
                            {

                                ++fuzzyForConditions;
                            }
                        } // loop over the conditions


                        // assign an action to the Rule
                        DataTable ruleAction = new DataTable();
                        Program.dBAccess.GetDBData("ActionOfRuleId", new object[] { ruleRow["id"] }, ref ruleAction);

                        // decide what to do for this action
                        switch (ruleAction.Rows[0]["id"])
                        {
                            // calculate the invoke
                            case 3:
                                {
                                    int newValue = fuzzyForConditions / conditions.Rows.Count;
                                    Program.formNavi.SetDataGridCell(row, "AlgoInvoke", newValue.ToString());
                                    break;
                                }
                        }

                    } // loop over a rule
                }// loop over appliance
            } // loop over a data Grid
        return 0;
        }
    }
}
