using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS476.Models
{
    public class RetailUser
    {
        public int Userid { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }


        //public Nullable<System.DateTime> eff_end_dte { get; set; } to end users record
    }
}