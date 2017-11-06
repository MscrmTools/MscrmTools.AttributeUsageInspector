using System;
using System.Windows.Forms;

namespace MscrmTools.AttributeUsageInspector
{
    public partial class SettingsDialog : Form
    {
        public SettingsDialog(Settings settings)
        {
            InitializeComponent();

            Settings = settings;

            nudNumberOfRecordsPerCall.Value = settings.RecordsReturnedPerTrip >= nudNumberOfRecordsPerCall.Minimum &&
                                              settings.RecordsReturnedPerTrip <= nudNumberOfRecordsPerCall.Maximum
                ? settings.RecordsReturnedPerTrip
                : nudNumberOfRecordsPerCall.Minimum;

            nudNumberOfAttributesPerCall.Value = settings.AttributesReturnedPerTrip >= nudNumberOfAttributesPerCall.Minimum &&
                                                 settings.AttributesReturnedPerTrip <= nudNumberOfAttributesPerCall.Maximum
                ? settings.AttributesReturnedPerTrip
                : nudNumberOfAttributesPerCall.Minimum;

            chkFilterAttributes.Checked = settings.FilterAttributes;
        }

        public Settings Settings { get; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Settings.RecordsReturnedPerTrip = Convert.ToInt32(nudNumberOfRecordsPerCall.Value);
            Settings.AttributesReturnedPerTrip = Convert.ToInt32(nudNumberOfAttributesPerCall.Value);
            Settings.FilterAttributes = chkFilterAttributes.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}