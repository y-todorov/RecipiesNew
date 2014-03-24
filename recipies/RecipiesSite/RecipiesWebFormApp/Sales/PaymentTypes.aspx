<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentTypes.aspx.cs" Inherits="RecipiesWebFormApp.Sales.PaymentTypes" %>
<%@ Register assembly="YordanCustomControls" namespace="YordanCustomControls" tagprefix="yordan" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <yordan:YordanCustomRadGrid ID="rgPaymentTypes" runat="server" CellSpacing="0" DataSourceID="OpenAccessLinqDataSourcePaymentTypes" GridLines="None">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="PaymentTypeId" DataSourceID="OpenAccessLinqDataSourcePaymentTypes">
            <Columns>
                <telerik:GridBoundColumn DataField="PaymentTypeId" DataType="System.Int32" FilterControlAltText="Filter PaymentTypeId column" HeaderText="PaymentTypeId" ReadOnly="True" SortExpression="PaymentTypeId" UniqueName="PaymentTypeId">
                    <columnvalidationsettings>
                        <modelerrormessage text=""></modelerrormessage>
                    </columnvalidationsettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column" HeaderText="Name" SortExpression="Name" UniqueName="Name">
                    <columnvalidationsettings>
                        <modelerrormessage text=""></modelerrormessage>
                    </columnvalidationsettings>
                </telerik:GridBoundColumn>
                <telerik:GridDateTimeColumn DataField="ModifiedDate" DataType="System.DateTime" FilterControlAltText="Filter ModifiedDate column" HeaderText="ModifiedDate" SortExpression="ModifiedDate" UniqueName="ModifiedDate">
                    <columnvalidationsettings>
                        <modelerrormessage text=""></modelerrormessage>
                    </columnvalidationsettings>
                </telerik:GridDateTimeColumn>
                <telerik:GridBoundColumn DataField="ModifiedByUser" FilterControlAltText="Filter ModifiedByUser column" HeaderText="ModifiedByUser" SortExpression="ModifiedByUser" UniqueName="ModifiedByUser">
                    <columnvalidationsettings>
                        <modelerrormessage text=""></modelerrormessage>
                    </columnvalidationsettings>
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </yordan:YordanCustomRadGrid>
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourcePaymentTypes" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="PaymentTypes">
    </yordan:YordanCustomOpenAccessLinqDataSource>
</asp:Content>