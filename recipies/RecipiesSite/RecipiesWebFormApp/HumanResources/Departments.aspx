<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="RecipiesWebFormApp.HumanResources.Departments" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="yordan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <yordan:YordanCustomRadGrid ID="rgDepartment" runat="server" ItemType="RecipiesModelNS.Department" DataSourceID="OpenAccessLinqDataSourceDepartments">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="DepartmentId" DataSourceID="OpenAccessLinqDataSourceDepartments">
            <Columns>
                <telerik:GridBoundColumn DataField="DepartmentId" DataType="System.Int32" FilterControlAltText="Filter DepartmentId column" HeaderText="DepartmentId" ReadOnly="True" SortExpression="DepartmentId" UniqueName="DepartmentId">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column" HeaderText="Name" SortExpression="Name" UniqueName="Name">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
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
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceDepartments" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Departments">
    </yordan:YordanCustomOpenAccessLinqDataSource>
</asp:Content>