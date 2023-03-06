namespace RetailManagment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment()
        {
            Commodity_rate = new HashSet<Commodity_rate>();
        }

        [Key]
        public int Comm_id { get; set; }

        [Required]
        [StringLength(255)]
        public string Comments { get; set; }

        public DateTime Comm_date { get; set; }

        public int? Cus_id { get; set; }

        public int? Commo_id { get; set; }

        public virtual Commodity Commodity { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commodity_rate> Commodity_rate { get; set; }
    }
}
