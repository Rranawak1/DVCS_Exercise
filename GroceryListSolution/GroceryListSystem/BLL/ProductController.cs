using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using System.ComponentModel;
using GroceryListSystem.DAL;
using GroceryList.Data.Entities;
#endregion

namespace GroceryListSystem.BLL
{
    [DataObject]
    public class ProductController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Product> Product_List()
        {
            using (var context = new GrocerySystemContext())
            {
                return context.Products.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Product Product_Get(int productId)
        {
            using (var context = new GrocerySystemContext())
            {
                return context.Products.Find(productId);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Product> Category_GetByProduct(int categoryid)
        {
            using (var context = new GrocerySystemContext())
            {
                var results = from x in context.Products
                              where x.CategoryID == categoryid
                              select x;
                return results.ToList();
            }
        }


        #region Add,Update,Delete 

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public int Product_Add(Product item)
        {
            using (var context = new GrocerySystemContext())
            {
                context.Products.Add(item); // stage add action
                context.SaveChanges(); // EntityValidation is executed. it's what puts things on the database
                return item.ProductID;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public int Product_Update(Product item)
        {
            using (var context = new GrocerySystemContext())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges();
            }
        }
        //The overloaded Delete Method

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public int Product_Delete(Product item)
        {
            return Product_Delete(item.ProductID);
        }

        public int Product_Delete(int productID)
        {
            using (var context = new GrocerySystemContext())
            {
                var existing = context.Products.Find(productID);
                context.Products.Remove(existing);
                return context.SaveChanges();
            }
        }
        


        #endregion
    }

}
