using CS476.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS476.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            Retail_ManagementEntities db = new Retail_ManagementEntities();
            
            
            return View();
        }
    }
}