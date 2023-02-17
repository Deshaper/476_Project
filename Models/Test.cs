using Microsoft.Build.ObjectModelRemoting;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC476.Models
{
    public class Test
    {
        // string? means this attribute can leave as null
        public int id { get; set; }
        public string name { get; set; }
        public string? description { get; set; }
        public int age { get; set; }
        public int status { get; set; }
        public string? statusMessage { get; set; }
        [Display(Name = "Birth day")]
        [DataType(DataType.Date)]
        public DateTime BirthDay{ get; set;}    

        /*[Column(TypeName = "decimal(18,2)")] //constraint of decimal, kind of limit
        public decimal price { get; set;}

        /*Column(TypeName = "varchar(200)")]
    public string Url { get; set; } */

    }
}
