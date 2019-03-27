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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("type=hidden");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("input", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("type=submit");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("button", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("role=button");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("div", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("role=button");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("data-testid=UFI2ReactionLink");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("a", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
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
            this.AlgoInvoke = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BFN_IDInvoke = new System.Windows.Forms.ComboBox();
            this.Submit = new System.Windows.Forms.Button();
            this.CopyToBrowser = new System.Windows.Forms.Button();
            this.FillAutoGenertedData = new System.Windows.Forms.Button();
            this.SaveBrowserValuesToDB = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InvokationDone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.relaodIFNoInvoke = new System.Windows.Forms.CheckBox();
            this.ruleAppliance = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fillPredefinedData = new System.Windows.Forms.Label();
            this.performLoop = new System.Windows.Forms.CheckBox();
            this.autoRestart = new System.Windows.Forms.CheckBox();
            this.timerSaveData = new System.Windows.Forms.ComboBox();
            this.timerCopyToBrowser = new System.Windows.Forms.ComboBox();
            this.timerFillData = new System.Windows.Forms.ComboBox();
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
            "http://www.amazon.de",
            "https://www.aliexpress.com"});
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
            this.CheckedAttribute,
            this.AlgoInvoke});
            this.dataGridView1.Location = new System.Drawing.Point(12, 183);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1201, 392);
            this.dataGridView1.TabIndex = 2;
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
            // AlgoInvoke
            // 
            this.AlgoInvoke.FillWeight = 50F;
            this.AlgoInvoke.HeaderText = "AlgoInvoke";
            this.AlgoInvoke.Name = "AlgoInvoke";
            this.AlgoInvoke.ReadOnly = true;
            // 
            // BFN_IDInvoke
            // 
            this.BFN_IDInvoke.FormattingEnabled = true;
            this.BFN_IDInvoke.Location = new System.Drawing.Point(82, 157);
            this.BFN_IDInvoke.Name = "BFN_IDInvoke";
            this.BFN_IDInvoke.Size = new System.Drawing.Size(62, 21);
            this.BFN_IDInvoke.TabIndex = 4;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(150, 157);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(56, 23);
            this.Submit.TabIndex = 5;
            this.Submit.Text = "invoke";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.InvokeFormSubmit);
            // 
            // CopyToBrowser
            // 
            this.CopyToBrowser.Location = new System.Drawing.Point(82, 90);
            this.CopyToBrowser.Name = "CopyToBrowser";
            this.CopyToBrowser.Size = new System.Drawing.Size(114, 27);
            this.CopyToBrowser.TabIndex = 6;
            this.CopyToBrowser.Text = "Copy to browser";
            this.CopyToBrowser.UseVisualStyleBackColor = true;
            this.CopyToBrowser.Click += new System.EventHandler(this.CopyDataToBrowser);
            // 
            // FillAutoGenertedData
            // 
            this.FillAutoGenertedData.Location = new System.Drawing.Point(82, 57);
            this.FillAutoGenertedData.Name = "FillAutoGenertedData";
            this.FillAutoGenertedData.Size = new System.Drawing.Size(114, 27);
            this.FillAutoGenertedData.TabIndex = 7;
            this.FillAutoGenertedData.Text = "Fill generted data";
            this.FillAutoGenertedData.UseVisualStyleBackColor = true;
            this.FillAutoGenertedData.Click += new System.EventHandler(this.FillAutoGenData);
            // 
            // SaveBrowserValuesToDB
            // 
            this.SaveBrowserValuesToDB.Location = new System.Drawing.Point(82, 123);
            this.SaveBrowserValuesToDB.Name = "SaveBrowserValuesToDB";
            this.SaveBrowserValuesToDB.Size = new System.Drawing.Size(114, 27);
            this.SaveBrowserValuesToDB.TabIndex = 9;
            this.SaveBrowserValuesToDB.Text = "Save browser values";
            this.SaveBrowserValuesToDB.UseVisualStyleBackColor = true;
            this.SaveBrowserValuesToDB.Click += new System.EventHandler(this.SaveBrowserFilledDataToDatabase);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InvokationDone);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.relaodIFNoInvoke);
            this.groupBox1.Controls.Add(this.ruleAppliance);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.fillPredefinedData);
            this.groupBox1.Controls.Add(this.performLoop);
            this.groupBox1.Controls.Add(this.autoRestart);
            this.groupBox1.Controls.Add(this.timerSaveData);
            this.groupBox1.Controls.Add(this.timerCopyToBrowser);
            this.groupBox1.Controls.Add(this.timerFillData);
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
            // InvokationDone
            // 
            this.InvokationDone.Location = new System.Drawing.Point(305, 160);
            this.InvokationDone.Name = "InvokationDone";
            this.InvokationDone.ReadOnly = true;
            this.InvokationDone.Size = new System.Drawing.Size(60, 20);
            this.InvokationDone.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(215, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Invokation done";
            // 
            // relaodIFNoInvoke
            // 
            this.relaodIFNoInvoke.AutoSize = true;
            this.relaodIFNoInvoke.Location = new System.Drawing.Point(442, 74);
            this.relaodIFNoInvoke.Name = "relaodIFNoInvoke";
            this.relaodIFNoInvoke.Size = new System.Drawing.Size(114, 17);
            this.relaodIFNoInvoke.TabIndex = 27;
            this.relaodIFNoInvoke.Text = "reload if no Invoke";
            this.relaodIFNoInvoke.UseVisualStyleBackColor = true;
            // 
            // ruleAppliance
            // 
            this.ruleAppliance.FormattingEnabled = true;
            this.ruleAppliance.Location = new System.Drawing.Point(564, 35);
            this.ruleAppliance.Name = "ruleAppliance";
            this.ruleAppliance.Size = new System.Drawing.Size(238, 94);
            this.ruleAppliance.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "wait";
            // 
            // fillPredefinedData
            // 
            this.fillPredefinedData.AutoSize = true;
            this.fillPredefinedData.Location = new System.Drawing.Point(564, 16);
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
            // timerSaveData
            // 
            this.timerSaveData.FormattingEnabled = true;
            this.timerSaveData.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.timerSaveData.Location = new System.Drawing.Point(39, 127);
            this.timerSaveData.Name = "timerSaveData";
            this.timerSaveData.Size = new System.Drawing.Size(37, 21);
            this.timerSaveData.TabIndex = 17;
            this.timerSaveData.Text = "0";
            // 
            // timerCopyToBrowser
            // 
            this.timerCopyToBrowser.FormattingEnabled = true;
            this.timerCopyToBrowser.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.timerCopyToBrowser.Location = new System.Drawing.Point(39, 94);
            this.timerCopyToBrowser.Name = "timerCopyToBrowser";
            this.timerCopyToBrowser.Size = new System.Drawing.Size(37, 21);
            this.timerCopyToBrowser.TabIndex = 16;
            this.timerCopyToBrowser.Text = "0";
            // 
            // timerFillData
            // 
            this.timerFillData.FormattingEnabled = true;
            this.timerFillData.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.timerFillData.Location = new System.Drawing.Point(39, 61);
            this.timerFillData.Name = "timerFillData";
            this.timerFillData.Size = new System.Drawing.Size(37, 21);
            this.timerFillData.TabIndex = 15;
            this.timerFillData.Text = "0";
            // 
            // timerExtractFromBrowser
            // 
            this.timerExtractFromBrowser.FormattingEnabled = true;
            this.timerExtractFromBrowser.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.timerExtractFromBrowser.Location = new System.Drawing.Point(39, 26);
            this.timerExtractFromBrowser.Name = "timerExtractFromBrowser";
            this.timerExtractFromBrowser.Size = new System.Drawing.Size(37, 21);
            this.timerExtractFromBrowser.TabIndex = 13;
            this.timerExtractFromBrowser.Text = "0";
            // 
            // ExtractFormFromBrowser
            // 
            this.ExtractFormFromBrowser.Location = new System.Drawing.Point(82, 24);
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
            treeNode1.Name = "input-type-hidden";
            treeNode1.Text = "type=hidden";
            treeNode2.Name = "input";
            treeNode2.Text = "input";
            treeNode3.Name = "button-type-submit";
            treeNode3.Text = "type=submit";
            treeNode4.Name = "button";
            treeNode4.Text = "button";
            treeNode5.Name = "div-role-button";
            treeNode5.Text = "role=button";
            treeNode6.Name = "div";
            treeNode6.Text = "div";
            treeNode7.Name = "a-role-button";
            treeNode7.Text = "role=button";
            treeNode8.Name = "a-data-testId-UFI2ReactionLink";
            treeNode8.Text = "data-testid=UFI2ReactionLink";
            treeNode9.Name = "a";
            treeNode9.Text = "a";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode6,
            treeNode9});
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
            this.menuStrip1.Size = new System.Drawing.Size(1225, 24);
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
            this.ClientSize = new System.Drawing.Size(1225, 770);
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
        public TreeView treeView1;
        public Label label2;
        public ComboBox timerExtractFromBrowser;
        public Label fillPredefinedData;
        public CheckBox performLoop;
        public CheckBox autoRestart;
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
        public CheckBox relaodIFNoInvoke;
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
        private DataGridViewTextBoxColumn AlgoInvoke;
        private Label label8;
        public TextBox InvokationDone;
    }
}

