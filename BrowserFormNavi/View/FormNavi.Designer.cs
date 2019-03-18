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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("hidden");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("input", new System.Windows.Forms.TreeNode[] {
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("submit");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("button", new System.Windows.Forms.TreeNode[] {
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("button");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("div", new System.Windows.Forms.TreeNode[] {
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("button");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("a", new System.Windows.Forms.TreeNode[] {
            treeNode23});
            this.navigationURL = new System.Windows.Forms.ComboBox();
            this.Go = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.BFN_IDInvoke = new System.Windows.Forms.ComboBox();
            this.Submit = new System.Windows.Forms.Button();
            this.CopyToBrowser = new System.Windows.Forms.Button();
            this.FillAutoGenertedData = new System.Windows.Forms.Button();
            this.SaveBrowserValuesToDB = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ruleAppliance = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fillPredefinedData = new System.Windows.Forms.Label();
            this.performLoop = new System.Windows.Forms.CheckBox();
            this.autoRestart = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerSaveData = new System.Windows.Forms.ComboBox();
            this.timerCopyToBrowser = new System.Windows.Forms.ComboBox();
            this.timerFillData = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timerExtractFromBrowser = new System.Windows.Forms.ComboBox();
            this.ExtractFormFromBrowser = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.domains = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.enableGeotaggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableExplorer11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkDBConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyrightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationURL
            // 
            this.navigationURL.FormattingEnabled = true;
            this.navigationURL.Items.AddRange(new object[] {
            "https://badoo.com/signin",
            "https://tinder.com/app/recs",
            "http://www.facebook.com",
            "http://www.amazon.de"});
            this.navigationURL.Location = new System.Drawing.Point(168, 32);
            this.navigationURL.Name = "navigationURL";
            this.navigationURL.Size = new System.Drawing.Size(838, 21);
            this.navigationURL.TabIndex = 0;
            this.navigationURL.Text = "Url to navigate";
            // 
            // Go
            // 
            this.Go.Location = new System.Drawing.Point(1019, 32);
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 183);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1100, 392);
            this.dataGridView1.TabIndex = 2;
            // 
            // BFN_ID
            // 
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Gray;
            this.BFN_ID.DefaultCellStyle = dataGridViewCellStyle17;
            this.BFN_ID.FillWeight = 50F;
            this.BFN_ID.Frozen = true;
            this.BFN_ID.HeaderText = "BFN_ID";
            this.BFN_ID.Name = "BFN_ID";
            this.BFN_ID.ReadOnly = true;
            this.BFN_ID.Width = 50;
            // 
            // TagAttribute
            // 
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Gray;
            this.TagAttribute.DefaultCellStyle = dataGridViewCellStyle18;
            this.TagAttribute.Frozen = true;
            this.TagAttribute.HeaderText = "Tag";
            this.TagAttribute.Name = "TagAttribute";
            this.TagAttribute.ReadOnly = true;
            this.TagAttribute.Width = 50;
            // 
            // ClassAttribute
            // 
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Gray;
            this.ClassAttribute.DefaultCellStyle = dataGridViewCellStyle19;
            this.ClassAttribute.Frozen = true;
            this.ClassAttribute.HeaderText = "Class";
            this.ClassAttribute.Name = "ClassAttribute";
            this.ClassAttribute.ReadOnly = true;
            // 
            // DataTestIdAttribute
            // 
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Gray;
            this.DataTestIdAttribute.DefaultCellStyle = dataGridViewCellStyle20;
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
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Gray;
            this.RoleAttribute.DefaultCellStyle = dataGridViewCellStyle21;
            this.RoleAttribute.Frozen = true;
            this.RoleAttribute.HeaderText = "Role";
            this.RoleAttribute.Name = "RoleAttribute";
            this.RoleAttribute.ReadOnly = true;
            // 
            // TypeAttribute
            // 
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Gray;
            this.TypeAttribute.DefaultCellStyle = dataGridViewCellStyle22;
            this.TypeAttribute.Frozen = true;
            this.TypeAttribute.HeaderText = "Type";
            this.TypeAttribute.Name = "TypeAttribute";
            this.TypeAttribute.ReadOnly = true;
            // 
            // NameAttribute
            // 
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Gray;
            this.NameAttribute.DefaultCellStyle = dataGridViewCellStyle23;
            this.NameAttribute.Frozen = true;
            this.NameAttribute.HeaderText = "Name";
            this.NameAttribute.Name = "NameAttribute";
            this.NameAttribute.ReadOnly = true;
            // 
            // IDAttribute
            // 
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Gray;
            this.IDAttribute.DefaultCellStyle = dataGridViewCellStyle24;
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
            // BFN_IDInvoke
            // 
            this.BFN_IDInvoke.FormattingEnabled = true;
            this.BFN_IDInvoke.Location = new System.Drawing.Point(46, 155);
            this.BFN_IDInvoke.Name = "BFN_IDInvoke";
            this.BFN_IDInvoke.Size = new System.Drawing.Size(62, 21);
            this.BFN_IDInvoke.TabIndex = 4;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(114, 155);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(56, 23);
            this.Submit.TabIndex = 5;
            this.Submit.Text = "invoke";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.InvokeFormSubmit);
            // 
            // CopyToBrowser
            // 
            this.CopyToBrowser.Location = new System.Drawing.Point(46, 88);
            this.CopyToBrowser.Name = "CopyToBrowser";
            this.CopyToBrowser.Size = new System.Drawing.Size(114, 27);
            this.CopyToBrowser.TabIndex = 6;
            this.CopyToBrowser.Text = "Copy to browser";
            this.CopyToBrowser.UseVisualStyleBackColor = true;
            this.CopyToBrowser.Click += new System.EventHandler(this.CopyDataToBrowser);
            // 
            // FillAutoGenertedData
            // 
            this.FillAutoGenertedData.Location = new System.Drawing.Point(46, 55);
            this.FillAutoGenertedData.Name = "FillAutoGenertedData";
            this.FillAutoGenertedData.Size = new System.Drawing.Size(114, 27);
            this.FillAutoGenertedData.TabIndex = 7;
            this.FillAutoGenertedData.Text = "Fill generted data";
            this.FillAutoGenertedData.UseVisualStyleBackColor = true;
            this.FillAutoGenertedData.Click += new System.EventHandler(this.FillAutoGenData);
            // 
            // SaveBrowserValuesToDB
            // 
            this.SaveBrowserValuesToDB.Location = new System.Drawing.Point(46, 121);
            this.SaveBrowserValuesToDB.Name = "SaveBrowserValuesToDB";
            this.SaveBrowserValuesToDB.Size = new System.Drawing.Size(114, 27);
            this.SaveBrowserValuesToDB.TabIndex = 9;
            this.SaveBrowserValuesToDB.Text = "Save browser values";
            this.SaveBrowserValuesToDB.UseVisualStyleBackColor = true;
            this.SaveBrowserValuesToDB.Click += new System.EventHandler(this.SaveBrowserFilledDataToDatabase);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ruleAppliance);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.fillPredefinedData);
            this.groupBox1.Controls.Add(this.performLoop);
            this.groupBox1.Controls.Add(this.autoRestart);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.timerSaveData);
            this.groupBox1.Controls.Add(this.timerCopyToBrowser);
            this.groupBox1.Controls.Add(this.timerFillData);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.timerExtractFromBrowser);
            this.groupBox1.Controls.Add(this.ExtractFormFromBrowser);
            this.groupBox1.Controls.Add(this.buttonStop);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.Submit);
            this.groupBox1.Controls.Add(this.SaveBrowserValuesToDB);
            this.groupBox1.Controls.Add(this.BFN_IDInvoke);
            this.groupBox1.Controls.Add(this.CopyToBrowser);
            this.groupBox1.Controls.Add(this.FillAutoGenertedData);
            this.groupBox1.Location = new System.Drawing.Point(12, 581);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 185);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perform recursively automated";
            // 
            // ruleAppliance
            // 
            this.ruleAppliance.FormattingEnabled = true;
            this.ruleAppliance.Location = new System.Drawing.Point(564, 19);
            this.ruleAppliance.Name = "ruleAppliance";
            this.ruleAppliance.Size = new System.Drawing.Size(238, 94);
            this.ruleAppliance.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "timer";
            // 
            // fillPredefinedData
            // 
            this.fillPredefinedData.AutoSize = true;
            this.fillPredefinedData.Location = new System.Drawing.Point(439, 71);
            this.fillPredefinedData.Name = "fillPredefinedData";
            this.fillPredefinedData.Size = new System.Drawing.Size(51, 13);
            this.fillPredefinedData.TabIndex = 24;
            this.fillPredefinedData.Text = "Rules set";
            // 
            // performLoop
            // 
            this.performLoop.AutoSize = true;
            this.performLoop.Checked = true;
            this.performLoop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.performLoop.Location = new System.Drawing.Point(442, 30);
            this.performLoop.Name = "performLoop";
            this.performLoop.Size = new System.Drawing.Size(84, 17);
            this.performLoop.TabIndex = 23;
            this.performLoop.Text = "perform loop";
            this.performLoop.UseVisualStyleBackColor = true;
            // 
            // autoRestart
            // 
            this.autoRestart.AutoSize = true;
            this.autoRestart.Location = new System.Drawing.Point(442, 51);
            this.autoRestart.Name = "autoRestart";
            this.autoRestart.Size = new System.Drawing.Size(108, 17);
            this.autoRestart.TabIndex = 22;
            this.autoRestart.Text = "restart after crash";
            this.autoRestart.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "2";
            // 
            // timerSaveData
            // 
            this.timerSaveData.FormattingEnabled = true;
            this.timerSaveData.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.timerSaveData.Location = new System.Drawing.Point(170, 125);
            this.timerSaveData.Name = "timerSaveData";
            this.timerSaveData.Size = new System.Drawing.Size(37, 21);
            this.timerSaveData.TabIndex = 17;
            this.timerSaveData.Text = "1";
            // 
            // timerCopyToBrowser
            // 
            this.timerCopyToBrowser.FormattingEnabled = true;
            this.timerCopyToBrowser.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.timerCopyToBrowser.Location = new System.Drawing.Point(170, 92);
            this.timerCopyToBrowser.Name = "timerCopyToBrowser";
            this.timerCopyToBrowser.Size = new System.Drawing.Size(37, 21);
            this.timerCopyToBrowser.TabIndex = 16;
            this.timerCopyToBrowser.Text = "1";
            // 
            // timerFillData
            // 
            this.timerFillData.FormattingEnabled = true;
            this.timerFillData.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.timerFillData.Location = new System.Drawing.Point(170, 59);
            this.timerFillData.Name = "timerFillData";
            this.timerFillData.Size = new System.Drawing.Size(37, 21);
            this.timerFillData.TabIndex = 15;
            this.timerFillData.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "1";
            // 
            // timerExtractFromBrowser
            // 
            this.timerExtractFromBrowser.FormattingEnabled = true;
            this.timerExtractFromBrowser.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.timerExtractFromBrowser.Location = new System.Drawing.Point(170, 26);
            this.timerExtractFromBrowser.Name = "timerExtractFromBrowser";
            this.timerExtractFromBrowser.Size = new System.Drawing.Size(37, 21);
            this.timerExtractFromBrowser.TabIndex = 13;
            this.timerExtractFromBrowser.Text = "1";
            // 
            // ExtractFormFromBrowser
            // 
            this.ExtractFormFromBrowser.Location = new System.Drawing.Point(46, 22);
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
            this.buttonStop.Location = new System.Drawing.Point(502, 0);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(56, 22);
            this.buttonStop.TabIndex = 12;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.StopTheNavigation);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(442, 0);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(54, 22);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.StartTheNavigation);
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(12, 32);
            this.treeView1.Name = "treeView1";
            treeNode17.Name = "input-type-hidden";
            treeNode17.Text = "hidden";
            treeNode18.Name = "input";
            treeNode18.Text = "input";
            treeNode19.Name = "button-type-submit";
            treeNode19.Text = "submit";
            treeNode20.Name = "button";
            treeNode20.Text = "button";
            treeNode21.Name = "div-role-button";
            treeNode21.Text = "button";
            treeNode22.Name = "div";
            treeNode22.Text = "div";
            treeNode23.Name = "a-role-button";
            treeNode23.Text = "button";
            treeNode24.Name = "a";
            treeNode24.Text = "a";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode20,
            treeNode22,
            treeNode24});
            this.treeView1.Size = new System.Drawing.Size(146, 134);
            this.treeView1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Load specific settings";
            // 
            // domains
            // 
            this.domains.FormattingEnabled = true;
            this.domains.Location = new System.Drawing.Point(168, 84);
            this.domains.Name = "domains";
            this.domains.Size = new System.Drawing.Size(125, 82);
            this.domains.TabIndex = 16;
            this.domains.Click += new System.EventHandler(this.LoadDomainSettings);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1124, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableGeotaggingToolStripMenuItem,
            this.enableExplorer11ToolStripMenuItem,
            this.checkDBConnectionToolStripMenuItem,
            this.infoToolStripMenuItem1,
            this.copyrightToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(40, 20);
            this.toolStripMenuItem1.Text = "Info";
            // 
            // enableGeotaggingToolStripMenuItem
            // 
            this.enableGeotaggingToolStripMenuItem.Name = "enableGeotaggingToolStripMenuItem";
            this.enableGeotaggingToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.enableGeotaggingToolStripMenuItem.Text = "Enable Geotagging";
            this.enableGeotaggingToolStripMenuItem.Click += new System.EventHandler(this.EnableGeotagging);
            // 
            // enableExplorer11ToolStripMenuItem
            // 
            this.enableExplorer11ToolStripMenuItem.Name = "enableExplorer11ToolStripMenuItem";
            this.enableExplorer11ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.enableExplorer11ToolStripMenuItem.Text = "Enable Explorer 11";
            this.enableExplorer11ToolStripMenuItem.Click += new System.EventHandler(this.AddToRegistry);
            // 
            // checkDBConnectionToolStripMenuItem
            // 
            this.checkDBConnectionToolStripMenuItem.Name = "checkDBConnectionToolStripMenuItem";
            this.checkDBConnectionToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.checkDBConnectionToolStripMenuItem.Text = "Check DB Connection";
            this.checkDBConnectionToolStripMenuItem.Click += new System.EventHandler(this.CheckDBConnection);
            // 
            // infoToolStripMenuItem1
            // 
            this.infoToolStripMenuItem1.Name = "infoToolStripMenuItem1";
            this.infoToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.infoToolStripMenuItem1.Text = "Info";
            // 
            // copyrightToolStripMenuItem
            // 
            this.copyrightToolStripMenuItem.Name = "copyrightToolStripMenuItem";
            this.copyrightToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.copyrightToolStripMenuItem.Text = "Copyright";
            // 
            // FormNavi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 770);
            this.Controls.Add(this.domains);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Go);
            this.Controls.Add(this.navigationURL);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormNavi";
            this.Text = "Automated formular extractor and formular submitter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public ComboBox navigationURL;
        public Button Go;
        public DataGridView dataGridView1;
        public ComboBox BFN_IDInvoke;
        public Button Submit;
        public Button CopyToBrowser;
        public Button FillAutoGenertedData;
        public Button SaveBrowserValuesToDB;
        public GroupBox groupBox1;
        public Button buttonStart;
        public BackgroundWorker backgroundWorker1;
        public Button buttonStop;
        public Button ExtractFormFromBrowser;
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
        public TreeView treeView1;
        public Label label2;
        public ComboBox timerExtractFromBrowser;
        public Label label3;
        public Label fillPredefinedData;
        public CheckBox performLoop;
        public CheckBox autoRestart;
        public Label label6;
        public Label label5;
        public Label label4;
        public Label label1;
        public ComboBox timerSaveData;
        public ComboBox timerCopyToBrowser;
        public ComboBox timerFillData;
        public Label label7;
        public ListBox domains;
        public CheckedListBox ruleAppliance;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem enableGeotaggingToolStripMenuItem;
        private ToolStripMenuItem enableExplorer11ToolStripMenuItem;
        private ToolStripMenuItem checkDBConnectionToolStripMenuItem;
        private ToolStripMenuItem infoToolStripMenuItem1;
        private ToolStripMenuItem copyrightToolStripMenuItem;
    }
}

