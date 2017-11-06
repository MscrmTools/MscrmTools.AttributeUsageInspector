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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblNbrOfRecordsPerCall = new System.Windows.Forms.Label();
            this.nudNumberOfRecordsPerCall = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudNumberOfAttributesPerCall = new System.Windows.Forms.NumericUpDown();
            this.chkFilterAttributes = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfRecordsPerCall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfAttributesPerCall)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 39);
            this.panel1.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(2, 6);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(75, 25);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Settings";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 142);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(417, 39);
            this.panel2.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(253, 7);
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
            this.btnCancel.Location = new System.Drawing.Point(333, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblNbrOfRecordsPerCall
            // 
            this.lblNbrOfRecordsPerCall.AutoSize = true;
            this.lblNbrOfRecordsPerCall.Location = new System.Drawing.Point(8, 47);
            this.lblNbrOfRecordsPerCall.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNbrOfRecordsPerCall.Name = "lblNbrOfRecordsPerCall";
            this.lblNbrOfRecordsPerCall.Size = new System.Drawing.Size(131, 13);
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
            this.nudNumberOfRecordsPerCall.Location = new System.Drawing.Point(161, 45);
            this.nudNumberOfRecordsPerCall.Margin = new System.Windows.Forms.Padding(2);
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
            this.nudNumberOfRecordsPerCall.Size = new System.Drawing.Size(247, 20);
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
            this.label1.Location = new System.Drawing.Point(8, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
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
            this.nudNumberOfAttributesPerCall.Location = new System.Drawing.Point(161, 75);
            this.nudNumberOfAttributesPerCall.Margin = new System.Windows.Forms.Padding(2);
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
            this.nudNumberOfAttributesPerCall.Size = new System.Drawing.Size(247, 20);
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
            this.chkFilterAttributes.Location = new System.Drawing.Point(7, 100);
            this.chkFilterAttributes.Name = "chkFilterAttributes";
            this.chkFilterAttributes.Size = new System.Drawing.Size(168, 24);
            this.chkFilterAttributes.TabIndex = 6;
            this.chkFilterAttributes.Text = "Filter attributes";
            this.chkFilterAttributes.UseVisualStyleBackColor = true;
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 181);
            this.Controls.Add(this.chkFilterAttributes);
            this.Controls.Add(this.nudNumberOfAttributesPerCall);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudNumberOfRecordsPerCall);
            this.Controls.Add(this.lblNbrOfRecordsPerCall);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfRecordsPerCall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfAttributesPerCall)).EndInit();
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
    }
}