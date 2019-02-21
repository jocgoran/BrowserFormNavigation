using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BrowserFormNavi
{
    // Button
    internal delegate void EnableButtonDelegate(Button button, bool enable);
    internal delegate void SetButtonColorDelegate(Button buttonName, Color color);
    internal delegate void SetButtonTextColorDelegate(Button buttonName, Color color);
    internal delegate void ButtonPerformClickDelegate(Button button);

    // ComboBox
    internal delegate string GetComboBoxSelectedItemDelegate(ComboBox comboBoxName);
    internal delegate string GetComboBoxTextDelegate(ComboBox comboBoxName);
    internal delegate void SetComboBoxTextDelegate(ComboBox comboBoxName, string text);
    internal delegate void ComboBoxClearDelegate(ComboBox comboBoxName);
    internal delegate void EnableComboBoxDelegate(ComboBox comboBoxName, bool enable);
    internal delegate void AddItemToComboBoxDelegate(ComboBox comboBox, int formNr);
    internal delegate void SetComboBoxItemDelegate(ComboBox comboBoxName, object item);
    internal delegate void SetLastComboBoxItemDelegate(ComboBox comboBoxName);


    // DataGrid
    internal delegate string GetDataGridCellDelegate(DataGridViewRow row, string colName);
    internal delegate void SetDataGridCellDelegate(DataGridViewRow row, string colName, string value);
    internal delegate void DataGridViewClearDelegate();
    internal delegate void AddRowToDataGridDelegate(object[] rowData);

    public partial class FormNavi : Form
    {
        public FormNavi()
        {
            InitializeComponent();

            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;  //Tell the user how the process went
            backgroundWorker1.WorkerSupportsCancellation = true; //Allow for the process to be cancelled
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
            EnableButton(buttonStart, true);
            EnableButton(buttonStop, false);
            EnableButton(FillAutoGenertedData, true);
            EnableButton(CopyToBrowser, true);
            EnableButton(SaveBrowserValuesToDB, true);
            EnableButton(Go, true);
            EnableButton(Submit, true);
            EnableComboBox(comboBox2, true);
        }

        private void StartTheNavigation(object sender, System.EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // FormNavi.Invoke(FormNavi.button5.Enable = false);         
            EnableButton(buttonStart, false);
            EnableButton(buttonStop, true);
            EnableButton(FillAutoGenertedData, false);
            EnableButton(CopyToBrowser, false);
            EnableButton(SaveBrowserValuesToDB, false);
            EnableButton(Go, false);
            EnableButton(Submit, false);
            EnableComboBox(comboBox2, false);
            Program.navigation.StartTheNavigationLoop();
        }

        private void EnableButton(Button button, bool enable)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (button.InvokeRequired)
            {
                EnableButtonDelegate ebd = new EnableButtonDelegate(EnableButton);
                button.Invoke(ebd, new object[] { button, enable });
            }
            else
            {
                button.Enabled = enable;
            }
        }

        public string GetComboBoxSelectedItem(ComboBox comboBoxName)
        {
            if (comboBoxName.InvokeRequired)
            {
                GetComboBoxSelectedItemDelegate gsid = new GetComboBoxSelectedItemDelegate(GetComboBoxSelectedItem);
                return (string)comboBoxName.Invoke(gsid, new object[] { comboBoxName });
            }
            else
            {
                // handle null selection
                if (comboBoxName.SelectedItem == null) return "";
                return comboBoxName.SelectedItem.ToString();
            }
        }

        public string GetComboBoxText(ComboBox comboBoxName)
        {
            if (comboBoxName.InvokeRequired)
            {
                GetComboBoxTextDelegate gcbt = new GetComboBoxTextDelegate(GetComboBoxText);
                return (string)comboBoxName.Invoke(gcbt, new object[] { comboBoxName });
            }
            else
            {
                return comboBoxName.Text;
            }
        }

        public void SetComboBoxText(ComboBox comboBoxName, string text)
        {
            if (comboBoxName.InvokeRequired)
            {
                SetComboBoxTextDelegate scbt = new SetComboBoxTextDelegate(SetComboBoxText);
                comboBoxName.Invoke(scbt, new object[] { comboBoxName, text });
            }
            else
            {
                comboBoxName.Text = text;
            }
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

        public void EnableComboBox(ComboBox comboBoxName, bool enable)
        {
            if (comboBoxName.InvokeRequired)
            {
                EnableComboBoxDelegate ecbd = new EnableComboBoxDelegate(EnableComboBox);
                comboBoxName.Invoke(ecbd, new object[] { comboBoxName, enable });
            }
            else
            {
                comboBoxName.Enabled = enable;
            }
        }

        public void SetButtonColor(Button buttonName, Color color)
        {
            if (buttonName.InvokeRequired)
            {
                SetButtonColorDelegate sbcd = new SetButtonColorDelegate(SetButtonColor);
                buttonName.Invoke(sbcd, new object[] { buttonName, color });
            }
            else
            {
                buttonName.BackColor = color;
            }
        }

        public void SetButtonTextColor(Button buttonName, Color color)
        {
            if (buttonName.InvokeRequired)
            {
                SetButtonTextColorDelegate sbtcd = new SetButtonTextColorDelegate(SetButtonTextColor);
                buttonName.Invoke(sbtcd, new object[] { buttonName, color });
            }
            else
            {
                buttonName.ForeColor = color;
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

        public void ButtonPerformClick(Button button)
        {
            if (button.InvokeRequired)
            {
                ButtonPerformClickDelegate bpcd = new ButtonPerformClickDelegate(ButtonPerformClick);
                button.Invoke(bpcd, new object[] { button });
            }
            else
            {
                button.PerformClick();
            }
        }

        public void SetComboBoxItem(ComboBox comboBox, object item)
        {
            if (comboBox.InvokeRequired)
            {
                SetComboBoxItemDelegate scbvd = new SetComboBoxItemDelegate(SetComboBoxItem);
                comboBox.Invoke(scbvd, new object[] { comboBox, item });
            }
            else
            {
                if(comboBox.Items.Count>0)
                   comboBox.SelectedItem = item;
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
            EnableButton(submitSpecial, false);
            EnableComboBox(comboBox3, false);
            Program.navigation.SubmitSpecial();
            EnableButton(submitSpecial, true);
            EnableComboBox(comboBox3, true);
            
        }
    }
}
