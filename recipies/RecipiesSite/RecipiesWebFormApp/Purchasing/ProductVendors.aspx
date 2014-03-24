<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductVendors.aspx.cs" Inherits="RecipiesWebFormApp.Purchasing.ProductVendors" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="yordan" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <yordan:YordanCustomRadGrid ID="rgProductVendors" runat="server" ItemType="RecipiesModelNS.ProductVendor" DataSourceID="OpenAccessLinqDataSourceProductVendors">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="ProductVendorId" DataSourceID="OpenAccessLinqDataSourceProductVendors">
            <%--            <GroupByExpressions>
                <telerik:GridGroupByExpression>
                    <SelectFields>
                        <telerik:GridGroupByField FieldName="ProductId" HeaderText="Yordan Price" />
                    </SelectFields>
                    <GroupByFields>
                        <telerik:GridGroupByField FieldName="ProductId" SortOrder="Descending" />
                    </GroupByFields>
                </telerik:GridGroupByExpression>
            </GroupByExpressions>--%>
            <Columns>
                <telerik:GridBoundColumn DataField="ProductVendorId" DataType="System.Int32" FilterControlAltText="Filter ProductVendorId column" HeaderText="ProductVendorId" ReadOnly="True" SortExpression="ProductVendorId" UniqueName="ProductVendorId">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownProductListColumn" ListTextField="Name" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true"
                                            ListValueField="ProductId" DataSourceID="OpenAccessLinqDataSourceProduct" HeaderText="Product"
                                            DataField="ProductId" DropDownControlType="RadComboBox">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownVendorListColumn" ListTextField="Name" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true"
                                            ListValueField="VendorId" DataSourceID="OpenAccessLinqDataSourceVendor" HeaderText="Vendor"
                                            DataField="VendorId" DropDownControlType="RadComboBox">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownUnitMeasureListColumn" ListTextField="Name" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true"
                                            ListValueField="UnitMeasureId" DataSourceID="OpenAccessLinqDataSourceUnitMeasure" HeaderText="UnitMeasure"
                                            DataField="UnitMeasureId" DropDownControlType="RadComboBox">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridNumericColumn DataField="AverageLeadTime" DataType="System.Double" FilterControlAltText="Filter AverageLeadTime column" HeaderText="AverageLeadTime" SortExpression="AverageLeadTime" UniqueName="AverageLeadTime">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="StandardPrice" DataType="System.Decimal" FilterControlAltText="Filter StandardPrice column" HeaderText="StandardPrice" SortExpression="StandardPrice" UniqueName="StandardPrice">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="LastReceiptCost" DataType="System.Decimal" FilterControlAltText="Filter LastReceiptCost column" HeaderText="LastReceiptCost" SortExpression="LastReceiptCost" UniqueName="LastReceiptCost">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridDateTimeColumn DataField="LastReceiptDate" DataType="System.DateTime" FilterControlAltText="Filter LastReceiptDate column" HeaderText="LastReceiptDate" SortExpression="LastReceiptDate" UniqueName="LastReceiptDate">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridDateTimeColumn>
                <telerik:GridBoundColumn DataField="MinOrderQuantity" DataType="System.Double" FilterControlAltText="Filter MinOrderQuantity column" HeaderText="MinOrderQuantity" SortExpression="MinOrderQuantity" UniqueName="MinOrderQuantity">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridNumericColumn DataField="MaxOrderQuantity" DataType="System.Double" FilterControlAltText="Filter MaxOrderQuantity column" HeaderText="MaxOrderQuantity" SortExpression="MaxOrderQuantity" UniqueName="MaxOrderQuantity">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="OnOrderQuantity" DataType="System.Double" FilterControlAltText="Filter OnOrderQuantity column" HeaderText="OnOrderQuantity" SortExpression="OnOrderQuantity" UniqueName="OnOrderQuantity">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridBoundColumn DataField="ModifiedDate" DataType="System.DateTime" FilterControlAltText="Filter ModifiedDate column" HeaderText="ModifiedDate" SortExpression="ModifiedDate" UniqueName="ModifiedDate">
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
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceProductVendors" runat="server" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntitySetName="ProductVendors">
    </yordan:YordanCustomOpenAccessLinqDataSource>
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceProduct" runat="server" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntitySetName="Products" />
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceVendor" runat="server" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntitySetName="Vendors" />
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceUnitMeasure" runat="server" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntitySetName="UnitMeasures" />
</asp:Content>