<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shifts.aspx.cs" Inherits="RecipiesWebFormApp.HumanResources.Shifts" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="yordan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <yordan:YordanCustomRadGrid ID="rgShifts" runat="server" ItemType="RecipiesModelNS.Shift" DataSourceID="OpenAccessLinqDataSourceShifts">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="ShiftId" DataSourceID="OpenAccessLinqDataSourceShifts">
            <Columns>
                <telerik:GridBoundColumn DataField="ShiftId" DataType="System.Int32" FilterControlAltText="Filter ShiftId column" HeaderText="ShiftId" ReadOnly="True" SortExpression="ShiftId" UniqueName="ShiftId">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column" HeaderText="Name" SortExpression="Name" UniqueName="Name">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridDateTimeColumn  DataFormatString="{0:HH:mm}" ConvertEmptyStringToNull="true" PickerType="TimePicker" DataType="System.DateTime" DataField="StartHour" FilterControlAltText="Filter StartHour column" HeaderText="StartHour" SortExpression="StartHour" UniqueName="StartHour">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridDateTimeColumn>
                <telerik:GridDateTimeColumn DataFormatString="{0:HH:mm}" ConvertEmptyStringToNull="true" PickerType="TimePicker"  DataField="EndHour" DataType="System.DateTime" FilterControlAltText="Filter EndHour column" HeaderText="EndHour" SortExpression="EndHour" UniqueName="EndHour">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridDateTimeColumn>
                <telerik:GridDateTimeColumn DataField="ModifiedDate" PickerType="TimePicker" ReadOnly="true" DataType="System.DateTime" FilterControlAltText="Filter ModifiedDate column" HeaderText="ModifiedDate" SortExpression="ModifiedDate" UniqueName="ModifiedDate">
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
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceShifts" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Shifts">
    </yordan:YordanCustomOpenAccessLinqDataSource>
</asp:Content>