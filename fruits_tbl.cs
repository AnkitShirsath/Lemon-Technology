//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Task_company.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class fruits_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public fruits_tbl()
        {
            this.comman_fruit_veg = new HashSet<comman_fruit_veg>();
            this.vegerables_tbl1 = new HashSet<vegerables_tbl>();
        }
    
        public int Fruit_id { get; set; }

        [Required(ErrorMessage = "Please enter fruit name")]

         public string Fruit_name { get; set; }

        [Required(ErrorMessage = "Please select vegitable name")]


        public Nullable<int> veg_Id { get; set; }
        [Required(ErrorMessage = "Please select Date ")]

        public DateTime Start_Date { get; set; }

        public bool IsActive { get; set; }  


        public virtual vegerables_tbl vegerables_tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comman_fruit_veg> comman_fruit_veg { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vegerables_tbl> vegerables_tbl1 { get; set; }
    }
}
