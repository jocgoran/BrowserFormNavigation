using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace BrowserFormNavi
{
    // ComboBox
    internal delegate void ComboBoxClearDelegate(ComboBox comboBoxName);
    internal delegate void AddItemToComboBoxDelegate(ComboBox comboBox, int formNr);
    internal delegate void SetLastComboBoxItemDelegate(ComboBox comboBoxName);


    // DataGrid
    internal delegate string GetDataGridCellDelegate(DataGridViewRow row, string colName);
    internal delegate void SetDataGridCellDelegate(DataGridViewRow row, string colName, string value);
    internal delegate void DataGridViewClearDelegate();
    internal delegate void AddRowToDataGridDelegate(object[] rowData);

    internal delegate object GetPropertyValueDelegate(object instance, string strPropertyName);
    internal delegate void   SetPropertyValueDelegate(dynamic instance, string strPropertyName, object newValue);
    internal delegate void   GetMethodDelegate(object instance, string strMethodName, object[] arguments);

    public partial class FormNavi : Form
    {
        public FormNavi()
        {
            InitializeComponent();

            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;  //Tell the user how the process went
            backgroundWorker1.WorkerSupportsCancellation = true; //Allow for the process to be cancelled

            // load all the domains that have dataMiningSettings
            Program.dBAccess.LoadDomainsWithDataMiningSettings();
            HashSet<string> domainsWithSettings = new HashSet<string>();
            Program.dBAccess.ColToHashSet("domain", ref domainsWithSettings);

            // add all domains with settings to listbox
            foreach (string domain in domainsWithSettings)
            {
                domains.Items.Add(domain);
            }
            
        }

        private void OpenPage(object sender, System.EventArgs e)
        {
            Program.navigation.OpenPage();
        }

        private void CopyDataToBrowser(object sender, System.EventArgs e)
        {
            Program.navigation.CopyFromGridToBrowser();
        }

        private void InvokeFormSubmit(object sender, System.EventArgs e)
        {
            Program.navigation.InvokeSubmit();
        }

        private void CheckDBConnection(object sender, System.EventArgs e)
        {
            Program.dBAccess.CheckDBConnection();
        }

        private void FillAutoGenData(object sender, System.EventArgs e)
        {
            Program.navigation.AutoFillInputValue();
        }

        private void SaveBrowserFilledDataToDatabase(object sender, System.EventArgs e)
        {
            Program.navigation.SaveBrowserFilledValuesToDatabase();
        }

        public void StopTheNavigation(object sender, System.EventArgs e)
        {
            int error=Program.navigation.StopTheNavigationLoop();
            if(error==0)
            { 
                //Check if background worker is doing anything and send a cancellation if it is
                if (backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.CancelAsync();
                }
            }
        }

        // This event handler deals with the results of the
        // background operation.
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetPropertyValue(buttonStart, "Enabled", true);
            SetPropertyValue(buttonStop, "Enabled", false);
            SetPropertyValue(FillAutoGenertedData, "Enabled", true);
            SetPropertyValue(CopyToBrowser, "Enabled", true);
            SetPropertyValue(SaveBrowserValuesToDB, "Enabled", true);
            SetPropertyValue(Go, "Enabled", true);
            SetPropertyValue(Submit, "Enabled", true);
            SetPropertyValue(comboBox2, "Enabled", true);
        }

        private void StartTheNavigation(object sender, System.EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SetPropertyValue(buttonStart, "Enabled", false);
            SetPropertyValue(buttonStop, "Enabled", true);
            SetPropertyValue(FillAutoGenertedData, "Enabled", false);
            SetPropertyValue(CopyToBrowser, "Enabled", false);
            SetPropertyValue(SaveBrowserValuesToDB, "Enabled", false);
            SetPropertyValue(Go, "Enabled", false);
            SetPropertyValue(Submit, "Enabled", false);
            SetPropertyValue(comboBox2, "Enabled", false);
            Program.navigation.StartTheNavigationLoop();
        }


        public void SetDataGridCell(DataGridViewRow row, string colName, string value)
        {
            if (dataGridView1.InvokeRequired)
            {
                SetDataGridCellDelegate sdgcd = new SetDataGridCellDelegate(SetDataGridCell);
                dataGridView1.Invoke(sdgcd, new object[] { row, colName, value});
            }
            else
            {
                row.Cells[colName].Value = value;
            }
        }

        public string GetDataGridCell(DataGridViewRow row, string colName)
        {
            if (Program.formNavi.dataGridView1.InvokeRequired)
            {
                GetDataGridCellDelegate gdgcd = new GetDataGridCellDelegate(GetDataGridCell);
                return (string)Program.formNavi.dataGridView1.Invoke(gdgcd, new object[] { row, colName });
            }
            else
            {
                // handle null cell
                if (row.Cells[colName].Value == null) return "";
                return row.Cells[colName].Value.ToString();
            }
        }

        public void DataGridViewClear()
        {
            if (dataGridView1.InvokeRequired)
            {
                DataGridViewClearDelegate dgwcl = new DataGridViewClearDelegate(DataGridViewClear);
                dataGridView1.Invoke(dgwcl, new object[] { });
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }

        public void ComboBoxClear(ComboBox comboBoxName)
        {
            if (comboBoxName.InvokeRequired)
            {
                ComboBoxClearDelegate cbcd = new ComboBoxClearDelegate(ComboBoxClear);
                comboBoxName.Invoke(cbcd, new object[] { comboBoxName });
            }
            else
            {
                comboBoxName.Items.Clear();
            }
        }
       
        public void AddRowToDataGrid(object[] rowData)
        {
            if (dataGridView1.InvokeRequired)
            {
                AddRowToDataGridDelegate artdg = new AddRowToDataGridDelegate(AddRowToDataGrid);
                dataGridView1.Invoke(artdg, new object[] { rowData });
            }
            else
            {
                dataGridView1.Rows.Add(rowData[0], rowData[1], rowData[2], rowData[3], rowData[4], rowData[5], rowData[6], rowData[7], rowData[8]);
            }
        }

        public void AddItemToComboBox(ComboBox comboBox, int tagId)
        {
            if (comboBox.InvokeRequired)
            {
                AddItemToComboBoxDelegate aitcbd = new AddItemToComboBoxDelegate(AddItemToComboBox);
                comboBox.Invoke(aitcbd, new object[] { comboBox, tagId });
            }
            else
            {
                comboBox.Items.Add(tagId);
            }
        }

        public void SetLastComboBoxItem(ComboBox comboBox)
        {
            if (comboBox.InvokeRequired)
            {
                SetLastComboBoxItemDelegate slcbid = new SetLastComboBoxItemDelegate(SetLastComboBoxItem);
                comboBox.Invoke(slcbid, new object[] { comboBox });
            }
            else
            {
                if (comboBox.Items.Count > 0)
                    comboBox.SelectedIndex = comboBox.Items.Count-1;
            }
        }
        
        private void ExtractFromBrowser(object sender, System.EventArgs e)
        {
            Program.navigation.WriteBrowserFormToGrid();
        }

        private void SubmitSpecial(object sender, System.EventArgs e)
        {
            SetPropertyValue(formRulesSet, "Enabled", false);
            Program.navigation.SubmitSpecial();
            SetPropertyValue(formRulesSet, "Enabled", true);
            
        }

        public object GetPropertyValue(dynamic instance, string strPropertyName)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (instance.InvokeRequired)
            {
                GetPropertyValueDelegate gpvd = new GetPropertyValueDelegate(GetPropertyValue);
                return instance.Invoke(gpvd, new object[] { instance, strPropertyName });
            }
            else
            {
                Type type = instance.GetType();
                PropertyInfo propertyInfo = type.GetProperty(strPropertyName);
                return propertyInfo.GetValue(instance, new object[] { });
            }
        }

        public void SetPropertyValue(dynamic instance, string strPropertyName, object newValue)
        {
            if (instance.InvokeRequired)
            {
                SetPropertyValueDelegate spvd = new SetPropertyValueDelegate(SetPropertyValue);
                instance.Invoke(spvd, new object[] { instance, strPropertyName, newValue });
            }
            else
            {
                Type type = instance.GetType();
                PropertyInfo propertyInfo = type.GetProperty(strPropertyName);
                propertyInfo.SetValue(instance, newValue, null);
            }
        }

        public void GetMethod(dynamic instance, string strMethodName, object[] arguments)
        {
            if (instance.InvokeRequired)
            {
                GetMethodDelegate gmd = new GetMethodDelegate(GetMethod);
                instance.Invoke(gmd, new object[] { instance, strMethodName, arguments });
            }
            else
            {
                Type type = instance.GetType();
                MethodInfo methodInfo = type.GetMethod(strMethodName);
                methodInfo.Invoke(instance, arguments);
            }
        }

        private void LoadDomainSettings(object sender, EventArgs e)
        {
            Program.navigation.LoadDomainSettings();
        }

    }
}
