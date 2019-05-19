using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GroceryList.Data.Entities
{
    public partial class Picker
    {
        public int PickerID { get; set; }

        [Required]
        [StringLength(35)]
        public string LastName { get; set; }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        public bool Active { get; set; }

        public int StoreID { get; set; }

        public virtual Store Store { get; set; }

        #region Not-Mapped Properties 
        // NotMapped Properties are properties that exist on the Entity, but not in the Database
        // These properties help us make our properties expressive. For example getting the full name instead of the first and last name seperately
        public string FullName
        { get { return FirstName + " " + LastName; } }
        
        #endregion

    }
}
