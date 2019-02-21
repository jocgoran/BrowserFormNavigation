using System;
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
            Program.formNavi.ComboBoxClear(Program.formNavi.comboBox2);

            //set page title
            Program.browserView.SetFormText(Program.browserView.GetHtmlDocumentName());

            //copy URl To Form
            CopyUrlToForm();

            // get the Browser document thread safe
            HtmlDocument htmlDocument = Program.browserView.GetHtmlDocument();

            // looop over all tags 
            if (htmlDocument != null)
            {
                // set the tagId
                int tagId = 0;

                foreach (HtmlElement tagElement in htmlDocument.All)
                {
                    //get the TagName
                    string tagName = tagElement.TagName;
                    
                    //skip some not handlable tags 
                    bool skipExtraction = true;
                    if (string.Equals(tagName, "input", StringComparison.OrdinalIgnoreCase)
                        || string.Equals(tagName, "button", StringComparison.OrdinalIgnoreCase)
                        || string.Equals(tagName, "div", StringComparison.OrdinalIgnoreCase)
                        || string.Equals(tagName, "a", StringComparison.OrdinalIgnoreCase))
                        skipExtraction = false;

                    if (skipExtraction) continue;

                    string typeAttribute = tagElement.GetAttribute("type");
                    string roleAttribute = tagElement.GetAttribute("role");

                    bool extractFromBrowserToForm = false;
                    bool addInvokeToComboBox = false;

                    // decide what should be exported?
                    if (string.Equals(tagName, "input", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(typeAttribute, "hidden", StringComparison.OrdinalIgnoreCase))
                        extractFromBrowserToForm = true;

                    if (string.Equals(tagName, "button", StringComparison.OrdinalIgnoreCase)
                        && string.Equals(typeAttribute, "submit", StringComparison.OrdinalIgnoreCase))
                        extractFromBrowserToForm = true;

                    if (string.Equals(tagName, "div", StringComparison.OrdinalIgnoreCase)
                        && string.Equals(roleAttribute, "button", StringComparison.OrdinalIgnoreCase))
                        extractFromBrowserToForm = true;

                    if (string.Equals(tagName, "a", StringComparison.OrdinalIgnoreCase)
                        && string.Equals(roleAttribute, "button", StringComparison.OrdinalIgnoreCase))
                        extractFromBrowserToForm = true;

                    // decide if element can be invoked
                    if (string.Equals(tagName, "input", StringComparison.OrdinalIgnoreCase) 
                        && string.Equals(typeAttribute, "submit", StringComparison.OrdinalIgnoreCase))
                        addInvokeToComboBox = true;

                    if (string.Equals(tagName, "input", StringComparison.OrdinalIgnoreCase) 
                        && string.Equals(typeAttribute, "image", StringComparison.OrdinalIgnoreCase))
                        addInvokeToComboBox = true;

                    if (string.Equals(tagName, "button", StringComparison.OrdinalIgnoreCase)
                        && string.Equals(typeAttribute, "submit", StringComparison.OrdinalIgnoreCase))
                        addInvokeToComboBox = true;

                    if (string.Equals(tagName, "div", StringComparison.OrdinalIgnoreCase)
                        && string.Equals(roleAttribute, "button", StringComparison.OrdinalIgnoreCase))
                        addInvokeToComboBox = true;

                    if (string.Equals(tagName, "a", StringComparison.OrdinalIgnoreCase)
                        && string.Equals(roleAttribute, "button", StringComparison.OrdinalIgnoreCase))
                        addInvokeToComboBox = true;

                    if (extractFromBrowserToForm == false) continue;

                    // copy browser form data to Form
                    Program.formNavi.AddRowToDataGrid(new object[] {++tagId,
                                                                tagName,
                                                                tagElement.GetAttribute("className"),
                                                                tagElement.GetAttribute("data-testid"),
                                                                tagElement.GetAttribute("aria-pressed"),
                                                                tagElement.GetAttribute("role"),
                                                                tagElement.GetAttribute("type"),
                                                                tagElement.GetAttribute("name"),
                                                                tagElement.GetAttribute("id"),
                                                                tagElement.GetAttribute("value"),
                                                                tagElement.GetAttribute("checked")=="False"?"":"checked" });

                    // set the BrowserFormNavi specific ID of the tag
                    tagElement.SetAttribute("BFN_ID", tagId.ToString());

                    // add the ID of submit input
                    if (addInvokeToComboBox)
                        Program.formNavi.AddItemToComboBox(Program.formNavi.comboBox2, tagId);
                }
            
            }

            Program.formNavi.SetLastComboBoxItem(Program.formNavi.comboBox2);
            Program.browserData.FormExtracted = true;

            return 0;
        }

        public int CopyUrlToForm()
        {
            //set page URL
            Program.formNavi.SetComboBoxText(Program.formNavi.comboBox1, Program.browserView.GetHtmlDocumentUrl());
            return 0;
        }

        public int SaveBrowserValuesToDatabase()
        {
            string url = Program.formNavi.GetComboBoxText(Program.formNavi.comboBox1);
            string domain = new Uri(url).Host;

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
                int error = Program.dBAccess.InsertInputFormData(url, domain, tag, classAttribute, role, type, name, inputFieldID);

                // get the FormPK of which to save parameters
                int FormPK = 0;
                Program.dBAccess.GetInputPrimaryKey(url, domain, tag, classAttribute, role, type, name, inputFieldID, ref FormPK);
 
                if(input.GetAttribute("type") != "hidden")
                {
                    //save value and checkbox
                    Program.dBAccess.SaveHistorcalInputParam(FormPK, value, sChecked);
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
                int error = Program.dBAccess.InsertInputFormData(url, domain, tag, classAttribute, role, type, name, inputFieldID);

                // get the FormPK of which to save parameters
                int FormPK = 0;
                Program.dBAccess.GetInputPrimaryKey(url, domain, tag, classAttribute, role, type, name, inputFieldID, ref FormPK);

                //save value and checkbox
                Program.dBAccess.SaveHistorcalInputParam(FormPK, value, sChecked);
            }

            return 0;
        }

    }
}
