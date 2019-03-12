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
            string url = (string)Program.formNavi.GetPropertyValue(Program.formNavi.comboBox1, "Text");
            Program.dBAccess.LoadDomain(Program.browserData.domain);
            int domainId = 0;
            Program.dBAccess.ColToInt("id", ref domainId);
            string tag = Program.formNavi.GetDataGridCell(row, "TagAttribute");
            string classAttribute = Program.formNavi.GetDataGridCell(row, "ClassAttribute");
            string role = Program.formNavi.GetDataGridCell(row, "RoleAttribute");
            string type = Program.formNavi.GetDataGridCell(row, "TypeAttribute");
            string name = Program.formNavi.GetDataGridCell(row, "NameAttribute");
            string inputFieldID = Program.formNavi.GetDataGridCell(row, "IDAttribute");

            // search the exact match
            string value = "", sChecked = "";
            int success = 1;
            Program.dBAccess.RetriveExactFormParamValue(url, domainId, tag, classAttribute, role, type, name, inputFieldID);
            Program.dBAccess.ColToString("value", ref value, "checked", ref sChecked);

            if (!string.IsNullOrEmpty(value))
            {
                Program.formNavi.SetDataGridCell(row, "ValueAttribute", value);
                success = 0;
            }
            if (!string.IsNullOrEmpty(sChecked))
            {
                Program.formNavi.SetDataGridCell(row, "CheckedAttribute", sChecked);
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
