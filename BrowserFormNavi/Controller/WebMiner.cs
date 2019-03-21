using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserFormNavi.Controller
{
    public class WebMiner
    {

        private HashSet<string> icTagsToExport;
        HashSet<string> icAttributesToExport;

        public int DocumentMining(HtmlDocument htmlDocument)
        {
            // looop over all tags 
            if (htmlDocument != null)
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

                // set the tagId
             //   int tagId = 0;

                HtmlElementCollection tagElements = htmlDocument.All;
                //foreach (HtmlElement tagElement in tagElements)
                Parallel.For(0, tagElements.Count, i =>
                {

                    //int SouceINdex=((mshtml.HTMLLinkElementClass)tagElement.htmlElement).IHTMLElement_sourceIndex;
                    if (!TagExactMatch(tagElements[i])) return;

                    if (!AttributesExactMatch(tagElements[i])) return;

                    // copy browser form data to Form
                    Program.formNavi.AddRowToDataGrid(new object[] {i,
                                                                tagElements[i].TagName,
                                                                tagElements[i].GetAttribute("className"),
                                                                tagElements[i].GetAttribute("data-testid"),
                                                                tagElements[i].GetAttribute("aria-pressed"),
                                                                tagElements[i].GetAttribute("role"),
                                                                tagElements[i].GetAttribute("type"),
                                                                tagElements[i].GetAttribute("name"),
                                                                tagElements[i].GetAttribute("id"),
                                                                tagElements[i].GetAttribute("value"),
                                                                tagElements[i].GetAttribute("checked")=="False"?"":"checked",
                                                                "0"});

                    // set the BrowserFormNavi specific ID of the tag
                    tagElements[i].SetAttribute("BFN_ID", i.ToString());

                    // add the ID of submit input
                    if (SubmitTaxonomie(tagElements[i]))
                        Program.formNavi.AddItemToComboBox(Program.formNavi.BFN_IDInvoke, i.ToString());
                });

            }
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

            return false;
        }
    }
}
