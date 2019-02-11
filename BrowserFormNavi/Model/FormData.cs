using System.Windows.Forms;
using System;

namespace BrowserFormNavi.Model
{
    public class FormData
    {

        public int MatchExactInputData(DataGridViewRow row)
        {
            string url = Program.formNavi.comboBox1.Text;
            string domain = new Uri(Program.formNavi.comboBox1.Text).Host;
            string tag = row.Cells["Tag"].Value.ToString();
            string type = row.Cells["Type"].Value.ToString();
            string name = row.Cells["Name"].Value.ToString();
            string inputFieldID = row.Cells["ID"].Value.ToString();

            // search the exact match
            string value="", sChecked="";
            int success = 1;
            Program.dBAccess.RetriveExactFormParamValue(url, domain, tag, type, name, inputFieldID, ref value, ref sChecked);
            if (!string.IsNullOrEmpty(value))
            { 
                row.Cells["Value"].Value = value;
                success = 0;
            }
            if (!string.IsNullOrEmpty(sChecked))
            { 
                row.Cells["Checked"].Value = sChecked;
                success = 0;
            }

            return success;

        }

        public int GetMostReliableValue()
        {
            return 0;
        }

        public int SaveFormValues()
        {
            //   table Login | domain - login - password
            //table from | domain - tag - type - id - name - value
            //table  AutomatedValue | FormId - value - checked - Count - Error

            return 0;
        }
    }
}
