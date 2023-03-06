namespace RetailManagment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Purchased")]
    public partial class Purchased
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Purchased()
        {
            Shipments = new HashSet<Shipment>();
        }

        [Key]
        public int Pur_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Product_name { get; set; }

        public DateTime Pur_date { get; set; }

        public int? Cus_id { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
