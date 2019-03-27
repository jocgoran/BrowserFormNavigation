using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    public class ReadingDataGridForm
    {
        public int ExtractBrowserForm()
        {
            // clear DataGrid with form data 
            Program.formNavi.DataGridViewClear();
            // clear drop down menu of choosen form
            Program.formNavi.ComboBoxClear(Program.formNavi.BFN_IDInvoke);

            //set page title
            string BrowserTitel= (string)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "DocumentTitle");
            Program.browserView.SetPropertyValue(Program.browserView, "Text", BrowserTitel);

            //copy URl To Form
            CopyUrlToForm();

            //update domainId
            UpdateDomain();

            // passing the document for elaboration
            Program.webMiner.DocumentMining();

            return 0;
        }

        public int CopyUrlToForm()
        {
            //set page URL
            Uri url = (Uri)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "Url");
            Program.formNavi.SetPropertyValue(Program.formNavi.navigationURL, "Text", url.ToString());
            return 0;
        }

        public int UpdateDomain()
        {
            //set page URL
            Uri url = (Uri)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "Url");
            Program.browserData.domain = new Uri(url.ToString()).Host;
            return 0;
        }

        public int SaveBrowserValuesToDatabase()
        {
            string url = (string)Program.formNavi.GetPropertyValue(Program.formNavi.navigationURL, "Text");
            // get the domainId
            DataTable domain = new DataTable();
            Program.dBAccess.GetDBData("Domain", new object[] { Program.browserData.domain }, ref domain);

            // get the Browser document thread safe
            HtmlDocument htmlDocument = (HtmlDocument)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "Document");

            // get over the whole doc
            HtmlElementCollection tagElements = htmlDocument.All;

            // loop over all the rows of data grid
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                // Get the index of DOM element
                int indexOfTagElement = Convert.ToInt32(Program.formNavi.GetDataGridCell(row, "BFN_ID"));

                // extract the input values
                string tag = tagElements[indexOfTagElement].TagName;
                string classAttribute = tagElements[indexOfTagElement].GetAttribute("className");
                string dataTestId = tagElements[indexOfTagElement].GetAttribute("data-testid");
                string ariaPressed = tagElements[indexOfTagElement].GetAttribute("aria-pressed");
                string role = tagElements[indexOfTagElement].GetAttribute("role");
                string type = tagElements[indexOfTagElement].GetAttribute("type");
                string name = tagElements[indexOfTagElement].GetAttribute("name");
                string inputFieldID = tagElements[indexOfTagElement].GetAttribute("id");

                // insert IF NOT EXISTS description of User Interface Component
                int error = Program.dBAccess.InsertDBData("InsertInputFormData", new object[] { url, domain.Rows[0]["id"], tag, classAttribute, dataTestId, ariaPressed, role, type, name, inputFieldID });

                // get the FormPK of which to save parameters
                DataTable UIComponentPrimaryKey = new DataTable();
                Program.dBAccess.GetDBData("UIComponentPrimaryKey", new object[] { url, domain.Rows[0]["id"], tag, classAttribute, dataTestId, ariaPressed, role, type, name, inputFieldID },ref UIComponentPrimaryKey);

                string value = tagElements[indexOfTagElement].GetAttribute("value");
                string sChecked = tagElements[indexOfTagElement].GetAttribute("checked") == "checked" ? "checked" : "";
                //string AlgoInvoke = tagElement.GetAttribute("AlgoInvoke");

                if (tagElements[indexOfTagElement].GetAttribute("type") != "hidden")
                {
                    //save value and checkbox
                    Program.dBAccess.UpdateDBData("SaveHistorcalInputParam", new object[] { UIComponentPrimaryKey.Rows[0]["id"], value, sChecked });
                }

                // dispose the DataTable
                UIComponentPrimaryKey.Dispose();
            }

            // dispose the DataTable
            domain.Dispose();

            return 0;
        }

    }
}
