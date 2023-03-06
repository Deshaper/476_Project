namespace RetailManagment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        [Key]
        public int Stock_id { get; set; }

        public float Stock_num { get; set; }

        public int? Commo_id { get; set; }

        public virtual Commodity Commodity { get; set; }
    }
}
