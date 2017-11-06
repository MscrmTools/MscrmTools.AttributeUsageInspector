namespace MscrmTools.AttributeUsageInspector
{
    partial class FilterAttributesDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbStandard = new System.Windows.Forms.RadioButton();
            this.rbChoose = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbAttributesSelection = new System.Windows.Forms.GroupBox();
            this.lvAttributes = new System.Windows.Forms.ListView();
            this.chDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.llNone = new System.Windows.Forms.LinkLabel();
            this.llSelectAll = new System.Windows.Forms.LinkLabel();
            this.llCustom = new System.Windows.Forms.LinkLabel();
            this.llStandard = new System.Windows.Forms.LinkLabel();
            this.llInvertSelection = new System.Windows.Forms.LinkLabel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbAttributesSelection.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 353);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(454, 39);
            this.panel2.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(290, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(370, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 39);
            this.panel1.TabIndex = 2;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(2, 6);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(131, 25);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Filter attributes";
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(3, 5);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(36, 17);
            this.rbAll.TabIndex = 4;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(3, 28);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(129, 17);
            this.rbCustom.TabIndex = 5;
            this.rbCustom.Text = "Only custom attributes";
            this.rbCustom.UseVisualStyleBackColor = true;
            // 
            // rbStandard
            // 
            this.rbStandard.AutoSize = true;
            this.rbStandard.Location = new System.Drawing.Point(3, 51);
            this.rbStandard.Name = "rbStandard";
            this.rbStandard.Size = new System.Drawing.Size(136, 17);
            this.rbStandard.TabIndex = 6;
            this.rbStandard.Text = "Only standard attributes";
            this.rbStandard.UseVisualStyleBackColor = true;
            // 
            // rbChoose
            // 
            this.rbChoose.AutoSize = true;
            this.rbChoose.Location = new System.Drawing.Point(3, 74);
            this.rbChoose.Name = "rbChoose";
            this.rbChoose.Size = new System.Drawing.Size(95, 17);
            this.rbChoose.TabIndex = 7;
            this.rbChoose.Text = "Let me choose";
            this.rbChoose.UseVisualStyleBackColor = true;
            this.rbChoose.CheckedChanged += new System.EventHandler(this.rbChoose_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbCustom);
            this.panel3.Controls.Add(this.rbAll);
            this.panel3.Controls.Add(this.rbChoose);
            this.panel3.Controls.Add(this.rbStandard);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 39);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(454, 100);
            this.panel3.TabIndex = 9;
            // 
            // gbAttributesSelection
            // 
            this.gbAttributesSelection.Controls.Add(this.lvAttributes);
            this.gbAttributesSelection.Controls.Add(this.panel4);
            this.gbAttributesSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAttributesSelection.Enabled = false;
            this.gbAttributesSelection.Location = new System.Drawing.Point(0, 139);
            this.gbAttributesSelection.Name = "gbAttributesSelection";
            this.gbAttributesSelection.Size = new System.Drawing.Size(454, 214);
            this.gbAttributesSelection.TabIndex = 10;
            this.gbAttributesSelection.TabStop = false;
            this.gbAttributesSelection.Text = "Select attributes to audit";
            // 
            // lvAttributes
            // 
            this.lvAttributes.CheckBoxes = true;
            this.lvAttributes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDisplayName,
            this.chLogicalName});
            this.lvAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAttributes.Location = new System.Drawing.Point(3, 34);
            this.lvAttributes.Name = "lvAttributes";
            this.lvAttributes.Size = new System.Drawing.Size(448, 177);
            this.lvAttributes.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvAttributes.TabIndex = 2;
            this.lvAttributes.UseCompatibleStateImageBehavior = false;
            this.lvAttributes.View = System.Windows.Forms.View.Details;
            this.lvAttributes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvAttributes_ColumnClick);
            // 
            // chDisplayName
            // 
            this.chDisplayName.Text = "Display name";
            this.chDisplayName.Width = 150;
            // 
            // chLogicalName
            // 
            this.chLogicalName.Text = "Logical name";
            this.chLogicalName.Width = 150;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.llInvertSelection);
            this.panel4.Controls.Add(this.llStandard);
            this.panel4.Controls.Add(this.llCustom);
            this.panel4.Controls.Add(this.llNone);
            this.panel4.Controls.Add(this.llSelectAll);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(448, 18);
            this.panel4.TabIndex = 1;
            // 
            // llNone
            // 
            this.llNone.AutoSize = true;
            this.llNone.Dock = System.Windows.Forms.DockStyle.Right;
            this.llNone.Location = new System.Drawing.Point(334, 0);
            this.llNone.Name = "llNone";
            this.llNone.Size = new System.Drawing.Size(64, 13);
            this.llNone.TabIndex = 1;
            this.llNone.TabStop = true;
            this.llNone.Text = "Select none";
            this.llNone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llNone_LinkClicked);
            // 
            // llSelectAll
            // 
            this.llSelectAll.AutoSize = true;
            this.llSelectAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.llSelectAll.Location = new System.Drawing.Point(398, 0);
            this.llSelectAll.Name = "llSelectAll";
            this.llSelectAll.Size = new System.Drawing.Size(50, 13);
            this.llSelectAll.TabIndex = 0;
            this.llSelectAll.TabStop = true;
            this.llSelectAll.Text = "Select all";
            this.llSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSelectAll_LinkClicked);
            // 
            // llCustom
            // 
            this.llCustom.AutoSize = true;
            this.llCustom.Dock = System.Windows.Forms.DockStyle.Right;
            this.llCustom.Location = new System.Drawing.Point(260, 0);
            this.llCustom.Name = "llCustom";
            this.llCustom.Size = new System.Drawing.Size(74, 13);
            this.llCustom.TabIndex = 3;
            this.llCustom.TabStop = true;
            this.llCustom.Text = "Select custom";
            this.llCustom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCustom_LinkClicked);
            // 
            // llStandard
            // 
            this.llStandard.AutoSize = true;
            this.llStandard.Dock = System.Windows.Forms.DockStyle.Right;
            this.llStandard.Location = new System.Drawing.Point(179, 0);
            this.llStandard.Name = "llStandard";
            this.llStandard.Size = new System.Drawing.Size(81, 13);
            this.llStandard.TabIndex = 4;
            this.llStandard.TabStop = true;
            this.llStandard.Text = "Select standard";
            this.llStandard.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llStandard_LinkClicked);
            // 
            // llInvertSelection
            // 
            this.llInvertSelection.AutoSize = true;
            this.llInvertSelection.Dock = System.Windows.Forms.DockStyle.Right;
            this.llInvertSelection.Location = new System.Drawing.Point(100, 0);
            this.llInvertSelection.Name = "llInvertSelection";
            this.llInvertSelection.Size = new System.Drawing.Size(79, 13);
            this.llInvertSelection.TabIndex = 5;
            this.llInvertSelection.TabStop = true;
            this.llInvertSelection.Text = "Invert selection";
            // 
            // FilterAttributesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 392);
            this.Controls.Add(this.gbAttributesSelection);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FilterAttributesDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.gbAttributesSelection.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rbStandard;
        private System.Windows.Forms.RadioButton rbChoose;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox gbAttributesSelection;
        private System.Windows.Forms.ListView lvAttributes;
        private System.Windows.Forms.ColumnHeader chDisplayName;
        private System.Windows.Forms.ColumnHeader chLogicalName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.LinkLabel llNone;
        private System.Windows.Forms.LinkLabel llSelectAll;
        private System.Windows.Forms.LinkLabel llStandard;
        private System.Windows.Forms.LinkLabel llCustom;
        private System.Windows.Forms.LinkLabel llInvertSelection;
    }
}