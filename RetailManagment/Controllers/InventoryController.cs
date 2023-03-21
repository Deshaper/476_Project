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
        private readonly string _connectionString = "data source=DESKTOP-NS6UO45;initial catalog=Retail_management;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        private Model1 db = new Model1();
        public ActionResult Products_Inven_level()
        {

            if (Session["IsLoggedIn"] == null || (bool)Session["IsLoggedIn"] == false)
            {
                return RedirectToAction("Login", "Login");
            }
            List<Inven_alert> model2 = new List<Inven_alert>();
            var alerts = new List<string>();
            var allItems = db.Commodities.ToList();


            string q2 = "SELECT * FROM Commodity WHERE Leadtime IS NOT NULL";

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand(q2, sqlConnection);

                sqlConnection.Open();

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                       // Inven_alert Inven1 = new Inven_alert();
                        if ((int)read["Stocks"] < (int)read["Leadtime"])
                        {
                           // Inven1.Inven_item.Add((string)read["Product_name"]);
                            alerts.Add($"Item: {read["Commo_name"]} (Quantity: {read["Stocks"]}, is in low stocks, require to add more stocks");
                        }
                    }
                }
               
                ViewBag.Alerts = alerts;
                return View(allItems);
            }
        }

        public ActionResult Add_Inventory()
        {

            if (Session["IsLoggedIn"] == null || (bool)Session["IsLoggedIn"] == false)
            {
                return RedirectToAction("Login", "Login");
            }
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
