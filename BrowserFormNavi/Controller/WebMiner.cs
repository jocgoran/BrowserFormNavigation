using BrowserFormNavi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BrowserFormNavi.Program;

namespace BrowserFormNavi.Controller
{
    public class WebMiner
    {

        private HashSet<string> icTagsToExport;
        HashSet<string> icAttributesToExport;

        private int WaitSomeIncrementalDownloads()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine();
            
            // wait until page is completly loaded
            while ((WebBrowserReadyState)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "ReadyState") != WebBrowserReadyState.Complete)
                Thread.Sleep(100);
            LogWriter.LogWrite(LogLevel.Info, "Elapsed time for ReadyState: " + sw.ElapsedMilliseconds);

            while ((bool)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "IsBusy"))
                Thread.Sleep(100);
            LogWriter.LogWrite(LogLevel.Info, "Elapsed time for IsBusy: " + sw.ElapsedMilliseconds);

            // get the Browser document thread safe
            HtmlDocument htmlDocument = (HtmlDocument)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "Document");

            // work only with html elements
            int elementCount = -1;
            while (elementCount != htmlDocument.All.Count)
            {
                elementCount = htmlDocument.All.Count;
                Thread.Sleep(300);
            }
            LogWriter.LogWrite(LogLevel.Info, "Elapsed time for elementCount method: " + sw.ElapsedMilliseconds);
            sw.Stop();

            return 0;
        }

        public int DocumentMining()
        {
            // create the structures of the tags and attributes to export
            HashSet<string> tagsToExport = new HashSet<string>();
            HashSet<string> attributesToExport = new HashSet<string>();

            // loop and fill the TreeView
            TreeNodeCollection nodes = (TreeNodeCollection)Program.formNavi.GetPropertyValue(Program.formNavi.treeView1, "Nodes");
            foreach (TreeNode node in nodes)
            {
                //add the checked node in the list
                if (node.Checked)
                    tagsToExport.Add(node.Name);

                foreach (TreeNode child in node.Nodes)
                {
                    //add the checked child in the list
                    if (child.Checked)
                        attributesToExport.Add(child.Name);
                }
            }

            icTagsToExport = new HashSet<string>(tagsToExport, StringComparer.InvariantCultureIgnoreCase);
            icAttributesToExport = new HashSet<string>(attributesToExport, StringComparer.InvariantCultureIgnoreCase);

            // some checks to load the page
            WaitSomeIncrementalDownloads();

            // get the Browser document thread safe
            HtmlDocument htmlDocument = (HtmlDocument)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "Document");
            HtmlElementCollection htmlElements = htmlDocument.All;
            Parallel.For(0, htmlElements.Count, i =>
            {
                // elements can be changed dynamically - prevent outOfIndex
                if (i >= htmlElements.Count) return;

                // prevent outOfIndex
                try
                {

                    //check if the TagName match with what to extract    
                    if (!TagExactMatch(htmlElements[i])) return;

                    //check if the Attribute Value match with what to extract
                    if (!AttributesExactMatch(htmlElements[i])) return;

                    // copy browser form data to Form
                    Program.formNavi.AddRowToDataGrid(new object[] {i,
                                                                htmlElements[i].TagName,
                                                                htmlElements[i].GetAttribute("className"),
                                                                htmlElements[i].GetAttribute("data-testid"),
                                                                htmlElements[i].GetAttribute("aria-pressed"),
                                                                htmlElements[i].GetAttribute("data-interest-id"),
                                                                htmlElements[i].GetAttribute("role"),
                                                                htmlElements[i].GetAttribute("type"),
                                                                htmlElements[i].GetAttribute("name"),
                                                                htmlElements[i].GetAttribute("id"),
                                                                htmlElements[i].GetAttribute("value"),
                                                                string.IsNullOrEmpty(htmlElements[i].GetAttribute("checked"))?"":"checked",
                                                                "0"});

                    // set the BrowserFormNavi specific ID of the tag
                    htmlElements[i].SetAttribute("BFN_ID", i.ToString());

                    // add the ID of submit input
                    if (SubmitTaxonomie(htmlElements[i]))
                        Program.formNavi.AddItemToComboBox(Program.formNavi.BFN_IDInvoke, i.ToString());
                }
                catch (Exception)
                {
                    LogWriter.LogWrite(LogLevel.Warning, "In WebMiner, not found element: " + i.ToString());
                    return;
                }
            });

            // sort the BFN_ID ascending
            Program.formNavi.SortDataGrid(Program.formNavi.dataGridView1.Columns[0], ListSortDirection.Ascending);

            return 0;
        }

        private bool TagExactMatch(HtmlElement tagElement)
        {
            //check if tag is to export
            string TagElementName = tagElement.TagName;
            if (icTagsToExport.Contains(TagElementName.ToLower()))
                return true;

            return false;
        }

        private bool AttributesExactMatch(HtmlElement tagElement)
        {
            //check if the attributes correspond to the exportation 
            string typeAttribute = tagElement.GetAttribute("type");
            string attributeNameValue = tagElement.TagName + "-type-" + typeAttribute;
            if (icAttributesToExport.Contains(attributeNameValue))
                return true;
           
            string roleAttribute = tagElement.GetAttribute("role");
            attributeNameValue = tagElement.TagName + "-role-" + roleAttribute;
            if (icAttributesToExport.Contains(attributeNameValue))
                return true;

            string dataTestIdAttribute = tagElement.GetAttribute("data-testid");
            attributeNameValue = tagElement.TagName + "-data-testid-" + dataTestIdAttribute;
            if (icAttributesToExport.Contains(attributeNameValue))
                return true;

            string classAttribute = tagElement.GetAttribute("className");
            attributeNameValue = tagElement.TagName + "-class-" + classAttribute;
            if (icAttributesToExport.Contains(attributeNameValue))
                return true;

            return false;
        }

        private bool SubmitTaxonomie(HtmlElement tagElement)
        {
            string typeAttribute = tagElement.GetAttribute("type");
            string roleAttribute = tagElement.GetAttribute("role");

            // decide if element can be invoked
            if (string.Equals(tagElement.TagName, "input", StringComparison.OrdinalIgnoreCase)
                && string.Equals(typeAttribute, "submit", StringComparison.OrdinalIgnoreCase))
                return true;

            if (string.Equals(tagElement.TagName, "input", StringComparison.OrdinalIgnoreCase)
                && string.Equals(typeAttribute, "image", StringComparison.OrdinalIgnoreCase))
                return true;

            if (string.Equals(tagElement.TagName, "button", StringComparison.OrdinalIgnoreCase)
                && string.Equals(typeAttribute, "submit", StringComparison.OrdinalIgnoreCase))
                return true;

            if (string.Equals(tagElement.TagName, "div", StringComparison.OrdinalIgnoreCase)
                && string.Equals(roleAttribute, "button", StringComparison.OrdinalIgnoreCase))
                return true;

            if (string.Equals(tagElement.TagName, "a", StringComparison.OrdinalIgnoreCase)
                && string.Equals(roleAttribute, "button", StringComparison.OrdinalIgnoreCase))
                return true;

            if (string.Equals(tagElement.TagName, "li", StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }
    }
}
