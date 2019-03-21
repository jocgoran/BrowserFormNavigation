using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BrowserFormNavi.Controller
{
    public class ReadingDataGridForm
    {

        public int ExtractBrowserForm()
        {
            // reset the Browser loading var
            Program.browserData.FormExtracted = false;
            // clear DataGrid with form data 
            Program.formNavi.DataGridViewClear();
            // clear drop down menu of choosen form
            Program.formNavi.ComboBoxClear(Program.formNavi.BFN_IDInvoke);

            //set page title
            Program.browserView.SetFormText(Program.browserView.GetHtmlDocumentName());

            //copy URl To Form
            CopyUrlToForm();

            //update domainId
            UpdateDomain();

            // get the Browser document thread safe
            HtmlDocument htmlDocument = Program.browserView.GetHtmlDocument();

            // passing the document for elaboration
            Program.webMiner.DocumentMining(htmlDocument);

            // set the FormNavi fields
            //Program.formNavi.SetLastComboBoxItem(Program.formNavi.BFN_IDInvoke);
            Program.browserData.FormExtracted = true;

            return 0;
        }

        public int CopyUrlToForm()
        {
            //set page URL
            Program.formNavi.SetPropertyValue(Program.formNavi.navigationURL, "Text", Program.browserView.GetHtmlDocumentUrl());
            return 0;
        }

        public int UpdateDomain()
        {
            //set page URL
            Program.browserData.domain = new Uri(Program.browserView.GetHtmlDocumentUrl()).Host;
            return 0;
        }

        public int SaveBrowserValuesToDatabase()
        {
            string url = (string)Program.formNavi.GetPropertyValue(Program.formNavi.navigationURL, "Text");
            // get the domainId
            Program.dBAccess.GetDBData("Domain", new object[] { Program.browserData.domain });
            int domainId = 0;
            Program.dBAccess.ColToInt("id", ref domainId);

            // get the Browser document thread safe
            HtmlDocument htmlDocument = Program.browserView.GetHtmlDocument();

            // get over the whole doc
            HtmlElementCollection tagElements = htmlDocument.All;
            //foreach (HtmlElement tagElement in tagElements)
            Parallel.For(0, tagElements.Count, i =>
            {
                string BFN_ID = tagElements[i].GetAttribute("BFN_ID");

                // elaborate onyl Tags with BFN_ID
                if (string.IsNullOrEmpty(BFN_ID)) return;

                // extract the input values
                string tag = tagElements[i].TagName;
                string classAttribute = tagElements[i].GetAttribute("className");
                string dataTestId = tagElements[i].GetAttribute("data-testid");
                string ariaPressed = tagElements[i].GetAttribute("aria-pressed");
                string role = tagElements[i].GetAttribute("role");
                string type = tagElements[i].GetAttribute("type");
                string name = tagElements[i].GetAttribute("name");
                string inputFieldID = tagElements[i].GetAttribute("id");

                // insert IF NOT EXISTS description of User Interface Component
                //int error = Program.dBAccess.InsertInputFormData(url, domainId, tag, classAttribute, dataTestId, ariaPressed, role, type, name, inputFieldID);

                // get the FormPK of which to save parameters
                int UIComponentID = 0;
                Program.dBAccess.GetDBData("UIComponentPrimaryKey", new object[] { url, domainId, tag, classAttribute, dataTestId, ariaPressed, role, type, name, inputFieldID });
                Program.dBAccess.ColToInt("id", ref UIComponentID);

                string value = tagElements[i].GetAttribute("value");
                string sChecked = tagElements[i].GetAttribute("checked") == "checked" ? "checked" : "";
                //string AlgoInvoke = tagElement.GetAttribute("AlgoInvoke");

                if (tagElements[i].GetAttribute("type") != "hidden")
                {
                    //save value and checkbox
                    //Program.dBAccess.SaveHistorcalInputParam(UIComponentID, value, sChecked);
                }
            });

            return 0;
        }

    }
}
