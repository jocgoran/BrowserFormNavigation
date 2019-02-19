using System;
using System.Windows.Forms;

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

            // set the tagId
            int tagId = 0;

            // extract the Form tag       
            if (htmlDocument != null)
            {
                HtmlElementCollection forms = htmlDocument.GetElementsByTagName("form");
                // call the loop overthe forms
                LoopOverAllForms(forms, ref tagId);
            }

            // extract the div tag       
            if (htmlDocument != null)
            {
                HtmlElementCollection divs = htmlDocument.GetElementsByTagName("div");
                // call the loop overthe forms
                LoopOverAllDivs(divs, ref tagId);
            }

            Program.formNavi.SetLastComboBoxItem(Program.formNavi.comboBox2);
            Program.browserData.FormExtracted = true;

            return 0;
        }

        public int LoopOverAllForms(HtmlElementCollection forms, ref int tagId)
        {
            int formNr = 0;
            foreach (HtmlElement form in forms)
            {
                // copy browser form data to Form
                Program.formNavi.AddRowToDataGrid(new object[] {++tagId,
                                                                ++formNr,
                                                                "form",
                                                                "",
                                                                form.GetAttribute("action"),
                                                                "",
                                                                form.GetAttribute("type"),
                                                                form.GetAttribute("name"),
                                                                form.GetAttribute("id"),
                                                                form.GetAttribute("value") });

                // set the BrowserFormNavi specific ID of the tag
                form.SetAttribute("BFN_ID", tagId.ToString());

                // call the loop over the inputs
                HtmlElementCollection inputs = form.GetElementsByTagName("input");
                foreach (HtmlElement input in inputs)
                {
                    // copy browser form data to Form
                    Program.formNavi.AddRowToDataGrid(new object[] {++tagId,
                                                                    formNr,
                                                                    "input",
                                                                    "",
                                                                    input.GetAttribute("action"),
                                                                    "",
                                                                    input.GetAttribute("type"),
                                                                    input.GetAttribute("name"),
                                                                    input.GetAttribute("id"),
                                                                    input.GetAttribute("value"),
                                                                    input.GetAttribute("checked")=="False"?"":"checked" });

                    // set the BrowserFormNavi specific ID of the tag
                    input.SetAttribute("BFN_ID", tagId.ToString());

                    // add the ID of submit input
                    if (input.GetAttribute("type") == "submit")
                        Program.formNavi.AddItemToComboBox(Program.formNavi.comboBox2, tagId);
                }

                // call the loop over the buttons in form
                HtmlElementCollection buttons = form.GetElementsByTagName("button");
                foreach (HtmlElement button in buttons)
                {
                    // we are interested only in submit buttons
                    if (button.GetAttribute("type") != "submit") continue;

                    // copy browser form data to Form
                    Program.formNavi.AddRowToDataGrid(new object[] {++tagId,
                                                                    formNr,
                                                                    "button",
                                                                    "",
                                                                    button.GetAttribute("action"),
                                                                    "",
                                                                    button.GetAttribute("type"),
                                                                    button.GetAttribute("name"),
                                                                    button.GetAttribute("id"),
                                                                    button.GetAttribute("value") });

                    // set the BrowserFormNavi specific ID of the tag
                    button.SetAttribute("BFN_ID", tagId.ToString());

                    // add the ID of submit button
                    Program.formNavi.AddItemToComboBox(Program.formNavi.comboBox2, tagId);
                }
            }

            return 0;
        }

        public int LoopOverAllDivs(HtmlElementCollection divs, ref int tagId)
        {
            foreach (HtmlElement div in divs)
            {
                //check that the div contains the role=button
                if(div.GetAttribute("role")=="button")
                { 

                    // copy browser form data to Form
                    Program.formNavi.AddRowToDataGrid(new object[] {++tagId,
                                                                    "",
                                                                    "div",
                                                                    div.GetAttribute("className"),
                                                                    div.GetAttribute("action"),
                                                                    div.GetAttribute("role"),
                                                                    div.GetAttribute("type"),
                                                                    div.GetAttribute("name"),
                                                                    div.GetAttribute("id"),
                                                                    div.GetAttribute("value") });

                    // set the BrowserFormNavi specific ID of the tag
                    div.SetAttribute("BFN_ID", tagId.ToString());

                    // add the ID to be able to invoke the button
                    Program.formNavi.AddItemToComboBox(Program.formNavi.comboBox2, tagId);
                }
            }
            return 0;
        }


         public int CopyUrlToForm()
        {
            //set page URL
      //      Program.formNavi.SetComboBoxText(Program.formNavi.comboBox1, Program.browserView.GetHtmlDocumentUrl());
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
