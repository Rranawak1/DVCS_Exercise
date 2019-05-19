using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel;
using GroceryList.Data.Entities;
using GroceryListSystem.DAL;
#endregion

namespace GroceryListSystem.BLL
{
    [DataObject]
    public class CategoryController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Category> Category_List()
        {
            using (var context = new GrocerySystemContext())
            {
                return context.Categories.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Category Category_Get(int categoryId)
        {
            using (var context = new GrocerySystemContext())
            {
                return context.Categories.Find(categoryId);
            }
        }
    }
}
