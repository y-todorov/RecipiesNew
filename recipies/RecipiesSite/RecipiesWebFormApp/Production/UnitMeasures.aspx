<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UnitMeasures.aspx.cs" Inherits="RecipiesWebFormApp.Production.xUnits" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="YordanCustomControls" Namespace="YordanCustomControls" TagPrefix="yordan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <yordan:YordanCustomRadGrid ID="rgUnits" runat="server" ItemType="RecipiesModelNS.UnitMeasure" DataSourceID="OpenAccessLinqDataSourceUnit">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="UnitMeasureId" DataSourceID="OpenAccessLinqDataSourceUnit">
            <Columns>
                <telerik:GridBoundColumn DataField="UnitMeasureId" DataType="System.Int32" FilterControlAltText="Filter UnitId column" HeaderText="UnitId" ReadOnly="True" SortExpression="UnitMeasureId" UniqueName="UnitMeasureId">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text="" />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column" HeaderText="Name" SortExpression="Name" UniqueName="Name">
                    <ColumnValidationSettings>
                        <ModelErrorMessage />
                    </ColumnValidationSettings>
                </telerik:GridBoundColumn>
                <telerik:GridCheckBoxColumn DataField="IsBaseUnit" FilterControlAltText="Filter IsBaseUnit column" HeaderText="IsBaseUnit" SortExpression="IsBaseUnit" UniqueName="IsBaseUnit">
                </telerik:GridCheckBoxColumn>
                <telerik:GridNumericColumn DataField="BaseUnitFactor" DataType="System.Double" FilterControlAltText="Filter BaseUnitFactor column" HeaderText="BaseUnitFactor" SortExpression="BaseUnitFactor" UniqueName="BaseUnitFactor">                  
                </telerik:GridNumericColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownCategoryListColumn" ListTextField="Name"
                                            ListValueField="UnitMeasureId" DataSourceID="OpenAccessLinqDataSourceBaseUnit" HeaderText="BaseUnit"
                                            DataField="BaseUnitId" DropDownControlType="RadComboBox" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
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
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceUnit" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="UnitMeasures">
    </yordan:YordanCustomOpenAccessLinqDataSource>
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceBaseUnit" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="UnitMeasures" Where="" AutoGenerateWhereClause="True" ConnectionString="name=recipiesEntities" ContextTypeName="" DefaultContainerName="RecipiesEntities" EntityTypeFilter="" Select="">
        <WhereParameters>
            <asp:Parameter DefaultValue="True" Name="IsBaseUnit" Type="Boolean" />
        </WhereParameters>
    </yordan:YordanCustomOpenAccessLinqDataSource>
</asp:Content>