namespace RetailManagment.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class Categories
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Category_name { get; set; }
    }
}