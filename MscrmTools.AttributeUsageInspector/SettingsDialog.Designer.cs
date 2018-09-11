namespace MscrmTools.AttributeUsageInspector
{
    partial class SettingsDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblNbrOfRecordsPerCall = new System.Windows.Forms.Label();
            this.nudNumberOfRecordsPerCall = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudNumberOfAttributesPerCall = new System.Windows.Forms.NumericUpDown();
            this.chkFilterAttributes = new System.Windows.Forms.CheckBox();
            this.chkUseSQL = new System.Windows.Forms.CheckBox();
            this.tbSQLConnectionString = new System.Windows.Forms.TextBox();
            this.nudCommandTimeOut = new System.Windows.Forms.NumericUpDown();
            this.lblCommandTimeout = new System.Windows.Forms.Label();
            this.chkUseFetchXMLQuery = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfRecordsPerCall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfAttributesPerCall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCommandTimeOut)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 60);
            this.panel1.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(3, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(109, 38);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Settings";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.btnTestConnection);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 543);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(626, 60);
            this.panel2.TabIndex = 1;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTestConnection.Location = new System.Drawing.Point(16, 11);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(5);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(164, 35);
            this.btnTestConnection.TabIndex = 6;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Visible = false;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(380, 11);
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
            this.btnCancel.Location = new System.Drawing.Point(500, 11);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblNbrOfRecordsPerCall
            // 
            this.lblNbrOfRecordsPerCall.AutoSize = true;
            this.lblNbrOfRecordsPerCall.Location = new System.Drawing.Point(12, 72);
            this.lblNbrOfRecordsPerCall.Name = "lblNbrOfRecordsPerCall";
            this.lblNbrOfRecordsPerCall.Size = new System.Drawing.Size(194, 20);
            this.lblNbrOfRecordsPerCall.TabIndex = 2;
            this.lblNbrOfRecordsPerCall.Text = "Number of records per call";
            // 
            // nudNumberOfRecordsPerCall
            // 
            this.nudNumberOfRecordsPerCall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudNumberOfRecordsPerCall.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNumberOfRecordsPerCall.Location = new System.Drawing.Point(241, 69);
            this.nudNumberOfRecordsPerCall.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudNumberOfRecordsPerCall.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNumberOfRecordsPerCall.Name = "nudNumberOfRecordsPerCall";
            this.nudNumberOfRecordsPerCall.Size = new System.Drawing.Size(371, 26);
            this.nudNumberOfRecordsPerCall.TabIndex = 3;
            this.nudNumberOfRecordsPerCall.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of attributes per call";
            // 
            // nudNumberOfAttributesPerCall
            // 
            this.nudNumberOfAttributesPerCall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudNumberOfAttributesPerCall.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNumberOfAttributesPerCall.Location = new System.Drawing.Point(241, 115);
            this.nudNumberOfAttributesPerCall.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudNumberOfAttributesPerCall.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNumberOfAttributesPerCall.Name = "nudNumberOfAttributesPerCall";
            this.nudNumberOfAttributesPerCall.Size = new System.Drawing.Size(371, 26);
            this.nudNumberOfAttributesPerCall.TabIndex = 5;
            this.nudNumberOfAttributesPerCall.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // chkFilterAttributes
            // 
            this.chkFilterAttributes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFilterAttributes.Location = new System.Drawing.Point(11, 154);
            this.chkFilterAttributes.Margin = new System.Windows.Forms.Padding(5);
            this.chkFilterAttributes.Name = "chkFilterAttributes";
            this.chkFilterAttributes.Size = new System.Drawing.Size(252, 37);
            this.chkFilterAttributes.TabIndex = 6;
            this.chkFilterAttributes.Text = "Filter attributes";
            this.chkFilterAttributes.UseVisualStyleBackColor = true;
            this.chkFilterAttributes.CheckedChanged += new System.EventHandler(this.chkFilterAttributes_CheckedChanged);
            // 
            // chkUseSQL
            // 
            this.chkUseSQL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUseSQL.Location = new System.Drawing.Point(11, 197);
            this.chkUseSQL.Margin = new System.Windows.Forms.Padding(5);
            this.chkUseSQL.Name = "chkUseSQL";
            this.chkUseSQL.Size = new System.Drawing.Size(252, 37);
            this.chkUseSQL.TabIndex = 7;
            this.chkUseSQL.Text = "Use Direct SQL Query";
            this.chkUseSQL.UseVisualStyleBackColor = true;
            this.chkUseSQL.CheckedChanged += new System.EventHandler(this.chkUseSQL_CheckedChanged);
            // 
            // tbSQLConnectionString
            // 
            this.tbSQLConnectionString.Enabled = false;
            this.tbSQLConnectionString.Location = new System.Drawing.Point(16, 246);
            this.tbSQLConnectionString.Margin = new System.Windows.Forms.Padding(5);
            this.tbSQLConnectionString.Multiline = true;
            this.tbSQLConnectionString.Name = "tbSQLConnectionString";
            this.tbSQLConnectionString.Size = new System.Drawing.Size(594, 118);
            this.tbSQLConnectionString.TabIndex = 8;
            this.tbSQLConnectionString.Text = "Data Source=;Initial Catalog=;Integrated Security=SSPI";
            // 
            // nudCommandTimeOut
            // 
            this.nudCommandTimeOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudCommandTimeOut.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCommandTimeOut.Location = new System.Drawing.Point(447, 200);
            this.nudCommandTimeOut.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudCommandTimeOut.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCommandTimeOut.Name = "nudCommandTimeOut";
            this.nudCommandTimeOut.Size = new System.Drawing.Size(165, 26);
            this.nudCommandTimeOut.TabIndex = 9;
            this.nudCommandTimeOut.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // lblCommandTimeout
            // 
            this.lblCommandTimeout.AutoSize = true;
            this.lblCommandTimeout.Location = new System.Drawing.Point(290, 206);
            this.lblCommandTimeout.Name = "lblCommandTimeout";
            this.lblCommandTimeout.Size = new System.Drawing.Size(146, 20);
            this.lblCommandTimeout.TabIndex = 10;
            this.lblCommandTimeout.Text = "Command TimeOut";
            // 
            // chkUseFetchXMLQuery
            // 
            this.chkUseFetchXMLQuery.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUseFetchXMLQuery.Location = new System.Drawing.Point(16, 374);
            this.chkUseFetchXMLQuery.Margin = new System.Windows.Forms.Padding(5);
            this.chkUseFetchXMLQuery.Name = "chkUseFetchXMLQuery";
            this.chkUseFetchXMLQuery.Size = new System.Drawing.Size(252, 37);
            this.chkUseFetchXMLQuery.TabIndex = 11;
            this.chkUseFetchXMLQuery.Text = "Use FetchXML query";
            this.chkUseFetchXMLQuery.UseVisualStyleBackColor = true;
            this.chkUseFetchXMLQuery.CheckedChanged += new System.EventHandler(this.chkUseFetchXMLQuery_CheckedChanged);
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 603);
            this.Controls.Add(this.chkUseFetchXMLQuery);
            this.Controls.Add(this.lblCommandTimeout);
            this.Controls.Add(this.nudCommandTimeOut);
            this.Controls.Add(this.tbSQLConnectionString);
            this.Controls.Add(this.chkUseSQL);
            this.Controls.Add(this.chkFilterAttributes);
            this.Controls.Add(this.nudNumberOfAttributesPerCall);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudNumberOfRecordsPerCall);
            this.Controls.Add(this.lblNbrOfRecordsPerCall);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfRecordsPerCall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfAttributesPerCall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCommandTimeOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNbrOfRecordsPerCall;
        private System.Windows.Forms.NumericUpDown nudNumberOfRecordsPerCall;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudNumberOfAttributesPerCall;
        private System.Windows.Forms.CheckBox chkFilterAttributes;
        private System.Windows.Forms.CheckBox chkUseSQL;
        private System.Windows.Forms.TextBox tbSQLConnectionString;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.NumericUpDown nudCommandTimeOut;
        private System.Windows.Forms.Label lblCommandTimeout;
        private System.Windows.Forms.CheckBox chkUseFetchXMLQuery;
    }
}