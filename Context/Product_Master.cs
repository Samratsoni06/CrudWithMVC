//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestApplication.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Product_Master
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Required")]
        public Nullable<int> CategoryID { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Required")]
        public Nullable<decimal> CostPrice { get; set; }
        [Required(ErrorMessage = "Required")]        
        public Nullable<decimal> SalePrice { get; set; }
        public string Inventory { get; set; }

    }
}
