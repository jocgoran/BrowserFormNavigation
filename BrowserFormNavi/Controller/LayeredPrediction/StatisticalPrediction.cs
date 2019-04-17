using System;
using System.Collections.Generic;
using System.Data;
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
            DataTable domain = new DataTable();
            Program.dBAccess.GetDBData("Domain", new object[] { Program.browserData.domain }, ref domain);
            string tag = Program.formNavi.GetDataGridCell(row, "TagAttribute");
            string classAttribute = Program.formNavi.GetDataGridCell(row, "ClassAttribute");
            string dataTestId = Program.formNavi.GetDataGridCell(row, "dataTestidAttribute");
            string ariaPressed = Program.formNavi.GetDataGridCell(row, "ariaPressedAttribute");
            string dataInterestId = Program.formNavi.GetDataGridCell(row, "DataInterestIdAttribute");
            string role = Program.formNavi.GetDataGridCell(row, "RoleAttribute");
            string type = Program.formNavi.GetDataGridCell(row, "TypeAttribute");
            string name = Program.formNavi.GetDataGridCell(row, "NameAttribute");
            string inputFieldID = Program.formNavi.GetDataGridCell(row, "IDAttribute");

            // search the exact match
            DataTable exactFormParamValues = new DataTable();
            Program.dBAccess.GetDBData("ExactFormParamValue", new object[] { url, domain.Rows[0]["id"], tag, classAttribute, dataTestId, ariaPressed, dataInterestId, role, type, name, inputFieldID }, ref exactFormParamValues);

            foreach (DataRow exactFormParamValue in exactFormParamValues.Rows)
            {
                if (!string.IsNullOrEmpty(exactFormParamValue["value"].ToString()))
                {
                    Program.formNavi.SetDataGridCell(row, "ValueAttribute", exactFormParamValue["value"].ToString());
                }
                if (!string.IsNullOrEmpty(exactFormParamValue["checked"].ToString()))
                {
                    Program.formNavi.SetDataGridCell(row, "CheckedAttribute", exactFormParamValue["checked"].ToString());
                }
                if (exactFormParamValue["invoked"].Equals(1))
                {
                    Program.formNavi.SetDataGridCell(row, "AlgoInvoke", "1");
                }

            }

            // dispose the DataTable
            domain.Dispose();
            exactFormParamValues.Dispose();

            return 0;

        }

        public int CollaborativeCall()
        {

            return 0;
        }
    }
}
