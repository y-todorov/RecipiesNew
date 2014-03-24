<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCategories.aspx.cs" Inherits="RecipiesWebFormApp.Production.xCategories" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="yordan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <yordan:YordanCustomRadGrid ID="rgCategories" runat="server" ItemType="RecipiesModelNS.ProductCategory" DataSourceID="OpenAccessLinqDataSourceCategory">

        <MasterTableView DataKeyNames="CategoryId" DataSourceID="OpenAccessLinqDataSourceCategory">
            <Columns>
                <telerik:GridBoundColumn DataField="CategoryId" DataType="System.Int32" FilterControlAltText="Filter CategoryId column" HeaderText="CategoryId" ReadOnly="True" SortExpression="CategoryId" UniqueName="CategoryId">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column" HeaderText="Name" SortExpression="Name" UniqueName="Name">
                    <ColumnValidationSettings>
                        <ModelErrorMessage />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
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

    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceCategory" runat="server" EntitySetName="ProductCategories">
    </yordan:YordanCustomOpenAccessLinqDataSource>
</asp:Content>