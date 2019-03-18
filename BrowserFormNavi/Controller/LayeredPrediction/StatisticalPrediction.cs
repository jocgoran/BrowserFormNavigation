using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller.LayeredPrediction
{
    public class StatisticalPrediction
    {

        public int MatchExactInputData(DataGridViewRow row)
        {
            string url = (string)Program.formNavi.GetPropertyValue(Program.formNavi.navigationURL, "Text");
            Program.dBAccess.GetDBData("Domain", new object[] { Program.browserData.domain });
            int domainId = 0;
            Program.dBAccess.ColToInt("id", ref domainId);
            string tag = Program.formNavi.GetDataGridCell(row, "TagAttribute");
            string classAttribute = Program.formNavi.GetDataGridCell(row, "ClassAttribute");
            string role = Program.formNavi.GetDataGridCell(row, "RoleAttribute");
            string type = Program.formNavi.GetDataGridCell(row, "TypeAttribute");
            string name = Program.formNavi.GetDataGridCell(row, "NameAttribute");
            string inputFieldID = Program.formNavi.GetDataGridCell(row, "IDAttribute");

            // search the exact match
            string[] values = new string[2];
            int success = 1;
            Program.dBAccess.GetDBData("ExactFormParamValue", new object[] { url, domainId, tag, classAttribute, role, type, name, inputFieldID });
            Program.dBAccess.ColsToStringArray(new string[] { "value", "checked" }, ref values);

            if (!string.IsNullOrEmpty(values[0]))
            {
                Program.formNavi.SetDataGridCell(row, "ValueAttribute", values[0]);
                success = 0;
            }
            if (!string.IsNullOrEmpty(values[1]))
            {
                Program.formNavi.SetDataGridCell(row, "CheckedAttribute", values[1]);
                success = 0;
            }

            return success;

        }

        public int CollaborativeCall()
        {

            return 0;
        }
    }
}
