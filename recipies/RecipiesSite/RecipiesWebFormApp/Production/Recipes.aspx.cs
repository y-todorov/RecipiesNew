using RecipiesModelNS;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace RecipiesWebFormApp.Production
{
    public partial class Recipes : System.Web.UI.Page
    {
        public int RecipeId
        {
            get
            {
                int recipeId = (int) ViewState["RecipeId"];
                return recipeId;
            }
            set { ViewState["RecipeId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void OpenAccessLinqDataSourceRecipeIngredients_InsertedUpdatedDeleted(object sender,
            EntityDataSourceChangedEventArgs e)
        {
            // So value per portion will be updated
            rgRecipes.Rebind();
        }

        protected void rgRecipes_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.EditCommandName)
            {
                GridEditableItem editableItem = e.Item as GridEditableItem;
                if (editableItem != null)
                {
                    int recipeId = (int) editableItem.GetDataKeyValue(rgRecipes.MasterTableView.DataKeyNames[0]);
                    Recipe recipe =
                        ContextFactory.GetContextPerRequest().Recipes.FirstOrDefault(r => r.RecipeId == recipeId);
                    RecipeId = recipe.RecipeId;
                }
            }
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                RecipeId = 0;
            }
        }

        protected void OpenAccessLinqDataSourceRecipeIngredients_Inserting(object sender,
            EntityDataSourceChangingEventArgs e)
        {
            ProductIngredient newRecipeIngredient = e.Entity as ProductIngredient;
            if (newRecipeIngredient != null)
            {
                newRecipeIngredient.RecipeId = RecipeId;
            }
        }

        protected void OpenAccessLinqDataSourceRecipeIngredients_Selecting(object sender,
            EntityDataSourceSelectingEventArgs e)
        {
            // TO DO
            var test = e.SelectArguments;
            if (e.DataSource.WhereParameters["RecipeId"] != null)
            {
                e.DataSource.WhereParameters["RecipeId"].DefaultValue = RecipeId.ToString();
            }
        }

        protected void lblProductIngredients_PreRender(object sender, EventArgs e)
        {
            if (RecipeId > 0)
            {
                Label lblRecipeIngredients = (Label) sender;
                lblRecipeIngredients.Visible = false;
            }
        }

        protected void rgRecipeIngredients_PreRender(object sender, EventArgs e)
        {
            if (RecipeId <= 0)
            {
                RadGrid rgRecipeIngredients = (RadGrid) sender;
                rgRecipeIngredients.Visible = false;
            }
        }

        protected void rgRecipeIngredients_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem editedItem = (e.Item as GridEditableItem);
                RadComboBox dropDownProductListColumn =
                    editedItem["DropDownProductListColumn"].Controls[0] as RadComboBox;

                //attach SelectedIndexChanged event for the dropdown control  
                dropDownProductListColumn.AutoPostBack = true;
                dropDownProductListColumn.SelectedIndexChanged += dropDownProductListColumn_SelectedIndexChanged;
            }
        }

        private void dropDownProductListColumn_SelectedIndexChanged(object sender,
            RadComboBoxSelectedIndexChangedEventArgs e)
        {
            (sender as RadComboBox).ToolTip = (sender as RadComboBox).SelectedValue +
                                              (sender as RadComboBox).SelectedItem.Text;

            //first reference the edited grid item through the NamingContainer                                                     attribute  
            GridEditableItem editedItem = (sender as RadComboBox).NamingContainer as GridEditableItem;

            RadNumericTextBox tbCost = editedItem["Cost"].Controls[0] as RadNumericTextBox;
            RadComboBox dropDownProductListColumn = editedItem["DropDownProductListColumn"].Controls[0] as RadComboBox;
            string productId = dropDownProductListColumn.SelectedValue;
            tbCost.Text = "0";
            if (!string.IsNullOrEmpty(productId))
            {
                int intProductId;
                if (int.TryParse(productId, out intProductId))
                {
                    Product product =
                        ContextFactory.GetContextPerRequest().Products.FirstOrDefault(p => p.ProductId == intProductId);
                    if (product != null)
                    {
                        tbCost.Text = product.UnitPrice.GetValueOrDefault().ToString();
                            //.GetAveragePriceLastDays(14).ToString();
                    }

                    //ProductVendor productVendor = ContextFactory.GetContextPerRequest().ProductVendors.FirstOrDefault(pv => pv.ProductId == intProductId && pv.VendorId == VendorId);

                    //tbUnitPrice.Text = productVendor.StandardPrice.ToString();
                }
            }
        }
    }
}