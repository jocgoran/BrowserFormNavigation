using System;
using System.Threading;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    public class SpecialSubmitter
    {

        //For Facebook: like everything that is not liked
        // data-testedid=URI2ReactionLink & style!=color: rgb(53, 120, 229);

        public int LikeEverytingOnFacebook()
        {

            // search each matching LIKE button
            // loop over all the rows of data grid to find submit button
            foreach (DataGridViewRow row in Program.formNavi.dataGridView1.Rows)
            {
                // check URI2ReactionLink
                if(string.Equals(row.Cells["DataTestIdAttribute"].Value.ToString(), "UFI2ReactionLink", StringComparison.OrdinalIgnoreCase))
                {
                    // check if aria-pressed == false
                    if (string.Equals(row.Cells["AriaPressed"].Value.ToString(), "false", StringComparison.OrdinalIgnoreCase))
                    {

                        // read the tagName of submit
                        String submitTagName = Program.formNavi.GetDataGridCell(row, "TagAttribute");

                        // get the Browser document thread safe
                        HtmlDocument htmlDocument = Program.browserView.GetHtmlDocument();

                        // get all the forms from browser
                        HtmlElementCollection submitTagNameCollection = htmlDocument.GetElementsByTagName(submitTagName);

                        // loop over all the tags that are same as submit 
                        foreach (HtmlElement submitElement in submitTagNameCollection)
                        {
                            // match the broser tagElement corresponding to DataGrid 
                            if (submitElement.GetAttribute("BFN_ID") == Program.formNavi.GetDataGridCell(row, "BFN_ID"))
                            {
                                // invoke the Submit
                                submitElement.InvokeMember("click");
                                Thread.Sleep(Program.rnd.Next(800, 1200));

                            } // end if BFN_ID
                        } // end loop submitElement

                    }
                }
            }

            return 0;
        }
    }
}
