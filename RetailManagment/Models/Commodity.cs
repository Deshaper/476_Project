namespace RetailManagment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlTypes;

    [Table("Commodity")]
    public partial class Commodity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Commodity()
        {
            Comments = new HashSet<Comment>();
        }

        [Key]
        public int Commo_id { get; set; }

        public float Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Commo_name { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        public int Stocks { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public byte[] Commodities_img { get; set; }

        public int? Seller_id { get; set; }

        public virtual Seller Seller { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
