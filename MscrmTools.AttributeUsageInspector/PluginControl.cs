using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;

namespace MscrmTools.AttributeUsageInspector
{
    public partial class PluginControl : PluginControlBase, IStatusBarMessenger, IGitHubPlugin, IHelpPlugin
    {
        private readonly List<ListViewItem> allItems = new List<ListViewItem>();
        private readonly List<DetectionResults> globalResults;

        private readonly Settings settings;
        private DetectiveEngine de;

        public PluginControl()
        {
            InitializeComponent();

            if (!SettingsManager.Instance.TryLoad(typeof(PluginControl), out settings))
            {
                settings = new Settings { RecordsReturnedPerTrip = 1000, AttributesReturnedPerTrip = 50 };
            }

            if (settings.AttributesReturnedPerTrip == 0)
            {
                settings.AttributesReturnedPerTrip = 50;
                SettingsManager.Instance.Save(typeof(PluginControl), settings);
            }

            if (dgvData.Columns.Count < 5)
            {
                dgvData.Columns.Add(new DataGridViewProgressColumn
                {
                    HeaderText = "Data Usage",
                    Name = "clProgress",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
            }

            globalResults = new List<DetectionResults>();
        }

        #region Interfaces members

        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;

        public string HelpUrl
        {
            get { return "https://github.com/MscrmTools/MscrmTools.AttributeUsageInspector/wiki"; }
        }

        public string RepositoryName
        {
            get { return "MscrmTools.AttributeUsageInspector"; }
        }

        public string UserName
        {
            get { return "MscrmTools"; }
        }

        #endregion Interfaces members

        #region Form events

        private void dgvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (dgvData.SortOrder == SortOrder.Descending)
                    dgvData.Sort(dgvData.Columns[e.ColumnIndex], ListSortDirection.Ascending);
                else
                {
                    dgvData.Sort(dgvData.Columns[e.ColumnIndex], ListSortDirection.Descending);
                }
            }
        }

        private void llDiscoWithStandardQueries_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (
                MessageBox.Show(this,
                    "This feature may have performance impact on your computer and your CRM organization.\r\n\r\nAre you sure you want to continue?",
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                LoadDataUsage(true);
            }
        }

        private void llHowToUpdateAggregateQueryRecordLimit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(
                "https://nishantrana.me/2012/09/06/aggregatequeryrecordlimit-exceeded-cannot-perform-this-operation/");
        }

        private void lvEntities_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvEntities.SelectedIndexChanged -= lvEntities_SelectedIndexChanged;

            var lv = (ListView)sender;
            lv.Sorting = lv.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            lv.ListViewItemSorter = new ListViewItemComparer(e.Column, lv.Sorting);

            lvEntities.SelectedIndexChanged += lvEntities_SelectedIndexChanged;
        }

        private void lvEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEntities.SelectedItems.Count == 0) return;

            if (settings.FilterAttributes)
            {
                var dialog = new FilterAttributesDialog(Service,
                    ((EntityMetadata)lvEntities.SelectedItems[0].Tag).LogicalName);
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                EntityFilterSetting fs = new EntityFilterSetting();
                fs.Attributes = dialog.Attributes;
                fs.ShowOnlyCustom = dialog.ShowCustomOnly;
                fs.ShowOnlyStandard = dialog.ShowStandardOnly;
                settings.Filters[dialog.entityLogicalName] = fs;
            }

            ExecuteMethod(LoadDataUsage, false);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbExportToExcel_Click(object sender, EventArgs e)
        {
            if (lvEntities.CheckedItems.Count == 0) return;

            string message =
                "Exporting to Excel may use standard queries to retrieve all records if records count exceeds 50,000. If so, performance degradation may occur on CRM organization and export may take time. \r\n\r\nAre you sure you want to continue?\r\n\r\nNote: If you previously retrieved data usage, this has been stored in cache and won't be queried again";

            if (MessageBox.Show(this, message, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                ExecuteMethod(ExportToExcel);
            }
        }

        private void tsbLoadEntities_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEntities);
        }

        #endregion Form events

        #region Business methods

        public void ExportToExcel()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Starting export...",
                AsyncArgument = lvEntities.CheckedItems.Cast<ListViewItem>().Select(i => (EntityMetadata)i.Tag),
                Work = (w, e) =>
                {
                    var emds = (IEnumerable<EntityMetadata>)e.Argument;
                    var excelEngine = new ExcelEngine();

                    foreach (var emd in emds)
                    {
                        w.ReportProgress(0, "Exporting entity " + emd.LogicalName);
                        de = new DetectiveEngine(Service);

                        var result = globalResults.FirstOrDefault(r => r.Entity == emd.LogicalName);
                        if (result == null)
                        {
                            result = de.GetUsage(emd, false, settings);
                            if (result.IsAggregateQueryRecordLimitReached)
                            {
                                result = de.GetUsage(emd, true, settings);
                            }
                        }

                        w.ReportProgress(0, "Loading forms definitions...");
                        result.Forms = MetadataHelper.GetFormsDefinitions(emd.ObjectTypeCode.Value, Service);

                        excelEngine.AddEntity(emd, result);

                        e.Result = excelEngine;
                    }
                },
                PostWorkCallBack = e =>
                {
                    SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(""));

                    if (e.Error != null)
                    {
                        MessageBox.Show(e.Error.ToString());
                    }

                    var sfd = new SaveFileDialog { Filter = "Excel Workbook|*.xlsx" };
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ((ExcelEngine)e.Result).Save(sfd.FileName);

                        if (
                            MessageBox.Show(this, "File saved! Would you like to open it?", "Information",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Process.Start(sfd.FileName);
                        }
                    }
                },
                ProgressChanged = e =>
                {
                    SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(e.UserState.ToString()));
                    SetWorkingMessage(e.UserState.ToString());
                }
            });
        }

        public void LoadDataUsage(bool useQueries)
        {
            dgvData.Rows.Clear();
            lvEntities.Enabled = false;
            tsbLoadEntities.Enabled = false;
            tsbExportToExcel.Enabled = false;
            pnlData.Visible = true;
            pnlAggregateQueryRecordLimit.Visible = false;

            tssCancel.Visible = useQueries;
            tsbCancel.Visible = useQueries;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading data usage...",
                AsyncArgument =
                    new Tuple<EntityMetadata, bool>((EntityMetadata)lvEntities.SelectedItems[0].Tag, useQueries),
                Work = (w, e) =>
                {
                    de = new DetectiveEngine(Service);
                    var emd = ((Tuple<EntityMetadata, bool>)e.Argument).Item1;
                    var useStdQueries = ((Tuple<EntityMetadata, bool>)e.Argument).Item2;
                    DetectionResults result = de.GetUsage(emd, useStdQueries, settings, w);

                    w.ReportProgress(0, "Loading forms definitions...");
                    result.Forms = MetadataHelper.GetFormsDefinitions(emd.ObjectTypeCode.Value, Service);

                    e.Result = result;
                },
                PostWorkCallBack = e =>
                {
                    SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(""));
                    lvEntities.Enabled = true;
                    tsbLoadEntities.Enabled = true;

                    if (e.Error != null)
                    {
                        MessageBox.Show(this, $@"An error occured: {e.Error.Message}", @"Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    tsbExportToExcel.Enabled = true;

                    var results = (DetectionResults)e.Result;

                    var currentEntityResult = globalResults.FirstOrDefault(
                        r => r.Entity == ((EntityMetadata)lvEntities.SelectedItems[0].Tag).LogicalName);
                    if (currentEntityResult != null)
                    {
                        globalResults.Remove(currentEntityResult);
                    }

                    globalResults.Add(results);

                    if (results.Fault != null)
                    {
                        if (results.IsAggregateQueryRecordLimitReached)
                        {
                            pnlData.Visible = false;
                            pnlAggregateQueryRecordLimit.Visible = true;
                            lblWathNextOnPremise.Visible = !ConnectionDetail.UseOnline;
                            lblWhatNextOnline.Visible = ConnectionDetail.UseOnline;
                            llHowToUpdateAggregateQueryRecordLimit.Visible = !ConnectionDetail.UseOnline;
                        }
                        else
                        {
                            MessageBox.Show(results.Fault.Message);
                            lblCount.Text = results.Fault.Message;
                        }
                        return;
                    }

                    foreach (var result in results.Results)
                    {
                        dgvData.Rows.Add(result.Attribute.DisplayName.UserLocalizedLabel?.Label,
                            result.Attribute.LogicalName, result.Attribute.AttributeType.Value,
                            results.AttributeIsContainedInForms(result.Attribute.LogicalName), result.Percentage);
                    }

                    lblCount.Text = string.Format(lblCount.Tag.ToString(), results.Total);
                },
                ProgressChanged = e =>
                {
                    SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(e.UserState.ToString()));
                    SetWorkingMessage($"Loading data usage...\n{e.UserState.ToString()}");
                }
            });
        }

        public void LoadEntities()
        {
            lvEntities.Items.Clear();
            lvEntities.Enabled = false;
            tsbLoadEntities.Enabled = false;
            tsbExportToExcel.Enabled = false;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Entities...",
                Work = (w, e) =>
                {
                    e.Result = MetadataHelper.LoadEntities(Service);
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        MessageBox.Show(e.Error.ToString());
                    }

                    var items = new List<ListViewItem>();

                    foreach (var emd in (EntityMetadataCollection)e.Result)
                    {
                        var item = new ListViewItem(emd.DisplayName.UserLocalizedLabel != null
                            ? emd.DisplayName.UserLocalizedLabel.Label
                            : "N/A");
                        item.SubItems.Add(emd.LogicalName);
                        item.Tag = emd;

                        allItems.Add(item);

                        if (txtSearch.Text.Length == 0 || txtSearch.Text.Length > 0
                            && (emd.LogicalName.IndexOf(txtSearch.Text.ToLower(), StringComparison.Ordinal) >= 0
                                || emd.DisplayName?.UserLocalizedLabel?.Label.ToLower()
                                    .IndexOf(txtSearch.Text.ToLower(), StringComparison.Ordinal) >= 0))
                        {
                            items.Add(item);
                        }
                    }

                    lvEntities.Items.AddRange(items.ToArray());
                    lvEntities.Enabled = true;
                    tsbLoadEntities.Enabled = true;
                    tsbExportToExcel.Enabled = true;
                },
                ProgressChanged = e =>
                {
                    SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(e.UserState.ToString()));
                }
            });
        }

        #endregion Business methods

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            de.Cancel = true;
            tssCancel.Visible = false;
            tsbCancel.Visible = false;
        }

        private void tsbSettings_Click(object sender, EventArgs e)
        {
            var dialog = new SettingsDialog(settings);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                settings.AttributesReturnedPerTrip = dialog.Settings.AttributesReturnedPerTrip;
                settings.RecordsReturnedPerTrip = dialog.Settings.RecordsReturnedPerTrip;
                settings.FilterAttributes = dialog.Settings.FilterAttributes;
                SettingsManager.Instance.Save(typeof(PluginControl), settings);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lvEntities.SelectedIndexChanged -= lvEntities_SelectedIndexChanged;
            lvEntities.Items.Clear();

            if (txtSearch.Text.Length == 0)
            {
                lvEntities.Items.AddRange(allItems.ToArray());
            }
            else
            {
                lvEntities.Items.AddRange(allItems
                    .Where(i => ((EntityMetadata)i.Tag).LogicalName.IndexOf(txtSearch.Text.ToLower()) >= 0
                                || ((EntityMetadata)i.Tag).DisplayName?.UserLocalizedLabel?.Label.IndexOf(txtSearch
                                    .Text.ToLower()) >= 0).ToArray());
            }
            lvEntities.SelectedIndexChanged += lvEntities_SelectedIndexChanged;
        }
    }
}