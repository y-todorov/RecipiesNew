<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="RecipiesWebFormApp.Production.xProducts" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="yordan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <telerik:RadCodeBlock runat="server" ID="RadCodeBlock1">
        <script src="../Scripts/jquery-2.0.3.min.js"></script>
        <script src="../Scripts/jquery.signalR-1.1.3.js"></script>
        <script src="/signalr/hubs"></script>
        <script>
            var hub = $.connection.rebindHub;

            

            hub.client.rebindRadGrid = function () {

                var grid = window.$find("<%= ((RadGrid)rgProducts).ClientID %>");

            if (grid != null) {
                var masterTable = grid.get_masterTableView();
                var editedItemsArray = masterTable.get_editItems();
                var isItemInserted = masterTable.get_isItemInserted()
                if (editedItemsArray.length == 0 && !isItemInserted) {
                    masterTable.rebind();
                }
            }

        }

        $.connection.hub.start().done(function () {
            hub.server.AddToGroup($.connection, "test");
        });

    </script>


    </telerik:RadCodeBlock>--%>
    <yordan:YordanCustomRadGrid ID="rgProducts" runat="server" ItemType="RecipiesModelNS.Product" DataSourceID="OpenAccessLinqDataSourceProduct" CellSpacing="0" GridLines="None" EnableLinqExpressions="true">
        <ClientSettings>
        </ClientSettings>
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="ProductId" DataSourceID="OpenAccessLinqDataSourceProduct">            
            <Columns>
                <telerik:GridBoundColumn DataField="ProductId" DataType="System.Int32" FilterControlAltText="Filter ProductId column" HeaderText="ProductId" ReadOnly="True" SortExpression="ProductId" UniqueName="ProductId">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownUnitListColumn" ListTextField="Name" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true"
                                            ListValueField="UnitMeasureId" DataSourceID="OpenAccessLinqDataSourceUnit" HeaderText="UnitMeasure"
                                            DataField="UnitMeasureId" DropDownControlType="RadComboBox">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownCategoryListColumn" ListTextField="Name"
                                            ListValueField="CategoryId" DataSourceID="OpenAccessLinqDataSourceCategory" HeaderText="Category"
                                            DataField="CategoryId" DropDownControlType="RadComboBox" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownStoreListColumn" ListTextField="Name"
                                            ListValueField="StoreId" DataSourceID="OpenAccessLinqDataSourceStore" HeaderText="Store"
                                            DataField="StoreId" DropDownControlType="RadComboBox">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column" HeaderText="Name" SortExpression="Name" UniqueName="Name">
                    <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="This field is required!"></RequiredFieldValidator>
                        <ModelErrorMessage BackColor="Red" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Code" FilterControlAltText="Filter Code column" HeaderText="Code" SortExpression="Code" UniqueName="Code">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridNumericColumn DataField="UnitPrice" DataType="System.Decimal" FilterControlAltText="Filter UnitPrice column" HeaderText="UnitPrice" SortExpression="UnitPrice" UniqueName="UnitPrice">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="UnitsInStock" DataType="System.Double" FilterControlAltText="Filter UnitsInStock column" HeaderText="UnitsInStock" SortExpression="UnitsInStock" UniqueName="UnitsInStock">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="StockValue" ReadOnly="true" DataType="System.Double" FilterControlAltText="Filter StockValue column" HeaderText="StockValue" SortExpression="StockValue" UniqueName="StockValue">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="UnitsOnOrder" DataType="System.Double" FilterControlAltText="Filter UnitsOnOrder column" HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder" UniqueName="UnitsOnOrder">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="ReorderLevel" DataType="System.Double" FilterControlAltText="Filter ReorderLevel column" HeaderText="ReorderLevel" SortExpression="ReorderLevel" UniqueName="ReorderLevel">
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
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceStore" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Stores" />
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceProduct" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Products" >
    </yordan:YordanCustomOpenAccessLinqDataSource>
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceUnit" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="UnitMeasures" Where="IsBaseUnit == @IsBaseUnit" ConnectionString="name=recipiesEntities" ContextTypeName="" DefaultContainerName="RecipiesEntities" EntityTypeFilter="" Select="">
        <WhereParameters>
            <asp:Parameter DefaultValue="True" Name="IsBaseUnit" Type="Boolean" />
        </WhereParameters>
    </yordan:YordanCustomOpenAccessLinqDataSource>
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceVendor" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Vendors" />
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceCategory" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="ProductCategories" />
    <asp:Label Text="Update product unit price from all purchase orders since the last 14 days" runat="server" />
    <telerik:RadButton ID="rbUpdateUnitPrice" OnClick="rbUpdateUnitPrice_Click" runat="server" Text="Update UnitPrice"></telerik:RadButton>
    <br />
    <asp:Label ID="Label1" Text="Update product units in stock from all purchase orders that are completed" runat="server" />
    <telerik:RadButton ID="rbUpdateUnitsInStock" OnClick="rbUpdateUnitsInStock_Click" runat="server" Text="Update UnitsInStock"></telerik:RadButton>
    <br />
    <asp:Label ID="Label2" Text="Update product units on order from all purchase orders that are approved" runat="server" />
    <telerik:RadButton ID="rbUpdateUnitsOnOrder" OnClick="rbUpdateUnitsOnOrder_Click" runat="server" Text="Update UnitsOnOrder"></telerik:RadButton>

</asp:Content>