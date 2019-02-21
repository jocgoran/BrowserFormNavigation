using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BrowserFormNavi
{
    public partial class FormNavi
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Go = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Submit = new System.Windows.Forms.Button();
            this.CopyToBrowser = new System.Windows.Forms.Button();
            this.FillAutoGenertedData = new System.Windows.Forms.Button();
            this.btnCheckDBConnection = new System.Windows.Forms.Button();
            this.SaveBrowserValuesToDB = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExtractFormFromBrowser = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.submitSpecial = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.BFN_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataTestIdAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AriaPressed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckedAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "https://badoo.com/signin",
            "https://tinder.com/app/recs",
            "http://www.facebook.com",
            "http://www.amazon.de"});
            this.comboBox1.Location = new System.Drawing.Point(12, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(804, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Url to navigate";
            // 
            // Go
            // 
            this.Go.Location = new System.Drawing.Point(830, 12);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(93, 22);
            this.Go.TabIndex = 1;
            this.Go.Text = "Go";
            this.Go.UseVisualStyleBackColor = true;
            this.Go.Click += new System.EventHandler(this.OpenPage);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BFN_ID,
            this.TagAttribute,
            this.ClassAttribute,
            this.DataTestIdAttribute,
            this.AriaPressed,
            this.RoleAttribute,
            this.TypeAttribute,
            this.NameAttribute,
            this.IDAttribute,
            this.ValueAttribute,
            this.CheckedAttribute});
            this.dataGridView1.Location = new System.Drawing.Point(12, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1039, 510);
            this.dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 657);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "BNF_ID to invoke";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(126, 654);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(62, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(182, 74);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(56, 23);
            this.Submit.TabIndex = 5;
            this.Submit.Text = "submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.InvokeFormSubmit);
            // 
            // CopyToBrowser
            // 
            this.CopyToBrowser.Location = new System.Drawing.Point(293, 613);
            this.CopyToBrowser.Name = "CopyToBrowser";
            this.CopyToBrowser.Size = new System.Drawing.Size(98, 27);
            this.CopyToBrowser.TabIndex = 6;
            this.CopyToBrowser.Text = "Copy to browser";
            this.CopyToBrowser.UseVisualStyleBackColor = true;
            this.CopyToBrowser.Click += new System.EventHandler(this.CopyDataToBrowser);
            // 
            // FillAutoGenertedData
            // 
            this.FillAutoGenertedData.Location = new System.Drawing.Point(136, 613);
            this.FillAutoGenertedData.Name = "FillAutoGenertedData";
            this.FillAutoGenertedData.Size = new System.Drawing.Size(151, 27);
            this.FillAutoGenertedData.TabIndex = 7;
            this.FillAutoGenertedData.Text = "Fill auto generted data";
            this.FillAutoGenertedData.UseVisualStyleBackColor = true;
            this.FillAutoGenertedData.Click += new System.EventHandler(this.FillAutoGenData);
            // 
            // btnCheckDBConnection
            // 
            this.btnCheckDBConnection.Location = new System.Drawing.Point(928, 575);
            this.btnCheckDBConnection.Name = "btnCheckDBConnection";
            this.btnCheckDBConnection.Size = new System.Drawing.Size(123, 27);
            this.btnCheckDBConnection.TabIndex = 8;
            this.btnCheckDBConnection.Text = "Check DB Connection";
            this.btnCheckDBConnection.UseVisualStyleBackColor = true;
            this.btnCheckDBConnection.Click += new System.EventHandler(this.CheckDBConnection);
            // 
            // SaveBrowserValuesToDB
            // 
            this.SaveBrowserValuesToDB.Location = new System.Drawing.Point(397, 613);
            this.SaveBrowserValuesToDB.Name = "SaveBrowserValuesToDB";
            this.SaveBrowserValuesToDB.Size = new System.Drawing.Size(177, 27);
            this.SaveBrowserValuesToDB.TabIndex = 9;
            this.SaveBrowserValuesToDB.Text = "Save browser values to database";
            this.SaveBrowserValuesToDB.UseVisualStyleBackColor = true;
            this.SaveBrowserValuesToDB.Click += new System.EventHandler(this.SaveBrowserFilledDataToDatabase);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ExtractFormFromBrowser);
            this.groupBox1.Controls.Add(this.buttonStop);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.Submit);
            this.groupBox1.Location = new System.Drawing.Point(12, 578);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 108);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perform recursively automated";
            // 
            // ExtractFormFromBrowser
            // 
            this.ExtractFormFromBrowser.Location = new System.Drawing.Point(6, 35);
            this.ExtractFormFromBrowser.Name = "ExtractFormFromBrowser";
            this.ExtractFormFromBrowser.Size = new System.Drawing.Size(114, 27);
            this.ExtractFormFromBrowser.TabIndex = 11;
            this.ExtractFormFromBrowser.Text = "Extract from browser";
            this.ExtractFormFromBrowser.UseVisualStyleBackColor = true;
            this.ExtractFormFromBrowser.Click += new System.EventHandler(this.ExtractFromBrowser);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(216, -1);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(56, 22);
            this.buttonStop.TabIndex = 12;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.StopTheNavigation);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(156, -1);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(54, 22);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.StartTheNavigation);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.submitSpecial);
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Location = new System.Drawing.Point(594, 577);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 108);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Special submit functionalities";
            // 
            // submitSpecial
            // 
            this.submitSpecial.Location = new System.Drawing.Point(16, 75);
            this.submitSpecial.Name = "submitSpecial";
            this.submitSpecial.Size = new System.Drawing.Size(75, 23);
            this.submitSpecial.TabIndex = 1;
            this.submitSpecial.Text = "submit";
            this.submitSpecial.UseVisualStyleBackColor = true;
            this.submitSpecial.Click += new System.EventHandler(this.SubmitSpecial);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(16, 36);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(278, 21);
            this.comboBox3.TabIndex = 0;
            // 
            // BFN_ID
            // 
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            this.BFN_ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.BFN_ID.FillWeight = 50F;
            this.BFN_ID.Frozen = true;
            this.BFN_ID.HeaderText = "BFN_ID";
            this.BFN_ID.Name = "BFN_ID";
            this.BFN_ID.ReadOnly = true;
            this.BFN_ID.Width = 50;
            // 
            // TagAttribute
            // 
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            this.TagAttribute.DefaultCellStyle = dataGridViewCellStyle2;
            this.TagAttribute.Frozen = true;
            this.TagAttribute.HeaderText = "Tag";
            this.TagAttribute.Name = "TagAttribute";
            this.TagAttribute.ReadOnly = true;
            this.TagAttribute.Width = 50;
            // 
            // ClassAttribute
            // 
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gray;
            this.ClassAttribute.DefaultCellStyle = dataGridViewCellStyle3;
            this.ClassAttribute.Frozen = true;
            this.ClassAttribute.HeaderText = "Class";
            this.ClassAttribute.Name = "ClassAttribute";
            this.ClassAttribute.ReadOnly = true;
            // 
            // DataTestIdAttribute
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gray;
            this.DataTestIdAttribute.DefaultCellStyle = dataGridViewCellStyle4;
            this.DataTestIdAttribute.Frozen = true;
            this.DataTestIdAttribute.HeaderText = "Data-testid";
            this.DataTestIdAttribute.Name = "DataTestIdAttribute";
            this.DataTestIdAttribute.ReadOnly = true;
            // 
            // AriaPressed
            // 
            this.AriaPressed.Frozen = true;
            this.AriaPressed.HeaderText = "aria-pressed";
            this.AriaPressed.Name = "AriaPressed";
            this.AriaPressed.ReadOnly = true;
            // 
            // RoleAttribute
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Gray;
            this.RoleAttribute.DefaultCellStyle = dataGridViewCellStyle5;
            this.RoleAttribute.Frozen = true;
            this.RoleAttribute.HeaderText = "Role";
            this.RoleAttribute.Name = "RoleAttribute";
            this.RoleAttribute.ReadOnly = true;
            // 
            // TypeAttribute
            // 
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Gray;
            this.TypeAttribute.DefaultCellStyle = dataGridViewCellStyle6;
            this.TypeAttribute.Frozen = true;
            this.TypeAttribute.HeaderText = "Type";
            this.TypeAttribute.Name = "TypeAttribute";
            this.TypeAttribute.ReadOnly = true;
            // 
            // NameAttribute
            // 
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Gray;
            this.NameAttribute.DefaultCellStyle = dataGridViewCellStyle7;
            this.NameAttribute.Frozen = true;
            this.NameAttribute.HeaderText = "Name";
            this.NameAttribute.Name = "NameAttribute";
            this.NameAttribute.ReadOnly = true;
            // 
            // IDAttribute
            // 
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Gray;
            this.IDAttribute.DefaultCellStyle = dataGridViewCellStyle8;
            this.IDAttribute.Frozen = true;
            this.IDAttribute.HeaderText = "ID";
            this.IDAttribute.Name = "IDAttribute";
            this.IDAttribute.ReadOnly = true;
            // 
            // ValueAttribute
            // 
            this.ValueAttribute.Frozen = true;
            this.ValueAttribute.HeaderText = "Value";
            this.ValueAttribute.Name = "ValueAttribute";
            // 
            // CheckedAttribute
            // 
            this.CheckedAttribute.Frozen = true;
            this.CheckedAttribute.HeaderText = "Checked";
            this.CheckedAttribute.Name = "CheckedAttribute";
            // 
            // FormNavi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 698);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SaveBrowserValuesToDB);
            this.Controls.Add(this.btnCheckDBConnection);
            this.Controls.Add(this.FillAutoGenertedData);
            this.Controls.Add(this.CopyToBrowser);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Go);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormNavi";
            this.Text = "Automated formular extractor and formular submitter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public ComboBox comboBox1;
        public Button Go;
        public DataGridView dataGridView1;
        public Label label1;
        public ComboBox comboBox2;
        public Button Submit;
        public Button CopyToBrowser;
        public Button FillAutoGenertedData;
        public Button btnCheckDBConnection;
        public Button SaveBrowserValuesToDB;
        public GroupBox groupBox1;
        public Button buttonStart;
        public BackgroundWorker backgroundWorker1;
        public Button buttonStop;
        public Button ExtractFormFromBrowser;
        private GroupBox groupBox2;
        private Button submitSpecial;
        private ComboBox comboBox3;
        private DataGridViewTextBoxColumn BFN_ID;
        private DataGridViewTextBoxColumn TagAttribute;
        private DataGridViewTextBoxColumn ClassAttribute;
        private DataGridViewTextBoxColumn DataTestIdAttribute;
        private DataGridViewTextBoxColumn AriaPressed;
        private DataGridViewTextBoxColumn RoleAttribute;
        private DataGridViewTextBoxColumn TypeAttribute;
        private DataGridViewTextBoxColumn NameAttribute;
        private DataGridViewTextBoxColumn IDAttribute;
        private DataGridViewTextBoxColumn ValueAttribute;
        private DataGridViewTextBoxColumn CheckedAttribute;
    }
}

