<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="RecipiesWebFormApp.Sales.OrderDetails" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="yordan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <yordan:YordanCustomRadGrid ID="rgSalesOrderDetails" runat="server" DataSourceID="OpenAccessLinqDataSourceOrderDetail" CellSpacing="0" GridLines="None">

        <HeaderStyle />
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="SalesOrderDetailId" DataSourceID="OpenAccessLinqDataSourceOrderDetail">
            <Columns>
                <telerik:GridBoundColumn DataField="SalesOrderDetailId" DataType="System.Int32" FilterControlAltText="Filter SalesOrderDetailId column" HeaderText="SalesOrderDetailId" ReadOnly="True" SortExpression="SalesOrderDetailId" UniqueName="SalesOrderDetailId">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownSalesOrderHeaderListColumn" ListTextField="OrderId"
                                            ListValueField="OrderId" DataSourceID="OpenAccessLinqDataSourceSalesOrderHeader" HeaderText="SalesOrder"
                                            DataField="SalesOrderId" DropDownControlType="RadComboBox" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true">
                </telerik:GridDropDownColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownRecipeListColumn" ListTextField="Name"
                                            ListValueField="RecipeId" DataSourceID="OpenAccessLinqDataSourceRecipe" HeaderText="Recipe"
                                            DataField="RecipeId" DropDownControlType="RadComboBox" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true">
                </telerik:GridDropDownColumn>
                <telerik:GridNumericColumn DataField="OrderQuantity" DataType="System.Int32" FilterControlAltText="Filter OrderQuantity column" HeaderText="OrderQuantity" SortExpression="OrderQuantity" UniqueName="OrderQuantity">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="UnitPrice" DataType="System.Decimal" FilterControlAltText="Filter UnitPrice column" HeaderText="UnitPrice" SortExpression="UnitPrice" UniqueName="UnitPrice">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="UnitPriceDiscount" DataType="System.Double" FilterControlAltText="Filter UnitPriceDiscount column" HeaderText="UnitPriceDiscount" SortExpression="UnitPriceDiscount" UniqueName="UnitPriceDiscount">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="LineTotal" ReadOnly="true" DataType="System.Decimal" FilterControlAltText="Filter LineTotal column" HeaderText="LineTotal" SortExpression="LineTotal" UniqueName="LineTotal">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridDateTimeColumn DataField="ModifiedDate" DataType="System.DateTime" FilterControlAltText="Filter ModifiedDate column" HeaderText="ModifiedDate" SortExpression="ModifiedDate" UniqueName="ModifiedDate">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridDateTimeColumn>
                <telerik:GridBoundColumn DataField="ModifiedByUser" FilterControlAltText="Filter ModifiedByUser column" HeaderText="ModifiedByUser" SortExpression="ModifiedByUser" UniqueName="ModifiedByUser">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </yordan:YordanCustomRadGrid>
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceOrderDetail" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="SalesOrderDetails">
    </yordan:YordanCustomOpenAccessLinqDataSource>
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceSalesOrderHeader" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="SalesOrderHeaders" />
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceRecipe" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Recipes" />
</asp:Content>