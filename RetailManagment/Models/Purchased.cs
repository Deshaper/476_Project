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
        [Required]
        [StringLength(50)]
        public string Brand { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }

        public DateTime Pur_date { get; set; }

        public DateTime Delivery_date{get; set;} 

        public int? Cus_id { get; set; }

        public int? Commo_id { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Commodity Commodity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
