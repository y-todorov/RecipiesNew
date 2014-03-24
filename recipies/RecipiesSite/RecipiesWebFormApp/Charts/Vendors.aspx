<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vendors.aspx.cs" Inherits="RecipiesWebFormApp.Charts.Vendors" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <cc1:YordanCustomOpenAccessLinqDataSource ID="YordanCustomOpenAccessLinqDataSource1" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"    EntitySetName="Vendors">
    </cc1:YordanCustomOpenAccessLinqDataSource>
    <telerik:RadComboBox runat="server" AutoPostBack="True" DataSourceID="YordanCustomOpenAccessLinqDataSource1" DataTextField="Name" DataValueField="VendorId" ID="rcbVendor" OnSelectedIndexChanged="rcbVendor_SelectedIndexChanged">
    </telerik:RadComboBox>
    <telerik:RadHtmlChart runat="server" ID="rhcVendorsLastWeek">
        <PlotArea>
            <Series>
                <telerik:LineSeries DataFieldY="VendorValue" Name="Vendor Name">
                </telerik:LineSeries>
            </Series>
            <XAxis DataLabelsField="Week">
                <TitleAppearance Position="Center" RotationAngle="0" Text="Week" />
            </XAxis>
            <YAxis>
                <TitleAppearance Text="Value">
                </TitleAppearance>
            </YAxis>
        </PlotArea>
        <ChartTitle Text="Vendor purchases per week">
        </ChartTitle>
    </telerik:RadHtmlChart>
</asp:Content>