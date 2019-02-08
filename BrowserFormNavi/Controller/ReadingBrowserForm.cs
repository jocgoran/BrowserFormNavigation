using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    class ReadingBrowserForm
    {

        public int ExtractBrowserForm()
        {
            //set page title
            Program.browserView.Text = Program.browserView.webBrowser1.DocumentTitle.ToString();

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
            foreach (HtmlElement form in forms)
            {
                ++formNr;
                // copy browser form data to Form
                Program.formNavi.dataGridView1.Rows.Add(formNr,
                                                        form.GetAttribute("action"));

                // add form number to list of form to submit
                Program.formNavi.comboBox2.Items.Add(formNr);

                // call the loop over the inputs
                LoopOverAllInputs(form);
            }
            return 0;
        }

        public int LoopOverAllInputs(HtmlElement form)
        {
            HtmlElementCollection inputs = form.GetElementsByTagName("input");
            foreach (HtmlElement input in inputs)
            {
                // copy browser form data to Form
                Program.formNavi.dataGridView1.Rows.Add("",
                                                        "",
                                                        input.GetAttribute("type"),
                                                        input.GetAttribute("name"),
                                                        input.GetAttribute("id"),
                                                        input.GetAttribute("value"));
            }
            return 0;
        }

        public int CopyUrlToForm()
        {
            //set page URL
            Program.formNavi.comboBox1.Text = Program.browserView.webBrowser1.Url.ToString();

            return 0;
        }

    }
}
