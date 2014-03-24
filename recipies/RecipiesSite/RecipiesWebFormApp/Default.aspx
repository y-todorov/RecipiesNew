<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RecipiesWebFormApp._Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <table>
        <tr>
            <td colspan="2">
                <telerik:RadHtmlChart runat="server" ID="rhcGP" Width="1600">
                    <PlotArea>
                        <Series>
                            <telerik:LineSeries DataFieldY="DayGp" Name="Value per day">
                            </telerik:LineSeries>
                        </Series>
                        <XAxis DataLabelsField="Days">
                        </XAxis>
                        <YAxis>
                            <TitleAppearance Text="Value"></TitleAppearance>
                        </YAxis>
                    </PlotArea>
                    <ChartTitle Text="GP per day (Last 30 days)">
                    </ChartTitle>
                </telerik:RadHtmlChart>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <telerik:RadHtmlChart runat="server" ID="rhcGpRecipies" Width="1600">
                    <PlotArea>
                        <Series>
                            <telerik:LineSeries DataFieldY="GrossProfit" Name="GP (Gross Profit)">
                                <LabelsAppearance DataFormatString="{0:P0}"></LabelsAppearance>
                                <TooltipsAppearance DataFormatString="{0:P0}" />
                            </telerik:LineSeries>
                            <%--  <telerik:LineSeries DataFieldY="SellValuePerPortion" Name="Sell Value Per Portion">
                                  <LabelsAppearance DataFormatString="{0:F2}"></LabelsAppearance>
                            </telerik:LineSeries>--%>
                        </Series>
                        <XAxis DataLabelsField="Name">
                        </XAxis>
                        <YAxis>
                            <TitleAppearance Text="Value"></TitleAppearance>
                        </YAxis>
                    </PlotArea>
                    <ChartTitle Text="Recipies by GP descending">
                    </ChartTitle>
                </telerik:RadHtmlChart>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadHtmlChart runat="server" ID="rhcLast10ModifiedProducts">
                    <PlotArea>
                        <Series>
                            <telerik:ColumnSeries DataFieldY="UnitsInStock" Name="Units In Stock">
                            </telerik:ColumnSeries>
                            <telerik:ColumnSeries DataFieldY="UnitsOnOrder" Name="Units On Order">
                            </telerik:ColumnSeries>
                        </Series>
                        <XAxis DataLabelsField="Name">
                        </XAxis>
                        <YAxis>
                            <TitleAppearance Text="Units"></TitleAppearance>
                        </YAxis>
                    </PlotArea>
                    <ChartTitle Text="Last 10 modified products">
                    </ChartTitle>
                </telerik:RadHtmlChart>
            </td>
            <td>
                <telerik:RadHtmlChart runat="server" ID="rhcProductsCountByCategory">
                    <PlotArea>
                        <Series>
                            <telerik:ColumnSeries DataFieldY="ProductCount" Name="Product count">
                            </telerik:ColumnSeries>
                            <telerik:ColumnSeries DataFieldY="ProductValue" Name="Product value">
                            </telerik:ColumnSeries>
                        </Series>
                        <XAxis DataLabelsField="CategoryName">
                        </XAxis>
                        <YAxis>
                            <TitleAppearance Text="Count"></TitleAppearance>
                        </YAxis>
                    </PlotArea>
                    <ChartTitle Text="Products count per category">
                    </ChartTitle>
                </telerik:RadHtmlChart>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadHtmlChart runat="server" ID="rhcProductsForReorder">
                    <PlotArea>
                        <Series>
                            <telerik:ColumnSeries DataFieldY="UnitsInStock" Name="Units In Stock">
                            </telerik:ColumnSeries>
                            <telerik:ColumnSeries DataFieldY="UnitsOnOrder" Name="Units On Order">
                            </telerik:ColumnSeries>
                            <telerik:ColumnSeries DataFieldY="ReorderLevel" Name="Reorder Level">
                            </telerik:ColumnSeries>
                        </Series>
                        <XAxis DataLabelsField="Name">
                        </XAxis>
                        <YAxis>
                            <TitleAppearance Text="Units"></TitleAppearance>
                        </YAxis>
                    </PlotArea>
                    <ChartTitle Text="Low products">
                    </ChartTitle>
                </telerik:RadHtmlChart>

            </td>
            <td>
                <telerik:RadHtmlChart runat="server" ID="rhcMostExpensiveProducts">
                    <PlotArea>
                        <Series>
                            <telerik:ColumnSeries DataFieldY="UnitPrice" Name="Unit Price">
                            </telerik:ColumnSeries>
                        </Series>
                        <XAxis DataLabelsField="Name">
                        </XAxis>
                        <YAxis>
                            <TitleAppearance Text="Price"></TitleAppearance>
                        </YAxis>
                    </PlotArea>
                    <ChartTitle Text="Top 10 most expensive products">
                    </ChartTitle>
                </telerik:RadHtmlChart>
            </td>
        </tr>
    </table>
</asp:Content>