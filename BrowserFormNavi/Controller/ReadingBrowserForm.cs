using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace BrowserFormNavi.Controller
{
    public class ReadingBrowserForm
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
            Program.formNavi.SetLastComboBoxItem(Program.formNavi.BFN_IDInvoke);
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

            // get over all input
            HtmlElementCollection inputCollection = htmlDocument.GetElementsByTagName("input");

            foreach (HtmlElement input in inputCollection)
            {
                // skip if there is not BNF_ID
                if (string.IsNullOrEmpty(input.GetAttribute("BFN_ID"))) continue;

                // extract the input values
                string tag = "input";
                string classAttribute = input.GetAttribute("className");
                string role = input.GetAttribute("role");
                string type = input.GetAttribute("type");
                string name = input.GetAttribute("name");
                string inputFieldID = input.GetAttribute("id");
                string value = input.GetAttribute("value");
                string sChecked = input.GetAttribute("checked") == "checked" ? "checked" : "";

                // insert IF NOT EXISTS description of input data
                int error = Program.dBAccess.InsertInputFormData(url, domainId, tag, classAttribute, role, type, name, inputFieldID);

                // get the FormPK of which to save parameters
                int UIComponentID = 0;
                Program.dBAccess.GetDBData("UIComponentPrimaryKey", new object[] { url, domainId, tag, classAttribute, role, type, name, inputFieldID });
                Program.dBAccess.ColToInt("id", ref UIComponentID);

                if (input.GetAttribute("type") != "hidden")
                {
                    //save value and checkbox
                    Program.dBAccess.SaveHistorcalInputParam(UIComponentID, value, sChecked);
                }
            }

            // get over all div
            HtmlElementCollection divCollection = htmlDocument.GetElementsByTagName("div");

            foreach (HtmlElement div in divCollection)
            {
                // skip if there is not BNF_ID
                if (string.IsNullOrEmpty(div.GetAttribute("BFN_ID"))) continue;

                // extract the input values
                string tag = "div";
                string classAttribute = div.GetAttribute("className");
                string role = div.GetAttribute("role");
                string type = div.GetAttribute("type");
                string name = div.GetAttribute("name");
                string inputFieldID = div.GetAttribute("id");
                string value = div.GetAttribute("value");
                string sChecked = div.GetAttribute("checked") == "checked" ? "checked" : "";

                // insert IF NOT EXISTS description of input data
                int error = Program.dBAccess.InsertInputFormData(url, domainId, tag, classAttribute, role, type, name, inputFieldID);

                // get the FormPK of which to save parameters
                int UIComponentID = 0;
                Program.dBAccess.GetDBData("UIComponentPrimaryKey", new object[] { url, domainId, tag, classAttribute, role, type, name, inputFieldID });
                Program.dBAccess.ColToInt("id", ref UIComponentID);

                //save value and checkbox
                Program.dBAccess.SaveHistorcalInputParam(UIComponentID, value, sChecked);
            }

            return 0;
        }

    }
}
