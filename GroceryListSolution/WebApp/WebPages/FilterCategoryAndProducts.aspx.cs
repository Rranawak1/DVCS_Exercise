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
            CategoryController sysmgr = new CategoryController();
            List<Category> info = sysmgr.Category_List();
            info.Sort((x, y) => x.Description.CompareTo(y.Description));
            CategoryList.DataSource = info;
            CategoryList.DataTextField = nameof(Category.Description);
            CategoryList.DataValueField = nameof(Category.CategoryID);
            CategoryList.DataBind();
        }

        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow agrow = ProductList.Rows[ProductList.SelectedIndex];
            string productid = (agrow.FindControl("ProductID") as Label).Text;
        }

        //protected void AlbumList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //access data located on the gridviewrow
        //    //template web control access syntax
        //    GridViewRow agvrow = AlbumList.Rows[AlbumList.SelectedIndex]; // the row is selected that's pointed at
        //    string albumid = (agvrow.FindControl("AlbumID") as Label).Text; // will allow me to find any field in that row even though the data is hidden
        //                                                                    //albumid = "0"; //testing to cause an error REMOVE WHEN Finished testing

        //    MessageUserControl.TryRun(() => {
        //        //standard lookup
        //        AlbumController sysmgr = new AlbumController();
        //        Album datainfo = sysmgr.Album_Get(int.Parse(albumid));
        //        if (datainfo == null) //to check if there's items in the list use .Count
        //        {
        //            ClearControls(); // only activated if this part of the if statement is valid
        //            throw new Exception("No records found for selected album. Refresh your list of albums");
        //        }
        //        else
        //        {
        //            EditAlbumID.Text = datainfo.AlbumId.ToString();
        //            EditTitle.Text = datainfo.Title;
        //            EditAlbumArtistList.SelectedValue = datainfo.ArtistId.ToString();
        //            EditReleaseYear.Text = datainfo.ReleaseYear.ToString();
        //            EditReleaseLabel.Text = datainfo.ReleaseLabel == null ? "" : datainfo.ReleaseLabel;
        //        }

        //    }, "Album Search", "View Album Details");

        //}
    }
}