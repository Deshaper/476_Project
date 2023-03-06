namespace RetailManagment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rate")]
    public partial class Rate
    {
        [Key]
        public int rate_id { get; set; }

        [Column("Rate")]
        public int Rate1 { get; set; }

        public int? Seller_id { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
