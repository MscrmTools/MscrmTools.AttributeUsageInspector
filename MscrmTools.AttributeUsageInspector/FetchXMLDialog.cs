using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MscrmTools.AttributeUsageInspector
{
    public partial class FetchXMLDialog : Form
    {
        public string FetchXMLQuery { get; private set; }

        private IOrganizationService _service;

        private EntityMetadata _selectedEntity;

        public FetchXMLDialog()
        {
            InitializeComponent();
        }

        public FetchXMLDialog(IOrganizationService service, Settings settings, EntityMetadata selectedEntity, EntityMetadataCollection entities)
            : this()
        {
            this._service = service;
            this._selectedEntity = selectedEntity;

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

        private async void rTxtB_FetchXMLQuery_TextChanged(object sender, EventArgs e)
        {
            txb_validationResult.ForeColor = Color.Black; 
            txb_validationResult.Text = "Validating FetchXML query...";

            string fetchXMLQuery = this.rTxtB_FetchXMLQuery.Text;
            if (string.IsNullOrEmpty(fetchXMLQuery))
                ShowInvalidQueryResults("Invalid query. FetchXML query cannot empty");
            else
            {
                try
                {
                    var queryExpression = await Task.Run(() => ConvertFetchXMLtoQuery(fetchXMLQuery));
                    if (queryExpression.EntityName != this._selectedEntity.LogicalName)
                    {
                        ShowInvalidQueryResults("Invalid query. The selected entity doesn't match the entity in the FetchXML query");
                    }
                    else if (queryExpression.ColumnSet.AllColumns == true)
                        ShowInvalidQueryResults("Invalid query. All columns shouldn't be selected, choose just the ones you need");
                    else
                        ShowValidQueryResults("FetchXML is correct");
                }
                catch(FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> exc)
                {
                    ShowInvalidQueryResults(string.Format("{0}. {1}", exc.Message, exc.Detail));
                }
                catch (Exception exc)
                {
                    ShowInvalidQueryResults(exc.Message);
                }
            }
        }

        private void ShowInvalidQueryResults(string message)
        {
            txb_validationResult.Text = message;
            txb_validationResult.ForeColor = Color.Red;
            btnOK.Enabled = false;
        }

        private void ShowValidQueryResults(string message)
        {
            txb_validationResult.Text = message;
            txb_validationResult.ForeColor = Color.Green;
            btnOK.Enabled = true;
        }

        private QueryExpression ConvertFetchXMLtoQuery(string fetchXMLQuery)
        {
            FetchXmlToQueryExpressionRequest conversionRequest = new FetchXmlToQueryExpressionRequest
            {
                FetchXml = fetchXMLQuery
            };

            FetchXmlToQueryExpressionResponse conversionResponse =
                (FetchXmlToQueryExpressionResponse)_service.Execute(conversionRequest);

            QueryExpression queryExpression = conversionResponse.Query;

            return queryExpression;
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
