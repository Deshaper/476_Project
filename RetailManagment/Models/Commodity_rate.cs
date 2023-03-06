namespace RetailManagment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Commodity_rate
    {
        [Key]
        public int Com_rate_id { get; set; }

        public int Com_rate { get; set; }

        public int? Comm_id { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
