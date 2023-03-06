namespace RetailManagment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        [Key]
        public int Cart_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Product_name { get; set; }

        public int Quantity { get; set; }

        public int? Cus_id { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
