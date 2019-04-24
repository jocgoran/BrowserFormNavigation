using System.Reflection;

namespace BrowserFormNavi.View
{
    partial class Info
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Product = new System.Windows.Forms.Label();
            this.Softility = new System.Windows.Forms.Label();
            this.Company = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // product
            // 
            this.Product.AutoSize = true;
            this.Product.Location = new System.Drawing.Point(6, 29);
            this.Product.Name = "product";
            this.Product.Size = new System.Drawing.Size(120, 13);
            this.Product.TabIndex = 0;
            this.Product.Text = "Browser form navigation";
            // 
            // version
            // 
            this.Softility.AutoSize = true;
            this.Softility.Location = new System.Drawing.Point(6, 69);
            this.Softility.Name = "version";
            this.Softility.Size = new System.Drawing.Size(42, 13);
            this.Softility.TabIndex = 1;
            this.Softility.Text = "Version" + Assembly.GetEntryAssembly().GetName().Version;
            // 
            // company
            // 
            this.Company.AutoSize = true;
            this.Company.Location = new System.Drawing.Point(6, 111);
            this.Company.Name = "company";
            this.Company.Size = new System.Drawing.Size(94, 13);
            this.Company.TabIndex = 2;
            this.Company.Text = "Created by Softility";

            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Product);
            this.groupBox1.Controls.Add(this.Softility);
            this.groupBox1.Controls.Add(this.Company);
            this.groupBox1.Location = new System.Drawing.Point(13, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 144);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(161, 166);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Info";
            this.Text = "Info";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Softility;
        private System.Windows.Forms.Label Product;
        private System.Windows.Forms.Label Company;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}