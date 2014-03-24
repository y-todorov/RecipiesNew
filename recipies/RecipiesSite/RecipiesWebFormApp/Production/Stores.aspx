<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stores.aspx.cs" Inherits="RecipiesWebFormApp.Sales.Stores" %>
<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="yordan" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <yordan:YordanCustomRadGrid ID="YordanCustomRadGrid1" runat="server" CellSpacing="0" DataSourceID="OpenAccessLinqDataSourceStore" GridLines="None">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="StoreId" DataSourceID="OpenAccessLinqDataSourceStore">
            <Columns>
                <telerik:GridBoundColumn DataField="StoreId" DataType="System.Int32" FilterControlAltText="Filter StoreId column" HeaderText="StoreId" ReadOnly="True" SortExpression="StoreId" UniqueName="StoreId">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column" HeaderText="Name" SortExpression="Name" UniqueName="Name">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ModifiedDate" DataType="System.DateTime" FilterControlAltText="Filter ModifiedDate column" HeaderText="ModifiedDate" SortExpression="ModifiedDate" UniqueName="ModifiedDate">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ModifiedByUser" FilterControlAltText="Filter ModifiedByUser column" HeaderText="ModifiedByUser" SortExpression="ModifiedByUser" UniqueName="ModifiedByUser">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </yordan:YordanCustomRadGrid>
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceStore" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Stores">
    </yordan:YordanCustomOpenAccessLinqDataSource>
</asp:Content>