using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RetailManagment.Models;
using RetailManagment.Data;

namespace RetailManagment.Controllers
{
   
    public class LoginController : Controller
    { 
        private Model1 db = new Model1();
        // GET: Login
        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {


        }
    }
}