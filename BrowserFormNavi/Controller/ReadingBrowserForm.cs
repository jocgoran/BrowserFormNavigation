using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Program.formNavi.dataGridView1.Rows.Clear();
            // clear drop down menu of choosen form
            Program.formNavi.comboBox2.Items.Clear();

            //set page title
            Program.browserView.Text = Program.browserView.webBrowser1.DocumentTitle.ToString();

            //copy URl To Form
            CopyUrlToForm();

            // extract the Form tag       
            if (Program.browserView.webBrowser1.Document != null)
            {
                HtmlElementCollection forms = Program.browserView.webBrowser1.Document.GetElementsByTagName("form");
                // call the loop overthe forms
                LoopOverAllForms(forms);
            }
            Program.browserData.FormExtracted = true;
            return 0;
        }

        public int LoopOverAllForms(HtmlElementCollection forms)
        {
            int formNr = 0;
            int tagId = 0;
            foreach (HtmlElement form in forms)
            {
                // copy browser form data to Form
                Program.formNavi.dataGridView1.Rows.Add(++tagId,
                                                        ++formNr,
                                                        "form",
                                                        form.GetAttribute("action"),
                                                        form.GetAttribute("type"),
                                                        form.GetAttribute("name"),
                                                        form.GetAttribute("id"),
                                                        form.GetAttribute("value"));

                // add form number to list of form to submit
                Program.formNavi.comboBox2.Items.Add(formNr);
                // Preselect the first element
                Program.formNavi.comboBox2.SelectedIndex=0;

                // set the BrowserFormNavi specific ID of the tag
                form.SetAttribute("BFN_ID", tagId.ToString());

                // call the loop over the inputs
                HtmlElementCollection inputs = form.GetElementsByTagName("input");
                foreach (HtmlElement input in inputs)
                {
                    // copy browser form data to Form
                    Program.formNavi.dataGridView1.Rows.Add(++tagId,
                                                            formNr,
                                                            "input",
                                                            input.GetAttribute("action"),
                                                            input.GetAttribute("type"),
                                                            input.GetAttribute("name"),
                                                            input.GetAttribute("id"),
                                                            input.GetAttribute("value"),
                                                            input.GetAttribute("checked")=="False"?"":"checked");

                    // set the BrowserFormNavi specific ID of the tag
                    input.SetAttribute("BFN_ID", tagId.ToString());
                }

                // call the loop over the buttons
                HtmlElementCollection buttons = form.GetElementsByTagName("button");
                foreach (HtmlElement button in buttons)
                {
                    if (button.GetAttribute("type") != "submit") continue;

                    // copy browser form data to Form
                    Program.formNavi.dataGridView1.Rows.Add(++tagId,
                                                            formNr,
                                                            "button",
                                                            button.GetAttribute("action"),
                                                            button.GetAttribute("type"),
                                                            button.GetAttribute("name"),
                                                            button.GetAttribute("id"),
                                                            button.GetAttribute("value"));

                    // set the BrowserFormNavi specific ID of the tag
                    button.SetAttribute("BFN_ID", tagId.ToString());
                }
            }
            return 0;
        }

        public int CopyUrlToForm()
        {
            //set page URL
            Program.formNavi.comboBox1.Text = Program.browserView.webBrowser1.Url.ToString();

            return 0;
        }

        public int SaveBrowserValuesToDatabase()
        {
            // read the form that have to be submitted  
            int ChoosenFormNr = Program.formNavi.comboBox2.SelectedIndex;

            // get all the forms
            HtmlElementCollection forms = Program.browserView.webBrowser1.Document.GetElementsByTagName("form");

            // call the loop over the inputs of my choosen form
            HtmlElementCollection inputs = forms[ChoosenFormNr].GetElementsByTagName("input");
            foreach (HtmlElement input in inputs)
            {

                string url = Program.formNavi.comboBox1.Text;
                string domain = new Uri(Program.formNavi.comboBox1.Text).Host;
                string tag = "input";
                string type = input.GetAttribute("type");
                string name = input.GetAttribute("name");
                string inputFieldID = input.GetAttribute("id");
                string value = input.GetAttribute("value");
                string sChecked = input.GetAttribute("checked") == "False" ? "" : "checked";

                // insert IF NOT EXISTS description of input data
                int error = Program.dBAccess.InsertInputFormData(url, domain, tag, type, name, inputFieldID);

                // get the FormPK of which to save parameters
                int FormPK = 0;
                Program.dBAccess.GetInputPrimaryKey(url, domain, tag, type, name, inputFieldID, ref FormPK);
 
                if(input.GetAttribute("type") != "hidden")
                {
                    //save value and checkbox
                    Program.dBAccess.SaveHistorcalInputParam(FormPK, value, sChecked);
                }
            }

            return 0;
        }

    }
}
