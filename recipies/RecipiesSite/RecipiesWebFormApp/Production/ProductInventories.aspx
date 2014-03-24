<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductInventories.aspx.cs" Inherits="RecipiesWebFormApp.Production.Inventory" %>
<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="yordan" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceProduct" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Products" />
    <yordan:YordanCustomRadGrid ID="YordanCustomRadGridInventory"  runat="server" CellSpacing="0" ItemType="RecipiesModelNS.Inventory" DataSourceID="OpenAccessLinqDataSourceInventory" GridLines="None" OnItemCreated="YordanCustomRadGridInventory_ItemCreated" OnItemCommand="YordanCustomRadGridInventory_ItemCommand">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="InventoryId" DataSourceID="OpenAccessLinqDataSourceInventory">
            <%--<GroupByExpressions>
                <telerik:GridGroupByExpression>
                    <GroupByFields>
                        <telerik:GridGroupByField FieldName="Product.ProductCategory.Name" HeaderText="Category" Aggregate="None"  />
                    </GroupByFields>
                    <SelectFields>
                        <telerik:GridGroupByField FieldName="Product.ProductCategory.Name" HeaderText="Category" Aggregate="None" />
                    </SelectFields>
                </telerik:GridGroupByExpression>
            </GroupByExpressions>--%>
            <Columns>
                <telerik:GridBoundColumn DataField="InventoryId" DataType="System.Int32" FilterControlAltText="Filter InventoryId column" HeaderText="InventoryId" ReadOnly="True" SortExpression="InventoryId" UniqueName="InventoryId">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownProductListColumn" ListTextField="Name" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true"
                                            ListValueField="ProductId" DataSourceID="OpenAccessLinqDataSourceProduct" HeaderText="Product"
                                            DataField="ProductId" DropDownControlType="RadComboBox">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridBoundColumn DataField="Product.ProductCategory.Name" ReadOnly="true" DataType="System.String" FilterControlAltText="Filter Product.ProductCategory.Name column" HeaderText="Category" SortExpression="Product.ProductCategory.Name" UniqueName="Product.ProductCategory.Name">
    
                </telerik:GridBoundColumn>            
                <telerik:GridDateTimeColumn DataField="ForDate" DataType="System.DateTime" FilterControlAltText="Filter ForDate column" HeaderText="ForDate" SortExpression="ForDate" UniqueName="ForDate">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDateTimeColumn>
                <telerik:GridNumericColumn DataField="AverageUnitPrice" DataType="System.Decimal" FilterControlAltText="Filter AverageUnitPrice column" HeaderText="AverageUnitPrice" SortExpression="AverageUnitPrice" UniqueName="AverageUnitPrice">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="QuantityByDocuments" DataType="System.Double" FilterControlAltText="Filter QuantityByDocuments column" HeaderText="QuantityByDocuments" SortExpression="QuantityByDocuments" UniqueName="QuantityByDocuments">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="ValueByDocuments" ReadOnly="true" DataType="System.Decimal" FilterControlAltText="Filter ValueByDocuments column" HeaderText="ValueByDocuments" SortExpression="ValueByDocuments" UniqueName="ValueByDocuments">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="StocktakeQuantity" DataType="System.Double" FilterControlAltText="Filter StocktakeQuantity column" HeaderText="StocktakeQuantity" SortExpression="StocktakeQuantity" UniqueName="StocktakeQuantity">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn ReadOnly="true" DataField="StocktakeValue" DataType="System.Decimal" FilterControlAltText="Filter StocktakeValue column" HeaderText="StocktakeValue" SortExpression="StocktakeValue" UniqueName="StocktakeValue">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="DeficiencyQuantity" ReadOnly="true" DataType="System.Double" FilterControlAltText="Filter DeficiencyQuantity column" HeaderText="DeficiencyQuantity" SortExpression="DeficiencyQuantity" UniqueName="DeficiencyQuantity">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="DeficiencyValue" ReadOnly="true" DataType="System.Decimal" FilterControlAltText="Filter DeficiencyValue column" HeaderText="DeficiencyValue" SortExpression="DeficiencyValue" UniqueName="DeficiencyValue">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="SurplusQuantity" ReadOnly="true" DataType="System.Double" FilterControlAltText="Filter SurplusQuantity column" HeaderText="SurplusQuantity" SortExpression="SurplusQuantity" UniqueName="SurplusQuantity">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="SurplusValue" ReadOnly="true" DataType="System.Decimal" FilterControlAltText="Filter SurplusValue column" HeaderText="SurplusValue" SortExpression="SurplusValue" UniqueName="SurplusValue">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridDateTimeColumn DataField="ModifiedDate" DataType="System.DateTime" FilterControlAltText="Filter ModifiedDate column" HeaderText="ModifiedDate" SortExpression="ModifiedDate" UniqueName="ModifiedDate">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDateTimeColumn>
                <telerik:GridBoundColumn DataField="ModifiedByUser" FilterControlAltText="Filter ModifiedByUser column" HeaderText="ModifiedByUser" SortExpression="ModifiedByUser" UniqueName="ModifiedByUser">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </yordan:YordanCustomRadGrid>
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceInventory" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Inventories" Include="Product.ProductCategory, Product" ConnectionString="name=recipiesEntities" DefaultContainerName="RecipiesEntities" EnableFlattening="False" EntityTypeFilter="ProductInventory" />

</asp:Content>