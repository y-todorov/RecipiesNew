<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseOrderDetails.aspx.cs" Inherits="RecipiesWebFormApp.Purchasing.PurchaseOrderDetails" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="yordan" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourcePurchaseOrderDetails" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="PurchaseOrderDetails" Include="PurchaseOrderHeader, PurchaseOrderHeader.Vendor, Product.ProductCategory, PurchaseOrderHeader.PurchaseOrderStatu">
    </yordan:YordanCustomOpenAccessLinqDataSource>
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourcePurchaseOrder" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="PurchaseOrderHeaders" />
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceProduct" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Products" />
    <yordan:YordanCustomRadGrid ID="rgPurchaseOrderDetails" runat="server" EnableLinqExpressions="true" DataSourceID="OpenAccessLinqDataSourcePurchaseOrderDetails">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="PurchaseOrderDetailId" DataSourceID="OpenAccessLinqDataSourcePurchaseOrderDetails">
            <%--            <GroupByExpressions>
                <telerik:GridGroupByExpression>
                    <GroupByFields>
                        <telerik:GridGroupByField FieldName="PurchaseOrderHeader.ShipDate" HeaderText="ShipDate" FormatString="{0:dd/MM/yyyy}" />
                        <telerik:GridGroupByField FieldName="PurchaseOrderHeader.Vendor.Name" HeaderText="Vendor"  />
                        <telerik:GridGroupByField FieldName="Product.ProductCategory.Name"  HeaderText="Category"/>
                    </GroupByFields>
                    <SelectFields>
                        <telerik:GridGroupByField FieldName="PurchaseOrderHeader.ShipDate"  HeaderText="ShipDate" FormatString="{0:dd/MM/yyyy}"/>
                        <telerik:GridGroupByField FieldName="PurchaseOrderHeader.Vendor.Name"  HeaderText="Vendor"/>
                         <telerik:GridGroupByField FieldName="Product.ProductCategory.Name"  HeaderText="Category"/>
                    </SelectFields>
                </telerik:GridGroupByExpression>
            </GroupByExpressions>--%>
            <Columns>
                <telerik:GridBoundColumn DataField="PurchaseOrderDetailId" DataType="System.Int32" FilterControlAltText="Filter PurchaseOrderDetailId column" HeaderText="PurchaseOrderDetailId" ReadOnly="True" SortExpression="PurchaseOrderDetailId" UniqueName="PurchaseOrderDetailId">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownPurchaseOrderListColumn" ListTextField="PurchaseOrderId" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true"
                                            ListValueField="PurchaseOrderId" DataSourceID="OpenAccessLinqDataSourcePurchaseOrder" HeaderText="PurchaseOrder"
                                            DataField="PurchaseOrderId" DropDownControlType="RadComboBox">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownProductListColumn" ListTextField="Name" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true"
                                            ListValueField="ProductId" DataSourceID="OpenAccessLinqDataSourceProduct" HeaderText="Product"
                                            DataField="ProductId" DropDownControlType="RadComboBox">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridDateTimeColumn DataField="PurchaseOrderHeader.ShipDate" ReadOnly="true" DataType="System.DateTime"  FilterControlAltText="Filter PurchaseOrderHeader.ShipDate column" HeaderText="ShipDate" SortExpression="PurchaseOrderHeader.ShipDate.Value" UniqueName="PurchaseOrderHeaderShipDate">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridDateTimeColumn>
                <telerik:GridBoundColumn DataField="PurchaseOrderHeader.Vendor.Name" ReadOnly="true" DataType="System.String" FilterControlAltText="Filter PurchaseOrderHeader.ShipDate column" HeaderText="Vendor" SortExpression="PurchaseOrderHeader.Vendor.Name" UniqueName="PurchaseOrderHeader.Vendor.Name">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PurchaseOrderHeader.OrderDate" ReadOnly="true" DataType="System.DateTime" FilterControlAltText="Filter PurchaseOrderHeader.OrderDate column" HeaderText="OrderDate" SortExpression="PurchaseOrderHeader.OrderDate" UniqueName="PurchaseOrderHeader.OrderDate">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PurchaseOrderHeader.ShipDate" ReadOnly="true" DataType="System.DateTime" FilterControlAltText="Filter PurchaseOrderHeader.OrderDate column" HeaderText="ShipDate" SortExpression="PurchaseOrderHeader.ShipDate" UniqueName="PurchaseOrderHeader.ShipDate">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PurchaseOrderHeader.PurchaseOrderStatu.Name" ReadOnly="true" DataType="System.DateTime" FilterControlAltText="Filter PurchaseOrderHeader.PurchaseOrderStatu.Name column" HeaderText="Status" SortExpression="PurchaseOrderHeader.PurchaseOrderStatu.Name" UniqueName="PurchaseOrderHeader.PurchaseOrderStatu.Name">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Product.ProductCategory.Name" ReadOnly="true" DataType="System.String" FilterControlAltText="Filter Product.ProductCategory.Name column" HeaderText="Category" SortExpression="Product.ProductCategory.Name" UniqueName="Product.ProductCategory.Name">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
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
                <telerik:GridNumericColumn DataField="LineTotal" ReadOnly="true" DataType="System.Double" FilterControlAltText="Filter LineTotal column" HeaderText="LineTotal" SortExpression="LineTotal" UniqueName="LineTotal">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="ReceivedQuantity" DataType="System.Double" FilterControlAltText="Filter ReceivedQuantity column" HeaderText="ReceivedQuantity" SortExpression="ReceivedQuantity" UniqueName="ReceivedQuantity">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="ReturnedQuantity" DataType="System.Double" FilterControlAltText="Filter ReturnedQuantity column" HeaderText="ReturnedQuantity" SortExpression="ReturnedQuantity" UniqueName="ReturnedQuantity">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="StockedQuantity" ReadOnly="true" DataType="System.Double" FilterControlAltText="Filter StockedQuantity column" HeaderText="StockedQuantity" SortExpression="StockedQuantity" UniqueName="StockedQuantity">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridDateTimeColumn DataField="ModifiedDate" ReadOnly="true" DataType="System.DateTime" FilterControlAltText="Filter ModifiedDate column" HeaderText="ModifiedDate" SortExpression="ModifiedDate" UniqueName="ModifiedDate">
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