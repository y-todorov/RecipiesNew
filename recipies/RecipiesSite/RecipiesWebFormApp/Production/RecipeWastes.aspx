<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecipeWastes.aspx.cs" Inherits="RecipiesWebFormApp.Production.RecipeWastes" %>
<%@ Register assembly="YordanCustomControls" namespace="YordanCustomControls" tagprefix="yordan" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceRecipe" Runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Recipes" />
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceUnit" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="UnitMeasures">
    </yordan:YordanCustomOpenAccessLinqDataSource>
    <yordan:YordanCustomRadGrid ID="YordanCustomRadGrid1" runat="server" DataSourceID="oaldsRecipeWastes">

        <MasterTableView AutoGenerateColumns="False" DataKeyNames="WasteId" DataSourceID="oaldsRecipeWastes">
            <Columns>
                <telerik:GridBoundColumn DataField="RecipeWasteId" DataType="System.Int32" FilterControlAltText="Filter RecipeWasteId column" HeaderText="RecipeWasteId" ReadOnly="True" SortExpression="RecipeWasteId" UniqueName="RecipeWasteId">
                    <columnvalidationsettings>
                        <modelerrormessage text=""></modelerrormessage>
                    </columnvalidationsettings>
                </telerik:GridBoundColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownRecipeListColumn" ListTextField="Name"
                                            ListValueField="RecipeId" DataSourceID="OpenAccessLinqDataSourceRecipe" HeaderText="Recipe"
                                            DataField="RecipeId" DropDownControlType="RadComboBox" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true">
                </telerik:GridDropDownColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownUnitListColumn" ListTextField="Name" EmptyListItemText="" EnableEmptyListItem="true" EmptyListItemValue="" ConvertEmptyStringToNull="true"
                                            ListValueField="UnitMeasureId" DataSourceID="OpenAccessLinqDataSourceUnit" HeaderText="UnitMeasure"
                                            DataField="UnitMeasureId" DropDownControlType="RadComboBox">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>
                <telerik:GridNumericColumn DataField="Quantity" DataType="System.Double" FilterControlAltText="Filter Quantity column" HeaderText="Quantity" SortExpression="Quantity" UniqueName="Quantity">
                    <columnvalidationsettings>
                        <modelerrormessage text=""></modelerrormessage>
                    </columnvalidationsettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="WasteValue" DataType="System.Double" FilterControlAltText="Filter WasteValue column" HeaderText="WasteValue" ReadOnly="True" SortExpression="WasteValue" UniqueName="WasteValue">
                    <columnvalidationsettings>
                        <modelerrormessage text=""></modelerrormessage>
                    </columnvalidationsettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="UnitPrice" DataType="System.Decimal" FilterControlAltText="Filter UnitPrice column" HeaderText="UnitPrice" SortExpression="UnitPrice" UniqueName="UnitPrice">
                    <columnvalidationsettings>
                        <modelerrormessage text=""></modelerrormessage>
                    </columnvalidationsettings>
                </telerik:GridNumericColumn>
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
    <yordan:YordanCustomOpenAccessLinqDataSource ID="oaldsRecipeWastes" runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Wastes" ConnectionString="name=recipiesEntities" DefaultContainerName="RecipiesEntities" EnableFlattening="False" EntityTypeFilter="RecipeWaste">
    </yordan:YordanCustomOpenAccessLinqDataSource>
</asp:Content>