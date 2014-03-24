<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseOrders.aspx.cs" Inherits="RecipiesWebFormApp.Purchasing.PurchaseOrders" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="yordan" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourcePurchaseOrders" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="PurchaseOrderHeaders" OnUpdating="OpenAccessLinqDataSourcePurchaseOrders_Updating">
    </yordan:YordanCustomOpenAccessLinqDataSource>
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceVendor" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Vendors" />
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceShipMethod" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="ShipMethods" />
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceEmployee" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Employees" />
    <!-- PurchaseOrderId are case sensitives !!!!!! -->

    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourcePurchaseOrder" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="PurchaseOrderHeaders" />
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceProduct" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Products"  OnSelecting="OpenAccessLinqDataSourceProduct_Selecting" />
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourcePurchaseOrderDetails" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="PurchaseOrderDetails" Where="PurchaseOrderId == @PurchaseOrderId" OnSelected="OpenAccessLinqDataSourcePurchaseOrderDetails_Selected" OnSelecting="OpenAccessLinqDataSourcePurchaseOrderDetails_Selecting" OnInserting="OpenAccessLinqDataSourcePurchaseOrderDetails_Inserting" OnUpdating="OpenAccessLinqDataSourcePurchaseOrderDetails_Updating" OnDeleted="OpenAccessLinqDataSourcePurchaseOrderDetails_Deleted" OnInserted="OpenAccessLinqDataSourcePurchaseOrderDetails_Inserted" OnUpdated="OpenAccessLinqDataSourcePurchaseOrderDetails_Updated" OnDeleting="OpenAccessLinqDataSourcePurchaseOrderDetails_Deleting" OnQueryCreated="OpenAccessLinqDataSourcePurchaseOrderDetails_QueryCreated">
        <WhereParameters>
            <asp:Parameter DefaultValue="0" Name="PurchaseOrderId" Type="Int32" />
        </WhereParameters>
    </yordan:YordanCustomOpenAccessLinqDataSource>
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceUnit" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="UnitMeasures" />

    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceStatus" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="PurchaseOrderStatus" Where="IsVisible == @IsVisible">
        <WhereParameters>
            <asp:Parameter DefaultValue="True" Name="IsVisible" Type="Boolean" />
        </WhereParameters>
    </yordan:YordanCustomOpenAccessLinqDataSource>
    <yordan:YordanCustomRadGrid ID="rgPurchaseOrders" runat="server" ItemType="RecipiesModelNS.PurchaseOrderHeader" DataSourceID="OpenAccessLinqDataSourcePurchaseOrders" OnItemCommand="rgPurchaseOrders_ItemCommand" OnItemCreated="rgPurchaseOrders_ItemCreated">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="PurchaseOrderId" DataSourceID="OpenAccessLinqDataSourcePurchaseOrders">
            <Columns>
                <telerik:GridBoundColumn DataField="PurchaseOrderId" DataType="System.Int32" FilterControlAltText="Filter PurchaseOrderId column" HeaderText="PurchaseOrderId" ReadOnly="True" SortExpression="PurchaseOrderId" UniqueName="PurchaseOrderId">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownEmployeeListColumn" ListTextField="FirstName"
                                            ListValueField="EmployeeId" DataSourceID="OpenAccessLinqDataSourceEmployee" HeaderText="Employee"
                                            DataField="EmployeeId" DropDownControlType="RadComboBox" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownVendorListVendor" ListTextField="Name"
                                            ListValueField="VendorId" DataSourceID="OpenAccessLinqDataSourceVendor" HeaderText="Vendor"
                                            DataField="VendorId" DropDownControlType="RadComboBox" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownShipMethodListColumn" ListTextField="Name"
                                            ListValueField="ShipMethodId" DataSourceID="OpenAccessLinqDataSourceShipMethod" HeaderText="ShipMethod"
                                            DataField="ShipMethodId" DropDownControlType="RadComboBox" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownStatusListColumn" ListTextField="Name"
                                            ListValueField="PurchaseOrderStatusId" DataSourceID="OpenAccessLinqDataSourceStatus" HeaderText="Status"
                                            DataField="StatusId" DropDownControlType="RadComboBox">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridBoundColumn DataField="InvoiceNumber" FilterControlAltText="Filter InvoiceNumber column" HeaderText="InvoiceNumber" SortExpression="InvoiceNumber" UniqueName="InvoiceNumber">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>

                <telerik:GridDateTimeColumn DataField="OrderDate" DataType="System.DateTime" FilterControlAltText="Filter OrderDate column" HeaderText="OrderDate" SortExpression="OrderDate" UniqueName="OrderDate">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridDateTimeColumn>
                <telerik:GridDateTimeColumn DataField="ShipDate" DataType="System.DateTime" FilterControlAltText="Filter ShipDate column" HeaderText="ShipDate" SortExpression="ShipDate" UniqueName="ShipDate">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridDateTimeColumn>
                <telerik:GridNumericColumn DataField="SubTotal" DataType="System.Decimal" FilterControlAltText="Filter SubTotal column" HeaderText="SubTotal" SortExpression="SubTotal" UniqueName="SubTotal">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="VAT" DataType="System.Decimal" FilterControlAltText="Filter VAT column" HeaderText="VAT" SortExpression="VAT" UniqueName="VAT">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="Freight" DataType="System.Decimal" FilterControlAltText="Filter Freight column" HeaderText="Freight" SortExpression="Freight" UniqueName="Freight">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="TotalDue" ReadOnly="true" DataType="System.Decimal" FilterControlAltText="Filter TotalDue column" HeaderText="TotalDue" SortExpression="TotalDue" UniqueName="TotalDue">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridHTMLEditorColumn DataField="Notes" MaxLength="4000" FilterControlAltText="Filter Notes column" HeaderText="Notes" SortExpression="Notes" UniqueName="Notes">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridHTMLEditorColumn>
                <telerik:GridBoundColumn DataField="ModifiedDate" ReadOnly="true" DataType="System.DateTime" FilterControlAltText="Filter ModifiedDate column" HeaderText="ModifiedDate" SortExpression="ModifiedDate" UniqueName="ModifiedDate">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ModifiedByUser" ReadOnly="true" FilterControlAltText="Filter ModifiedByUser column" HeaderText="ModifiedByUser" SortExpression="ModifiedByUser" UniqueName="ModifiedByUser">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn InsertVisiblityMode="AlwaysVisible" Visible="false" HeaderText="Purchasing products">
                    <ItemTemplate />
                    <EditItemTemplate>
                        <asp:Label runat="server" ID="lblPurchaseOrderDetails" ForeColor="Blue" Text="Please save the purchase order so products can be added to it." OnPreRender="lblPurchaseOrderDetails_PreRender"></asp:Label>
                        <yordan:YordanCustomRadGrid ID="rgPurchaseOrderDetails" runat="server" DataSourceID="OpenAccessLinqDataSourcePurchaseOrderDetails" OnItemCreated="rgPurchaseOrderDetails_ItemCreated" OnItemDataBound="rgPurchaseOrderDetails_ItemDataBound" OnCreateColumnEditor="rgPurchaseOrderDetails_CreateColumnEditor" OnPreRender="rgPurchaseOrderDetails_PreRender" OnItemCommand="rgPurchaseOrderDetails_ItemCommand">
                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="PurchaseOrderDetailId" DataSourceID="OpenAccessLinqDataSourcePurchaseOrderDetails">
                                <Columns>
                                    <telerik:GridDropDownColumn UniqueName="DropDownPurchaseOrderListColumn" Visible="false" ListTextField="PurchaseOrderId" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true"
                                                                ListValueField="PurchaseOrderId" DataSourceID="OpenAccessLinqDataSourcePurchaseOrder" ReadOnly="true" HeaderText="PurchaseOrder"
                                                                DataField="PurchaseOrderId" DropDownControlType="RadComboBox">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text=""></ModelErrorMessage>
                                        </ColumnValidationSettings>
                                    </telerik:GridDropDownColumn>
                                    <telerik:GridBoundColumn DataField="PurchaseOrderId" DataType="System.Int32" Visible="false" FilterControlAltText="Filter PurchaseOrderId column" HeaderText="PurchaseOrderId" ReadOnly="true" SortExpression="PurchaseOrderId" UniqueName="PurchaseOrderId">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridDropDownColumn UniqueName="DropDownProductListColumn" DataSourceID="OpenAccessLinqDataSourceProduct" ListTextField="Name" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true"
                                                                ListValueField="ProductId" HeaderText="Product"
                                                                DataField="ProductId" DropDownControlType="RadComboBox">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text=""></ModelErrorMessage>
                                        </ColumnValidationSettings>
                                    </telerik:GridDropDownColumn>
                                    <%--  <telerik:GridBoundColumn ReadOnly="true" DataField="Product.Code" FilterControlAltText="Filter Product.Code column" HeaderText="Product Code" SortExpression="Product.Code" UniqueName="Product.Code">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridDropDownColumn UniqueName="DropDownUnitListColumn" ListTextField="Name" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true"
                                                                ListValueField="UnitMeasureId" DataSourceID="OpenAccessLinqDataSourceUnit" HeaderText="UnitMeasure"
                                                                DataField="UnitMeasureId" DropDownControlType="RadComboBox">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text=""></ModelErrorMessage>
                                        </ColumnValidationSettings>
                                    </telerik:GridDropDownColumn>
                                    <telerik:GridNumericColumn DataField="OrderQuantity" DataType="System.Double" FilterControlAltText="Filter OrderQuantity column" HeaderText="OrderQuantity" SortExpression="OrderQuantity" UniqueName="OrderQuantity">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn DataField="UnitPrice" DataType="System.Decimal" FilterControlAltText="Filter UnitPrice column" HeaderText="UnitPrice" SortExpression="UnitPrice" UniqueName="UnitPrice">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn DataField="LineTotal" ReadOnly="true" DataType="System.Decimal" FilterControlAltText="Filter LineTotal column" HeaderText="LineTotal" SortExpression="LineTotal" UniqueName="LineTotal">
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
                                    <telerik:GridBoundColumn DataField="ModifiedDate" ReadOnly="true" DataType="System.DateTime" FilterControlAltText="Filter ModifiedDate column" HeaderText="ModifiedDate" SortExpression="ModifiedDate" UniqueName="ModifiedDate">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ModifiedByUser" ReadOnly="true" FilterControlAltText="Filter ModifiedByUser column" HeaderText="ModifiedByUser" SortExpression="ModifiedByUser" UniqueName="ModifiedByUser">
                                        <ColumnValidationSettings>
                                            <ModelErrorMessage Text="" />
                                        </ColumnValidationSettings>
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                        </yordan:YordanCustomRadGrid>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridButtonColumn ButtonType="LinkButton" Text="Download PO" UniqueName="Download" CommandName="GeneratePurchaseOrderReport"></telerik:GridButtonColumn>
                <telerik:GridButtonColumn ButtonType="LinkButton" Text="Send mail" CommandName="SendMail"></telerik:GridButtonColumn>
            </Columns>
        </MasterTableView>
    </yordan:YordanCustomRadGrid>

</asp:Content>