using RecipiesModelNS;
using System;
using System.Linq;
using System.Web.UI;
using Telerik.Web.UI;

namespace RecipiesWebFormApp.Production
{
    public partial class Inventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void YordanCustomRadGridInventory_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                GridEditableItem editedItem = (e.Item as GridEditableItem);
                RadComboBox dropDownProductListColumn =
                    editedItem["DropDownProductListColumn"].Controls[0] as RadComboBox;

                //attach SelectedIndexChanged event for the dropdown control  
                dropDownProductListColumn.AutoPostBack = true;
                dropDownProductListColumn.SelectedIndexChanged += dropDownProductListColumn_SelectedIndexChanged;
                dropDownProductListColumn.PreRender += dropDownProductListColumn_PreRender;

                RadDatePicker forDateRadDateTimePicker = editedItem["ForDate"].Controls[0] as RadDatePicker;
                forDateRadDateTimePicker.AutoPostBack = true;
                forDateRadDateTimePicker.SelectedDateChanged += ForDateRadDateTimePicker_SelectedDateChanged;


                RadNumericTextBox quantityByDocumentsRadNumericTextBox =
                    editedItem["QuantityByDocuments"].Controls[0] as RadNumericTextBox;
                quantityByDocumentsRadNumericTextBox.ReadOnly = true;
            }
        }

        private void ForDateRadDateTimePicker_SelectedDateChanged(object sender,
            Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            dropDownProductListColumn_SelectedIndexChanged(sender,
                new RadComboBoxSelectedIndexChangedEventArgs(string.Empty, string.Empty, string.Empty, string.Empty));
        }

        private void dropDownProductListColumn_PreRender(object sender, EventArgs e)
        {
            dropDownProductListColumn_SelectedIndexChanged(sender,
                new RadComboBoxSelectedIndexChangedEventArgs(string.Empty, string.Empty, string.Empty, string.Empty));
        }

        private void dropDownProductListColumn_SelectedIndexChanged(object sender,
            RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //first reference the edited grid item through the NamingContainer                                                       
            GridEditableItem editedItem = (sender as Control).NamingContainer as GridEditableItem;

            RadComboBox dropDownProductListColumn = editedItem["DropDownProductListColumn"].Controls[0] as RadComboBox;
            string productId = dropDownProductListColumn.SelectedValue;
            if (!string.IsNullOrEmpty(productId))
            {
                int intProductId;
                if (int.TryParse(productId, out intProductId))
                {
                    Product product =
                        ContextFactory.GetContextPerRequest().Products.FirstOrDefault(p => p.ProductId == intProductId);
                    if (product != null)
                    {
                        RadNumericTextBox quantityByDocumentsRadNumericTextBox =
                            editedItem["QuantityByDocuments"].Controls[0] as RadNumericTextBox;
                        RadNumericTextBox averageUnitPriceRadNumericTextBox =
                            editedItem["AverageUnitPrice"].Controls[0] as RadNumericTextBox;
                        RadDatePicker ForDateRadDateTimePicker = editedItem["ForDate"].Controls[0] as RadDatePicker;

                        averageUnitPriceRadNumericTextBox.Text = product.UnitPrice.GetValueOrDefault().ToString();
                        quantityByDocumentsRadNumericTextBox.Text =
                            product.GetQuantityByDocumentsForDate(
                                ForDateRadDateTimePicker.SelectedDate.GetValueOrDefault()).ToString();
                        quantityByDocumentsRadNumericTextBox.ToolTip = "Price";
                    }
                }
            }
        }

        protected void YordanCustomRadGridInventory_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                RecipiesModelNS.ProductInventory inventory = new RecipiesModelNS.ProductInventory
                {
                    //ForDate = DateTime.Now.Date
                };
                e.Item.OwnerTableView.InsertItem(inventory);
            }
        }
    }
}