using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MscrmTools.AttributeUsageInspector
{
    public partial class PluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginControl));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadEntities = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.scInspector = new System.Windows.Forms.SplitContainer();
            this.gbEntities = new System.Windows.Forms.GroupBox();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.pnlAggregateQueryRecordLimit = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.llDiscoWithStandardQueries = new System.Windows.Forms.LinkLabel();
            this.llHowToUpdateAggregateQueryRecordLimit = new System.Windows.Forms.LinkLabel();
            this.lblWhatNextOnline = new System.Windows.Forms.Label();
            this.lblWathNextOnPremise = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAggregateQueryRecordLimit = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvEntities = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlFilterInfo = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFilterInfo = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.clDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLogicalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clOnForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInspector)).BeginInit();
            this.scInspector.Panel1.SuspendLayout();
            this.scInspector.Panel2.SuspendLayout();
            this.scInspector.SuspendLayout();
            this.gbEntities.SuspendLayout();
            this.gbData.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlAggregateQueryRecordLimit.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlFilterInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.toolStripSeparator1,
            this.tsbLoadEntities,
            this.toolStripSeparator2,
            this.tsbExportToExcel,
            this.toolStripSeparator3,
            this.tsbSettings});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1631, 25);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(23, 22);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbLoadEntities
            // 
            this.tsbLoadEntities.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadEntities.Image")));
            this.tsbLoadEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadEntities.Name = "tsbLoadEntities";
            this.tsbLoadEntities.Size = new System.Drawing.Size(94, 22);
            this.tsbLoadEntities.Text = "Load Entities";
            this.tsbLoadEntities.Click += new System.EventHandler(this.tsbLoadEntities_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExportToExcel
            // 
            this.tsbExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportToExcel.Image")));
            this.tsbExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportToExcel.Name = "tsbExportToExcel";
            this.tsbExportToExcel.Size = new System.Drawing.Size(105, 22);
            this.tsbExportToExcel.Text = "Export To Excel";
            this.tsbExportToExcel.ToolTipText = "Export checked entities data usage to Excel Spreadsheet";
            this.tsbExportToExcel.Click += new System.EventHandler(this.tsbExportToExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSettings
            // 
            this.tsbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbSettings.Image")));
            this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Size = new System.Drawing.Size(23, 22);
            this.tsbSettings.Text = "Settings";
            this.tsbSettings.ToolTipText = "Define number of records returned per call";
            this.tsbSettings.Click += new System.EventHandler(this.tsbSettings_Click);
            // 
            // scInspector
            // 
            this.scInspector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scInspector.Location = new System.Drawing.Point(0, 25);
            this.scInspector.Name = "scInspector";
            // 
            // scInspector.Panel1
            // 
            this.scInspector.Panel1.Controls.Add(this.gbEntities);
            // 
            // scInspector.Panel2
            // 
            this.scInspector.Panel2.Controls.Add(this.gbData);
            this.scInspector.Size = new System.Drawing.Size(1631, 941);
            this.scInspector.SplitterDistance = 543;
            this.scInspector.TabIndex = 1;
            // 
            // gbEntities
            // 
            this.gbEntities.Controls.Add(this.lvEntities);
            this.gbEntities.Controls.Add(this.panel2);
            this.gbEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEntities.Location = new System.Drawing.Point(0, 0);
            this.gbEntities.Name = "gbEntities";
            this.gbEntities.Size = new System.Drawing.Size(543, 941);
            this.gbEntities.TabIndex = 0;
            this.gbEntities.TabStop = false;
            this.gbEntities.Text = "Entities";
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.dgvData);
            this.gbData.Controls.Add(this.pnlFilterInfo);
            this.gbData.Controls.Add(this.panel1);
            this.gbData.Controls.Add(this.pnlAggregateQueryRecordLimit);
            this.gbData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbData.Location = new System.Drawing.Point(0, 0);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(1084, 941);
            this.gbData.TabIndex = 1;
            this.gbData.TabStop = false;
            this.gbData.Text = "Data";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 918);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1078, 20);
            this.panel1.TabIndex = 1;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCount.Location = new System.Drawing.Point(0, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 13);
            this.lblCount.TabIndex = 0;
            this.lblCount.Tag = "Statistics based on {0} records";
            // 
            // pnlAggregateQueryRecordLimit
            // 
            this.pnlAggregateQueryRecordLimit.BackColor = System.Drawing.Color.White;
            this.pnlAggregateQueryRecordLimit.Controls.Add(this.panel3);
            this.pnlAggregateQueryRecordLimit.Controls.Add(this.lblWhatNextOnline);
            this.pnlAggregateQueryRecordLimit.Controls.Add(this.lblWathNextOnPremise);
            this.pnlAggregateQueryRecordLimit.Controls.Add(this.label3);
            this.pnlAggregateQueryRecordLimit.Controls.Add(this.label2);
            this.pnlAggregateQueryRecordLimit.Controls.Add(this.label1);
            this.pnlAggregateQueryRecordLimit.Controls.Add(this.lblAggregateQueryRecordLimit);
            this.pnlAggregateQueryRecordLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAggregateQueryRecordLimit.Location = new System.Drawing.Point(3, 16);
            this.pnlAggregateQueryRecordLimit.Name = "pnlAggregateQueryRecordLimit";
            this.pnlAggregateQueryRecordLimit.Size = new System.Drawing.Size(1078, 922);
            this.pnlAggregateQueryRecordLimit.TabIndex = 2;
            this.pnlAggregateQueryRecordLimit.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.llDiscoWithStandardQueries);
            this.panel3.Controls.Add(this.llHowToUpdateAggregateQueryRecordLimit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 545);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1078, 100);
            this.panel3.TabIndex = 6;
            // 
            // llDiscoWithStandardQueries
            // 
            this.llDiscoWithStandardQueries.Dock = System.Windows.Forms.DockStyle.Top;
            this.llDiscoWithStandardQueries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llDiscoWithStandardQueries.Location = new System.Drawing.Point(0, 30);
            this.llDiscoWithStandardQueries.Name = "llDiscoWithStandardQueries";
            this.llDiscoWithStandardQueries.Size = new System.Drawing.Size(1078, 30);
            this.llDiscoWithStandardQueries.TabIndex = 1;
            this.llDiscoWithStandardQueries.TabStop = true;
            this.llDiscoWithStandardQueries.Text = "Perform data discovery using standard queries";
            this.llDiscoWithStandardQueries.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llDiscoWithStandardQueries.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llDiscoWithStandardQueries_LinkClicked);
            // 
            // llHowToUpdateAggregateQueryRecordLimit
            // 
            this.llHowToUpdateAggregateQueryRecordLimit.Dock = System.Windows.Forms.DockStyle.Top;
            this.llHowToUpdateAggregateQueryRecordLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llHowToUpdateAggregateQueryRecordLimit.Location = new System.Drawing.Point(0, 0);
            this.llHowToUpdateAggregateQueryRecordLimit.Name = "llHowToUpdateAggregateQueryRecordLimit";
            this.llHowToUpdateAggregateQueryRecordLimit.Size = new System.Drawing.Size(1078, 30);
            this.llHowToUpdateAggregateQueryRecordLimit.TabIndex = 0;
            this.llHowToUpdateAggregateQueryRecordLimit.TabStop = true;
            this.llHowToUpdateAggregateQueryRecordLimit.Text = "Update AggregateQueryRecordLimit setting";
            this.llHowToUpdateAggregateQueryRecordLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llHowToUpdateAggregateQueryRecordLimit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llHowToUpdateAggregateQueryRecordLimit_LinkClicked);
            // 
            // lblWhatNextOnline
            // 
            this.lblWhatNextOnline.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWhatNextOnline.Location = new System.Drawing.Point(0, 432);
            this.lblWhatNextOnline.Name = "lblWhatNextOnline";
            this.lblWhatNextOnline.Size = new System.Drawing.Size(1078, 113);
            this.lblWhatNextOnline.TabIndex = 5;
            this.lblWhatNextOnline.Text = resources.GetString("lblWhatNextOnline.Text");
            // 
            // lblWathNextOnPremise
            // 
            this.lblWathNextOnPremise.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWathNextOnPremise.Location = new System.Drawing.Point(0, 289);
            this.lblWathNextOnPremise.Name = "lblWathNextOnPremise";
            this.lblWathNextOnPremise.Size = new System.Drawing.Size(1078, 143);
            this.lblWathNextOnPremise.TabIndex = 4;
            this.lblWathNextOnPremise.Text = resources.GetString("lblWathNextOnPremise.Text");
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1078, 35);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ok! So what\'s next?";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1078, 163);
            this.label2.TabIndex = 2;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1078, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "What does it mean?";
            // 
            // lblAggregateQueryRecordLimit
            // 
            this.lblAggregateQueryRecordLimit.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAggregateQueryRecordLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAggregateQueryRecordLimit.ForeColor = System.Drawing.Color.Red;
            this.lblAggregateQueryRecordLimit.Location = new System.Drawing.Point(0, 0);
            this.lblAggregateQueryRecordLimit.Name = "lblAggregateQueryRecordLimit";
            this.lblAggregateQueryRecordLimit.Size = new System.Drawing.Size(1078, 56);
            this.lblAggregateQueryRecordLimit.TabIndex = 0;
            this.lblAggregateQueryRecordLimit.Text = "Aggregate Query Record Limit reached!";
            this.lblAggregateQueryRecordLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 26);
            this.panel2.TabIndex = 1;
            // 
            // lvEntities
            // 
            this.lvEntities.CheckBoxes = true;
            this.lvEntities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvEntities.FullRowSelect = true;
            this.lvEntities.HideSelection = false;
            this.lvEntities.Location = new System.Drawing.Point(3, 42);
            this.lvEntities.Name = "lvEntities";
            this.lvEntities.Size = new System.Drawing.Size(537, 896);
            this.lvEntities.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvEntities.TabIndex = 2;
            this.lvEntities.UseCompatibleStateImageBehavior = false;
            this.lvEntities.View = System.Windows.Forms.View.Details;
            this.lvEntities.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvEntities_ColumnClick);
            this.lvEntities.SelectedIndexChanged += new System.EventHandler(this.lvEntities_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Display Name";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Logical Name";
            this.columnHeader2.Width = 200;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(108, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(429, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Search";
            // 
            // pnlFilterInfo
            // 
            this.pnlFilterInfo.BackColor = System.Drawing.SystemColors.Info;
            this.pnlFilterInfo.Controls.Add(this.lblFilterInfo);
            this.pnlFilterInfo.Controls.Add(this.label5);
            this.pnlFilterInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterInfo.Location = new System.Drawing.Point(3, 16);
            this.pnlFilterInfo.Name = "pnlFilterInfo";
            this.pnlFilterInfo.Size = new System.Drawing.Size(1078, 20);
            this.pnlFilterInfo.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 0;
            this.label5.Tag = "Statistics based on {0} records";
            // 
            // lblFilterInfo
            // 
            this.lblFilterInfo.AutoSize = true;
            this.lblFilterInfo.Location = new System.Drawing.Point(5, 5);
            this.lblFilterInfo.Name = "lblFilterInfo";
            this.lblFilterInfo.Size = new System.Drawing.Size(469, 13);
            this.lblFilterInfo.TabIndex = 1;
            this.lblFilterInfo.Text = "You can filter attributes displayed by enabling attributes filtering in settings," +
    " then selecting an entity.";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clDisplayName,
            this.clLogicalName,
            this.clType,
            this.clOnForm});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 36);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 28;
            this.dgvData.Size = new System.Drawing.Size(1078, 882);
            this.dgvData.TabIndex = 6;
            // 
            // clDisplayName
            // 
            this.clDisplayName.HeaderText = "Display Name";
            this.clDisplayName.Name = "clDisplayName";
            this.clDisplayName.ReadOnly = true;
            this.clDisplayName.Width = 200;
            // 
            // clLogicalName
            // 
            this.clLogicalName.HeaderText = "Logical Name";
            this.clLogicalName.Name = "clLogicalName";
            this.clLogicalName.ReadOnly = true;
            this.clLogicalName.Width = 200;
            // 
            // clType
            // 
            this.clType.HeaderText = "Attribute Type";
            this.clType.Name = "clType";
            this.clType.ReadOnly = true;
            this.clType.Width = 150;
            // 
            // clOnForm
            // 
            this.clOnForm.HeaderText = "On Form(s)";
            this.clOnForm.Name = "clOnForm";
            this.clOnForm.ReadOnly = true;
            // 
            // PluginControl
            // 
            this.Controls.Add(this.scInspector);
            this.Controls.Add(this.tsMain);
            this.Name = "PluginControl";
            this.Size = new System.Drawing.Size(1631, 966);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.scInspector.Panel1.ResumeLayout(false);
            this.scInspector.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInspector)).EndInit();
            this.scInspector.ResumeLayout(false);
            this.gbEntities.ResumeLayout(false);
            this.gbData.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlAggregateQueryRecordLimit.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlFilterInfo.ResumeLayout(false);
            this.pnlFilterInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.SplitContainer scInspector;
        private System.Windows.Forms.GroupBox gbEntities;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbLoadEntities;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbExportToExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Panel pnlAggregateQueryRecordLimit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.LinkLabel llDiscoWithStandardQueries;
        private System.Windows.Forms.LinkLabel llHowToUpdateAggregateQueryRecordLimit;
        private System.Windows.Forms.Label lblWhatNextOnline;
        private System.Windows.Forms.Label lblWathNextOnPremise;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAggregateQueryRecordLimit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbSettings;
        private System.Windows.Forms.ListView lvEntities;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlFilterInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFilterInfo;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLogicalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clOnForm;
    }
}
