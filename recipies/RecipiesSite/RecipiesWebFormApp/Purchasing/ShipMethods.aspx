<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShipMethods.aspx.cs" Inherits="RecipiesWebFormApp.Purchasing.ShipMethods" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="yordan" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <yordan:YordanCustomRadGrid ID="rgShipMethod" runat="server" ItemType="RecipiesModelNS.ShipMethod" DataSourceID="OpenAccessLinqDataSourceShipMethod">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="ShipMethodId" DataSourceID="OpenAccessLinqDataSourceShipMethod">
            <Columns>
                <telerik:GridBoundColumn DataField="ShipMethodId" DataType="System.Int32" FilterControlAltText="Filter ShipMethodId column" HeaderText="ShipMethodId" ReadOnly="True" SortExpression="ShipMethodId" UniqueName="ShipMethodId">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column" HeaderText="Name" SortExpression="Name" UniqueName="Name">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridNumericColumn DataField="ShipBase" DataType="System.Decimal" FilterControlAltText="Filter ShipBase column" HeaderText="ShipBase" SortExpression="ShipBase" UniqueName="ShipBase">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="ShipRate" DataType="System.Decimal" FilterControlAltText="Filter ShipRate column" HeaderText="ShipRate" SortExpression="ShipRate" UniqueName="ShipRate">
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
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceShipMethod" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="ShipMethods">
    </yordan:YordanCustomOpenAccessLinqDataSource>
</asp:Content>