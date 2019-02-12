using System.Windows.Forms;
using System;

namespace BrowserFormNavi.Model
{
    public class FormData
    {

        public int MatchExactInputData(DataGridViewRow row)
        {
            // string url = Program.formNavi.comboBox1.Text;
            string url = Program.formNavi.GetComboBoxSelectedItem(Program.formNavi.comboBox1);
            string domain = new Uri(url).Host;
            string tag = Program.formNavi.GetDataGridCell(row, "TagAttribute");
            string type = Program.formNavi.GetDataGridCell(row, "TypeAttribute");
            string name = Program.formNavi.GetDataGridCell(row, "NameAttribute");
            string inputFieldID = Program.formNavi.GetDataGridCell(row, "IDAttribute");

            // search the exact match
            string value="", sChecked="";
            int success = 1;
            Program.dBAccess.RetriveExactFormParamValue(url, domain, tag, type, name, inputFieldID, ref value, ref sChecked);
            if (!string.IsNullOrEmpty(value))
            {
                Program.formNavi.SetDataGridCell(row, "ValueAttribute", value);
                success = 0;
            }
            if (!string.IsNullOrEmpty(sChecked))
            { 
                Program.formNavi.SetDataGridCell(row, "CheckedAttribute", value);
                success = 0;
            }

            return success;

        }

        public int GetMostReliableValue()
        {
            return 0;
        }
    }
}
