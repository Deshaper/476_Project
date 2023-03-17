using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RetailManagment.Data;
using RetailManagment.Models;
using RetailManagment.ViewModels;

namespace RetailManagment.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        // 2023/3/ 14 New Function
        private readonly string _connectionString = "data source=LAPTOP-SNS0CLD2;initial catalog=Retail_management;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        private Model1 db = new Model1();
        public ActionResult Products_Inven_level()
        {
            return View(db.Commodities.ToList());
        }

        public ActionResult Add_Inventory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_Inventory(Commodity item)
        {
            if (ModelState.IsValid)
            {
                db.Commodities.Add(item);
                db.SaveChanges();

                if (item.Stocks < item.Leadtime)
                {
                    TempData["Alert"] = $"Warning: {item.Commo_name} inventory level is below the threshold!";
                }
                return RedirectToAction("Products_Inven_level");
            }

            return View(item);
        }

        public ActionResult Update_Pro(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commodity commoditys = db.Commodities.Find(id);
            if (commoditys == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Products_Inven_level");
        }
    }
}
