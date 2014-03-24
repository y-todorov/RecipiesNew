<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecipeIngredients.aspx.cs" Inherits="RecipiesWebFormApp.Production.RecipeIngredients" %>
<%@ Register assembly="YordanCustomControls" namespace="YordanCustomControls" tagprefix="yordan" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <yordan:YordanCustomRadGrid ID="YordanCustomRadGrid1" runat="server" CellSpacing="0" ItemType="RecipiesModelNS.RecipeIngredient" DataSourceID="OpenAccessLinqDataSourceRecipeIngredients" GridLines="None">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="RecipeIngredientId" DataSourceID="OpenAccessLinqDataSourceRecipeIngredients">
            <Columns>
                <telerik:GridBoundColumn DataField="RecipeIngredientId" DataType="System.Int32" FilterControlAltText="Filter RecipeIngredientId column" HeaderText="RecipeIngredientId" ReadOnly="True" SortExpression="RecipeIngredientId" UniqueName="RecipeIngredientId">
                    <columnvalidationsettings>
                        <modelerrormessage text=""></modelerrormessage>
                    </columnvalidationsettings>
                </telerik:GridBoundColumn>
                <telerik:GridDropDownColumn UniqueName="DropDownRecipeListColumn" ListTextField="Name" 
                                            ListValueField="RecipeId" DataSourceID="OpenAccessLinqDataSourceRecipe" HeaderText="Recipe"
                                            DataField="RecipeId" DropDownControlType="RadComboBox">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>               
                <telerik:GridDropDownColumn UniqueName="DropDownProductListColumn" ListTextField="Name" 
                                            ListValueField="ProductId" DataSourceID="OpenAccessLinqDataSourceProduct" HeaderText="Product"
                                            DataField="ProductId" DropDownControlType="RadComboBox">
                    <ColumnValidationSettings>
                        <ModelErrorMessage Text=""></ModelErrorMessage>
                    </ColumnValidationSettings>
                </telerik:GridDropDownColumn>             
                <telerik:GridNumericColumn DataField="QuantityPerPortion" DataType="System.Double" FilterControlAltText="Filter QuantityPerPortion column" HeaderText="QuantityPerPortion" SortExpression="QuantityPerPortion" UniqueName="QuantityPerPortion">
                    <columnvalidationsettings>
                        <modelerrormessage text=""></modelerrormessage>
                    </columnvalidationsettings>
                </telerik:GridNumericColumn>
                <telerik:GridNumericColumn DataField="Cost" DataType="System.Decimal" FilterControlAltText="Filter Cost column" HeaderText="Cost" SortExpression="Cost" UniqueName="Cost">
                    <columnvalidationsettings>
                        <modelerrormessage text=""></modelerrormessage>
                    </columnvalidationsettings>
                </telerik:GridNumericColumn>
                <telerik:GridBoundColumn DataField="ModifiedDate" DataType="System.DateTime" FilterControlAltText="Filter ModifiedDate column" HeaderText="ModifiedDate" SortExpression="ModifiedDate" UniqueName="ModifiedDate">
                    <columnvalidationsettings>
                        <modelerrormessage text=""></modelerrormessage>
                    </columnvalidationsettings>
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ModifiedByUser" FilterControlAltText="Filter ModifiedByUser column" HeaderText="ModifiedByUser" SortExpression="ModifiedByUser" UniqueName="ModifiedByUser">
                    <columnvalidationsettings>
                        <modelerrormessage text=""></modelerrormessage>
                    </columnvalidationsettings>
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </yordan:YordanCustomRadGrid>
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceRecipeIngredients" Runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="RecipeIngredients" />

    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceProduct" Runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Products" />
    <yordan:YordanCustomOpenAccessLinqDataSource ID="OpenAccessLinqDataSourceRecipe" Runat="server"   EnableDelete="True" EnableInsert="True" EnableUpdate="True"   EntitySetName="Recipes" />

</asp:Content>