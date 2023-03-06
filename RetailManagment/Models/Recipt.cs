namespace RetailManagment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Recipt")]
    public partial class Recipt
    {
        [Key]
        public int Rec_id { get; set; }

        public int? Cho_id { get; set; }

        public virtual Check_out Check_out { get; set; }
    }
}
