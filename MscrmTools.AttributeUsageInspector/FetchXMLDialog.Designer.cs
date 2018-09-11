namespace MscrmTools.AttributeUsageInspector
{
    partial class FetchXMLDialog
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rTxtB_FetchXMLQuery = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_userviews = new System.Windows.Forms.ComboBox();
            this.label_userviews = new System.Windows.Forms.Label();
            this.cmb_systemViews = new System.Windows.Forms.ComboBox();
            this.label_systemviews = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_validationResult = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.txb_validationResult);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 569);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(617, 69);
            this.panel2.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(371, 20);
            this.btnOK.Margin = new System.Windows.Forms.Padding(5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 35);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(491, 20);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rTxtB_FetchXMLQuery
            // 
            this.rTxtB_FetchXMLQuery.BackColor = System.Drawing.Color.White;
            this.rTxtB_FetchXMLQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtB_FetchXMLQuery.Location = new System.Drawing.Point(10, 10);
            this.rTxtB_FetchXMLQuery.Name = "rTxtB_FetchXMLQuery";
            this.rTxtB_FetchXMLQuery.Size = new System.Drawing.Size(597, 360);
            this.rTxtB_FetchXMLQuery.TabIndex = 3;
            this.rTxtB_FetchXMLQuery.Text = "Loading views... Please wait";
            this.rTxtB_FetchXMLQuery.TextChanged += new System.EventHandler(this.rTxtB_FetchXMLQuery_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.cmb_userviews);
            this.splitContainer1.Panel1.Controls.Add(this.label_userviews);
            this.splitContainer1.Panel1.Controls.Add(this.cmb_systemViews);
            this.splitContainer1.Panel1.Controls.Add(this.label_systemviews);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rTxtB_FetchXMLQuery);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Size = new System.Drawing.Size(617, 569);
            this.splitContainer1.SplitterDistance = 185;
            this.splitContainer1.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(316, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Then click OK to continue or Cancel to stop.";
            // 
            // cmb_userviews
            // 
            this.cmb_userviews.FormattingEnabled = true;
            this.cmb_userviews.Location = new System.Drawing.Point(134, 128);
            this.cmb_userviews.Name = "cmb_userviews";
            this.cmb_userviews.Size = new System.Drawing.Size(470, 28);
            this.cmb_userviews.TabIndex = 6;
            this.cmb_userviews.SelectedIndexChanged += new System.EventHandler(this.cmb_userviews_SelectedIndexChanged);
            // 
            // label_userviews
            // 
            this.label_userviews.AutoSize = true;
            this.label_userviews.Location = new System.Drawing.Point(35, 136);
            this.label_userviews.Name = "label_userviews";
            this.label_userviews.Size = new System.Drawing.Size(93, 20);
            this.label_userviews.TabIndex = 5;
            this.label_userviews.Text = "User Views:";
            // 
            // cmb_systemViews
            // 
            this.cmb_systemViews.FormattingEnabled = true;
            this.cmb_systemViews.Location = new System.Drawing.Point(134, 93);
            this.cmb_systemViews.Name = "cmb_systemViews";
            this.cmb_systemViews.Size = new System.Drawing.Size(470, 28);
            this.cmb_systemViews.TabIndex = 4;
            this.cmb_systemViews.SelectedIndexChanged += new System.EventHandler(this.cmb_systemViews_SelectedIndexChanged);
            // 
            // label_systemviews
            // 
            this.label_systemviews.AutoSize = true;
            this.label_systemviews.Location = new System.Drawing.Point(16, 98);
            this.label_systemviews.Name = "label_systemviews";
            this.label_systemviews.Size = new System.Drawing.Size(112, 20);
            this.label_systemviews.TabIndex = 2;
            this.label_systemviews.Text = "System Views:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose a view or just paste your FetchXML query in this editor.";
            // 
            // txb_validationResult
            // 
            this.txb_validationResult.BackColor = System.Drawing.SystemColors.Control;
            this.txb_validationResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_validationResult.Location = new System.Drawing.Point(10, 20);
            this.txb_validationResult.Multiline = true;
            this.txb_validationResult.Name = "txb_validationResult";
            this.txb_validationResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txb_validationResult.Size = new System.Drawing.Size(347, 35);
            this.txb_validationResult.TabIndex = 6;
            this.txb_validationResult.Text = "Validating FetchXML query ...";
            // 
            // FetchXMLDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 638);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Name = "FetchXMLDialog";
            this.ShowIcon = false;
            this.Text = "FetchXML Query";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RichTextBox rTxtB_FetchXMLQuery;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_systemviews;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_userviews;
        private System.Windows.Forms.Label label_userviews;
        private System.Windows.Forms.ComboBox cmb_systemViews;
        private System.Windows.Forms.TextBox txb_validationResult;
    }
}