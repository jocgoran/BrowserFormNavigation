﻿using BrowserFormNavi.Model;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BrowserFormNavi.Program;

namespace BrowserFormNavi.Controller
{
    public class HTMLDoc
    {
        public int ExtractBrowserForm()
        {
            // clear DataGrid with form data 
            Program.formNavi.DataGridViewClear();
            // clear drop down menu of choosen form
            Program.formNavi.ComboBoxClear(Program.formNavi.BFN_IDInvoke);

            //set page title
            string BrowserTitel= (string)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "DocumentTitle");
            Program.browserView.SetPropertyValue(Program.browserView, "Text", BrowserTitel);

            // passing the document for elaboration
            Program.webMiner.DocumentMining();

            //copy URl To Form
            CopyUrlToForm();

            //update domainId
            UpdateDomain();

            return 0;
        }

        public int CopyUrlToForm()
        {
            //set page URL
            Uri url = (Uri)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "Url");
            Program.formNavi.SetPropertyValue(Program.formNavi.navigationURL, "Text", url.ToString());
            return 0;
        }

        public int UpdateDomain()
        {
            //set page URL
            Uri url = (Uri)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "Url");
            Program.browserData.domain = new Uri(url.ToString()).Host;
            return 0;
        }

        public int SaveBrowserValuesToDatabase()
        {
            string url = (string)Program.formNavi.GetPropertyValue(Program.formNavi.navigationURL, "Text");
            // get the domainId
            DataTable domain = new DataTable();
            Program.dBAccess.GetDBData("Domain", new object[] { Program.browserData.domain }, ref domain);

            // get the BFN_IDInvoke  
            string ChoosenBFNID = (string)Program.formNavi.GetPropertyValue(Program.formNavi.BFN_IDInvoke, "SelectedItem");
            if (string.IsNullOrEmpty(ChoosenBFNID)) ChoosenBFNID = "-1";

            // get the Browser document thread safe
            HtmlDocument htmlDocument = (HtmlDocument)Program.browserView.GetPropertyValue(Program.browserView.webBrowser1, "Document");

            // loop over htmlElements
            HtmlElementCollection htmlElements = htmlDocument.All;
            Parallel.For(0, htmlElements.Count, i =>
            {
                // elements can be changed dynamically - prevent outOfIndex
                if (i >= htmlElements.Count) return;

                // prevent outOfIndex
                try
                {

                    // elaborate only htmlElments with BFN_ID
                    if (string.IsNullOrEmpty(htmlElements[i].GetAttribute("BFN_ID"))) return;

                    // extract the input values
                    string tag = htmlElements[i].TagName;
                    string classAttribute = htmlElements[i].GetAttribute("className");
                    string dataTestId = htmlElements[i].GetAttribute("data-testid");
                    string ariaPressed = htmlElements[i].GetAttribute("aria-pressed");
                    string dataInterestId = htmlElements[i].GetAttribute("data-interest-id");
                    string role = htmlElements[i].GetAttribute("role");
                    string type = htmlElements[i].GetAttribute("type");
                    string name = htmlElements[i].GetAttribute("name");
                    string inputFieldID = htmlElements[i].GetAttribute("id");

                    // insert IF NOT EXISTS description of User Interface Component
                    int error = Program.dBAccess.InsertDBData("InsertInputFormData", new object[] { url, domain.Rows[0]["id"], tag, classAttribute, dataTestId, ariaPressed, dataInterestId, role, type, name, inputFieldID });

                    // get the FormPK of UIComponent to save parameters
                    DataTable UIComponentPrimaryKey = new DataTable();
                    Program.dBAccess.GetDBData("UIComponentPrimaryKey", new object[] { url, domain.Rows[0]["id"], tag, classAttribute, dataTestId, ariaPressed, dataInterestId, role, type, name, inputFieldID },ref UIComponentPrimaryKey);

                    // set what you need to have in the history table
                    string value = htmlElements[i].GetAttribute("value");
                    string sChecked = string.IsNullOrEmpty(htmlElements[i].GetAttribute("checked")) ? "" : "checked";
                    int invoked = (string.Equals(ChoosenBFNID, htmlElements[i].GetAttribute("BFN_ID"))) ? 1 : 0;


                    //save value, checkbox and invoke on UIComponent
                    if(!string.IsNullOrEmpty(value) || !string.IsNullOrEmpty(sChecked) || invoked==1)
                        Program.dBAccess.UpdateDBData("SaveHistorcalInputParam", new object[] { UIComponentPrimaryKey.Rows[0]["id"], value, sChecked, invoked});

                    // dispose the DataTable
                    UIComponentPrimaryKey.Dispose();
                }
                    catch (Exception ex)
                {
                    LogWriter.LogWrite(LogLevel.Warning, "In HTMLDoc, not found element: " + i.ToString());
                    LogWriter.LogWrite(LogLevel.Error, "Catch Exception: " + ex.Message);
                    LogWriter.LogWrite(LogLevel.Error, "Catch Exception: " + ex.StackTrace);
                    return;
                }
        }); // end loop over htmlElements

            // dispose the DataTable
            domain.Dispose();

            return 0;
        }

    }
}
