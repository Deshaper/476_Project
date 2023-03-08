using RetailManagment.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RetailManagment.Models;

namespace RetailManagment.Controllers
{
    public class CommodityController : Controller
    {
       private Model1 db = new Model1();

        // SearchResult
        public ActionResult SearchList(string commodity_name)
        {
            var products = db.Commodities.ToList();
            if(!String.IsNullOrEmpty(commodity_name))
            {
                products = products.Where(c=> c.Commo_name.Contains(commodity_name)).ToList();
            }

            return View(products);
        }
    }
}