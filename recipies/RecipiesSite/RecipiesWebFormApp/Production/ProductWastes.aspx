<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductWastes.aspx.cs" Inherits="RecipiesWebFormApp.Production.ProductWaste" %>

<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="yordan" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <yordan:YordanCustomOpenAccessLinqDataSource ID="YordanCustomOpenAccessLinqDataSource1" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Wastes" ConnectionString="name=recipiesEntities" DefaultContainerName="RecipiesEntities" EnableFlattening="False" EntityTypeFilter="ProductWaste">
    </yordan:YordanCustomOpenAccessLinqDataSource>
    <yordan:YordanCustomRadGrid ID="YordanCustomRadGrid1" runat="server" DataSourceID="YordanCustomOpenAccessLinqDataSource1">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="WasteId" DataSourceID="YordanCustomOpenAccessLinqDataSource1">
            <Columns>
                <telerik:GridBoundColumn DataField="ProductWasteId" DataType="System.Int32" FilterControlAltText="Filter ProductWasteId column" HeaderText="ProductWasteId" ReadOnly="True" SortExpression="ProductWasteId" UniqueName="ProductWasteId">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownProductListColumn" ListTextField="Name"
                                            ListValueField="ProductId" DataSourceID="OpenAccessLinqDataSourceProduct" HeaderText="Product"
                                            DataField="ProductId" DropDownControlType="RadComboBox">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownUnitListColumn" ListTextField="Name" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true"
                                            ListValueField="UnitMeasureId" DataSourceID="OpenAccessLinqDataSourceUnit" HeaderText="UnitMeasure"
                                            DataField="UnitMeasureId" DropDownControlType="RadComboBox">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridNumericColumn DataField="Quantity" DataType="System.Double" FilterControlAltText="Filter Quantity column" HeaderText="Quantity" SortExpression="Quantity" UniqueName="Quantity">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="UnitPrice" DataType="System.Decimal" FilterControlAltText="Filter UnitPrice column" HeaderText="UnitPrice" SortExpression="UnitPrice" UniqueName="UnitPrice">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="WasteValue" DataType="System.Double" FilterControlAltText="Filter WasteValue column" HeaderText="WasteValue" ReadOnly="True" SortExpression="WasteValue" UniqueName="WasteValue">
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
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceUnit" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="UnitMeasures">
    </yordan:YordanCustomOpenAccessLinqDataSource>
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceProduct" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Products" />

</asp:Content>