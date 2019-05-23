using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using GroceryListSystem.BLL;
using GroceryList.Data.Entities;
#endregion

namespace WebApp.WebPages
{
    public partial class FilterCategoryAndProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCategory();
            }
        }

        protected void BindCategory()
        {
			MessageUserControl.TryRun(() =>
			{
				CategoryController sysmgr = new CategoryController();
				List<Category> info = sysmgr.Category_List();
				info.Sort((x, y) => x.Description.CompareTo(y.Description));
				CategoryList.DataSource = info;
				CategoryList.DataTextField = nameof(Category.Description);
				CategoryList.DataValueField = nameof(Category.CategoryID);
				CategoryList.DataBind();
			});
            
        }

        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow agrow = ProductList.Rows[ProductList.SelectedIndex];
            string productid = (agrow.FindControl("ProductID") as Label).Text;
        }
    }
}