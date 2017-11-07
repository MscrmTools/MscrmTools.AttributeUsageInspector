using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;

namespace MscrmTools.AttributeUsageInspector
{
    public partial class FilterAttributesDialog : Form
    {
        private int columnSortedIndex = 0;
        private readonly string entityLogicalName;
        private readonly IOrganizationService service;

        public FilterAttributesDialog(IOrganizationService service, string entityLogicalName)
        {
            InitializeComponent();

            this.entityLogicalName = entityLogicalName;
            this.service = service;
        }

        public List<string> Attributes
        {
            get
            {
                return lvAttributes.CheckedItems.Cast<ListViewItem>()
                    .Select(i => ((AttributeMetadata)i.Tag).LogicalName).ToList();
            }
        }

        public bool ShowCustomOnly => rbCustom.Checked;
        public bool ShowStandardOnly => rbStandard.Checked;

        private void rbChoose_CheckedChanged(object sender, EventArgs e)
        {
            if (rbChoose.Checked)
            {
                LoadAttributes();
                gbAttributesSelection.Enabled = true;
            }
            else
            {
                gbAttributesSelection.Enabled = false;
            }
        }

        private void LoadAttributes()
        {
            var emds = MetadataHelper.LoadAttributes(service, entityLogicalName);

            lvAttributes.Items.AddRange(emds.First().Attributes.Select(a => new ListViewItem(a.DisplayName?.UserLocalizedLabel?.Label ?? "N/A") { Tag = a, SubItems = { a.LogicalName } }).ToArray());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void llInvertSelection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in lvAttributes.Items)
            {
                item.Checked = !item.Checked;
            }
        }

        private void llNone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in lvAttributes.Items)
            {
                item.Checked = false;
            }
        }

        private void llSelectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in lvAttributes.Items)
            {
                item.Checked = true;
            }
        }

        private void llStandard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in lvAttributes.Items)
            {
                item.Checked = !((AttributeMetadata)item.Tag).IsCustomAttribute ?? false;
            }
        }

        private void llCustom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in lvAttributes.Items)
            {
                item.Checked = ((AttributeMetadata)item.Tag).IsCustomAttribute ?? false;
            }
        }

        private void lvAttributes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var lv = (ListView)sender;
            if (e.Column == columnSortedIndex)
            {
                lv.Sorting = lv.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                lv.ListViewItemSorter = new ListViewItemComparer(e.Column, lv.Sorting);
            }
            else
            {
                columnSortedIndex = e.Column;

                lv.ListViewItemSorter = new ListViewItemComparer(e.Column, SortOrder.Ascending);
            }
        }
    }
}