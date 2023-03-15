using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
        public ActionResult Products_Inven_level(int Commo_id)
        {
            var item = db.Commodities.Find(Commo_id);
            var serviceLevel = 0.95; // 95% service level
            var zValue = 1.64; // Z-value for 95% service level
            decimal stdDeviation = item.DemandVarialbility * (Decimal)Math.Sqrt(item.Leadtime);
            var safetyStockLevel = (Decimal)zValue * stdDeviation;

            ViewBag.ItemName = item.Commo_name;
            ViewBag.SafetyStockLevel = safetyStockLevel;
            return View();
        }
    }
}