using RecipiesModelNS;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace RecipiesWebFormApp.Sales
{
    public partial class Orders : System.Web.UI.Page
    {
        public int SalesOrderId
        {
            get
            {
                int salesOrderId = (int) ViewState["SalesOrderId"];
                return salesOrderId;
            }
            set { ViewState["SalesOrderId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void lblSalesOrderDetails_PreRender(object sender, EventArgs e)
        {
            if (SalesOrderId > 0)
            {
                Label lblSalesOrderDetails = (Label) sender;
                lblSalesOrderDetails.Visible = false;
            }
        }

        protected void rgSalesOrderDetails_PreRender(object sender, EventArgs e)
        {
            if (SalesOrderId <= 0)
            {
                RadGrid rgSalesOrderDetails = (RadGrid) sender;
                rgSalesOrderDetails.Visible = false;
            }
        }

        protected void OpenAccessLinqDataSourceOrderDetail_Inserting(object sender, EntityDataSourceChangingEventArgs e)
        {
            SalesOrderDetail newSalesOrderDetail = e.Entity as SalesOrderDetail;
            if (newSalesOrderDetail != null)
            {
                newSalesOrderDetail.SalesOrderHeaderId = SalesOrderId;
            }
        }

        protected void OpenAccessLinqDataSourceOrderDetail_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
        {
            if (e.DataSource.WhereParameters["SalesOrderHeaderId"] != null)
            {
                e.DataSource.WhereParameters["SalesOrderHeaderId"].DefaultValue = SalesOrderId.ToString();
            }
        }

        protected void rgSalesOrderHeaders_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.EditCommandName)
            {
                GridEditableItem editableItem = e.Item as GridEditableItem;
                if (editableItem != null)
                {
                    int salesOrderId =
                        (int) editableItem.GetDataKeyValue(rgSalesOrderHeaders.MasterTableView.DataKeyNames[0]);
                    SalesOrderHeader salesOrderHeader =
                        ContextFactory.GetContextPerRequest()
                            .SalesOrderHeaders.FirstOrDefault(s => s.SalesOrderHeaderId == salesOrderId);
                    SalesOrderId = salesOrderHeader.SalesOrderHeaderId;
                }
            }
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                SalesOrderId = 0;
            }
        }

        protected void OpenAccessLinqDataSourceOrder_Updating(object sender, EntityDataSourceChangingEventArgs e)
        {
            //SalesOrderHeader oldPurchaseOrderHeader = e.OriginalObject as SalesOrderHeader;
            //SalesOrderHeader newPurchaseOrderHeader = e.NewObject as SalesOrderHeader;

            //newPurchaseOrderHeader.UpdateProductsFromStatus(oldPurchaseOrderHeader.StatusId, newPurchaseOrderHeader.StatusId);
        }

        protected void OpenAccessLinqDataSourceOrder_Updated(object sender, EntityDataSourceChangedEventArgs e)
        {
            //SalesOrderHeader oldPurchaseOrderHeader = e.Entity as SalesOrderHeader;
            //SalesOrderHeader newPurchaseOrderHeader = e.NewObject as SalesOrderHeader;

            //newPurchaseOrderHeader.UpdateProductsFromStatus(oldPurchaseOrderHeader.StatusId, newPurchaseOrderHeader.StatusId);
        }
    }
}