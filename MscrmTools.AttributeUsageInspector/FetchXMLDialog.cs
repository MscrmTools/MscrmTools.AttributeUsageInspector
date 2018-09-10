using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MscrmTools.AttributeUsageInspector
{
    public partial class FetchXMLDialog : Form
    {
        public string FetchXMLQuery { get; private set; }

        private IOrganizationService _service;

        public FetchXMLDialog()
        {
            InitializeComponent();
        }

        public FetchXMLDialog(IOrganizationService service, Settings settings, EntityMetadata selectedEntity, EntityMetadataCollection entities)
            : this()
        {
            this._service = service;

            Task.Run(() => LoadSystemViews(selectedEntity));
            Task.Run(() => LoadUserViews(selectedEntity));
        }

        private void LoadUserViews(EntityMetadata selectedEntity)
        {
            QueryExpression query = new QueryExpression("userquery");
            query.ColumnSet.AddColumns(new string[] { "name", "fetchxml" });
            query.Criteria.AddCondition("returnedtypecode", ConditionOperator.Equal, selectedEntity.LogicalName);

            EntityCollection savedQueryCollection = _service.RetrieveMultiple(query);
            if (savedQueryCollection.Entities != null && savedQueryCollection.Entities.Count > 0)
            {
                IOrderedEnumerable<Entity> views = savedQueryCollection.Entities.OrderBy(v => v["name"] as string);
                foreach (Entity view in views)
                {
                    cmb_userviews.Items.Add(new DropDownViewItem(view["name"] as string, view["fetchxml"] as string));
                }
            }
        }

        private void LoadSystemViews(EntityMetadata selectedEntity)
        {
            QueryExpression query = new QueryExpression("savedquery");
            query.ColumnSet.AddColumns(new string[] { "name", "fetchxml" });
            query.Criteria.AddCondition("returnedtypecode", ConditionOperator.Equal, selectedEntity.LogicalName);

            EntityCollection savedQueryCollection = _service.RetrieveMultiple(query);
            if (savedQueryCollection.Entities!=null && savedQueryCollection.Entities.Count > 0)
            {
                IOrderedEnumerable<Entity> views = savedQueryCollection.Entities.OrderBy(v => v["name"] as string);
                foreach (Entity view in views)
                {
                    cmb_systemViews.Items.Add(new DropDownViewItem(view["name"] as string, view["fetchxml"] as string));
                }
                DropDownViewItem selectedView = cmb_systemViews.Items[0] as DropDownViewItem;
                cmb_systemViews.SelectedItem = selectedView;
                this.rTxtB_FetchXMLQuery.Text = selectedView.FetchXML;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FetchXMLQuery = this.rTxtB_FetchXMLQuery.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmb_systemViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownViewItem selectedView = this.cmb_systemViews.SelectedItem as DropDownViewItem;
            if (selectedView != null)
            {
                cmb_systemViews.SelectedItem = selectedView;
                this.rTxtB_FetchXMLQuery.Text = selectedView.FetchXML;
            }
        }

        private void cmb_userviews_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownViewItem selectedView = this.cmb_userviews.SelectedItem as DropDownViewItem;
            if (selectedView != null)
            {
                cmb_userviews.SelectedItem = selectedView;
                this.rTxtB_FetchXMLQuery.Text = selectedView.FetchXML;
            }
        }
    }

    internal class DropDownViewItem
    {
        internal string ViewName { get; private set; }

        internal string FetchXML { get; private set; }

        internal DropDownViewItem(string viewName, string fetchXML)
        {
            this.ViewName = viewName;
            this.FetchXML = fetchXML;
        }

        public override string ToString()
        {
            return this.ViewName;
        }
    }
}
