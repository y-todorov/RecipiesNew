<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeDepartment.aspx.cs" Inherits="RecipiesWebFormApp.HumanResources.Employee_department" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="yordan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <yordan:YordanCustomRadGrid ID="rgEmployeeDepartment" runat="server" CellSpacing="0" ItemType="RecipiesModelNS.EmployeeDepartment" DataSourceID="OpenAccessLinqDataSourceEmployeeDepartment" GridLines="None">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="EmployeeDepartmentId" DataSourceID="OpenAccessLinqDataSourceEmployeeDepartment">
            <Columns>
                <telerik:GridBoundColumn DataField="EmployeeDepartmentId" DataType="System.Int32" FilterControlAltText="Filter EmployeeDepartmentId column" HeaderText="EmployeeDepartmentId" ReadOnly="True" SortExpression="EmployeeDepartmentId" UniqueName="EmployeeDepartmentId">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownEmployeeListColumn" ListTextField="FirstName"
                                            ListValueField="EmployeeId" DataSourceID="OpenAccessLinqDataSourceEmployee" HeaderText="Employee"
                                            DataField="EmployeeId" DropDownControlType="RadComboBox" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>

                </telerik:GridDropDownColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownDepartmentListColumn" ListTextField="Name"
                                            ListValueField="DepartmentId" DataSourceID="OpenAccessLinqDataSourceDepartment" HeaderText="Department"
                                            DataField="DepartmentId" DropDownControlType="RadComboBox" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownShiftListColumn" ListTextField="Name"
                                            ListValueField="ShiftId" DataSourceID="OpenAccessLinqDataSourceShift" HeaderText="Shift"
                                            DataField="ShiftId" DropDownControlType="RadComboBox" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridDateTimeColumn DataField="StartDate"  DataType="System.DateTime" FilterControlAltText="Filter StartDate column" HeaderText="StartDate" SortExpression="StartDate" UniqueName="StartDate">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridDateTimeColumn>
                <telerik:GridDateTimeColumn DataField="EndDate"  DataType="System.DateTime" FilterControlAltText="Filter EndDate column" HeaderText="EndDate" SortExpression="EndDate" UniqueName="EndDate">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridDateTimeColumn>
                <telerik:GridDateTimeColumn DataField="ModifiedDate" ReadOnly="true" DataType="System.DateTime" FilterControlAltText="Filter ModifiedDate column" HeaderText="ModifiedDate" SortExpression="ModifiedDate" UniqueName="ModifiedDate">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridDateTimeColumn>
                <telerik:GridBoundColumn DataField="ModifiedByUser" ReadOnly="true" FilterControlAltText="Filter ModifiedByUser column" HeaderText="ModifiedByUser" SortExpression="ModifiedByUser" UniqueName="ModifiedByUser">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </yordan:YordanCustomRadGrid>
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceEmployeeDepartment" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="EmployeeDepartments">
    </yordan:YordanCustomOpenAccessLinqDataSource>
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceEmployee" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Employees" />
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceShift" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Shifts" />
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceDepartment" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Departments" />
</asp:Content>