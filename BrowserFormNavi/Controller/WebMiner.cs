using System;
using System.Collections.Generic;
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
                int tagId = 0;

                foreach (HtmlElement tagElement in htmlDocument.All)
                {
                    if (!TagExactMatch(tagElement)) continue;

                    if (!AttributesExactMatch(tagElement)) continue;

                     // copy browser form data to Form
                    Program.formNavi.AddRowToDataGrid(new object[] {++tagId,
                                                                tagElement.TagName,
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
                    if (SubmitTaxonomie(tagElement))
                        Program.formNavi.AddItemToComboBox(Program.formNavi.BFN_IDInvoke, tagId.ToString());
                }

            }
            return 0;
        }

        private bool TagExactMatch(HtmlElement tagElement)
        {
            //check if tag is to export
            string TagElementName= tagElement.TagName;
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
