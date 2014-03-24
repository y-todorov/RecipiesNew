<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseOrderStatuses.aspx.cs" Inherits="RecipiesWebFormApp.Purchasing.PurchaseOrderStatuses" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="yordan" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourcePurchaseOrderStatuses" Runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="PurchaseOrderStatus" />
    <yordan:YordanCustomRadGrid ID="rgPurchaseOrderStatuses" runat="server" CellSpacing="0" DataSourceID="OpenAccessLinqDataSourcePurchaseOrderStatuses" GridLines="None">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="PurchaseOrderStatusId" DataSourceID="OpenAccessLinqDataSourcePurchaseOrderStatuses">
            <Columns>
                <telerik:GridBoundColumn DataField="PurchaseOrderStatusId" DataType="System.Int32" FilterControlAltText="Filter PurchaseOrderStatusId column" HeaderText="PurchaseOrderStatusId" ReadOnly="True" SortExpression="PurchaseOrderStatusId" UniqueName="PurchaseOrderStatusId">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column" HeaderText="Name" SortExpression="Name" UniqueName="Name">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridDateTimeColumn DataField="ModifiedDate" DataType="System.DateTime"  ReadOnly="true" FilterControlAltText="Filter ModifiedDate column" HeaderText="ModifiedDate" SortExpression="ModifiedDate" UniqueName="ModifiedDate">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridDateTimeColumn>
                <telerik:GridBoundColumn DataField="ModifiedByUser" ReadOnly="true" FilterControlAltText="Filter ModifiedByUser column" HeaderText="ModifiedByUser" SortExpression="ModifiedByUser" UniqueName="ModifiedByUser">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </yordan:YordanCustomRadGrid>

</asp:Content>