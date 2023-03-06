namespace RetailManagment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shipment")]
    public partial class Shipment
    {
        [Key]
        public int Ship_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Estimate_date { get; set; }

        public int Duration { get; set; }

        public int? Pur_id { get; set; }

        public virtual Purchased Purchased { get; set; }
    }
}
