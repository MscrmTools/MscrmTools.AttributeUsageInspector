using System;
using System.Windows.Forms;

namespace MscrmTools.AttributeUsageInspector
{
    public partial class SettingsDialog : Form
    {
        public SettingsDialog(int numberOfRecordsPerCall)
        {
            InitializeComponent();

            nudNumberOfRecordsPerCall.Value = numberOfRecordsPerCall >= nudNumberOfRecordsPerCall.Minimum &&
                                              numberOfRecordsPerCall <= nudNumberOfRecordsPerCall.Maximum
                ? numberOfRecordsPerCall
                : nudNumberOfRecordsPerCall.Minimum;
        }

        public int NumberOfRecordsPerCall { get; private set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult  = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            NumberOfRecordsPerCall = Convert.ToInt32(nudNumberOfRecordsPerCall.Value);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
