namespace RetailManagement.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int employee_id { get; set; }

        [Required]
        [StringLength(50)]
        public string first_name { get; set; }

        [Required]
        [StringLength(50)]
        public string last_name { get; set; }

        [Required]
        [StringLength(50)]
        public string role { get; set; }

   
        public DateTime start_date { get; set; }


        public DateTime end_date { get; set; }

        public Employee()
        {
            start_date = DateTime.Today;
            end_date = new DateTime(2099, 12, 31);
        }
    }
}
