﻿using RetailManagment.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RetailManagment.Models;
using System.Data.SqlClient;

namespace RetailManagment.Controllers
{
   
    public class CommodityController : Controller
    {

        private readonly string _connectionString = "data source=LAPTOP-SNS0CLD2;initial catalog=Retail_management;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
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

        public ActionResult Commodity_detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commodity commodities_ent = db.Commodities.Find(id);
            if (commodities_ent == null)
            {
                return HttpNotFound();
            }
            return View(commodities_ent);
        }

        public ActionResult Commodity_detail_withname(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Console.WriteLine(name);

            Commodity commodity_ent = db.Commodities.FirstOrDefault(c=>c.Commo_name==name);
            if (commodity_ent == null)
            {
                return HttpNotFound();
            }
            return View("Commodity_detail", commodity_ent);
        }

        [HttpPost]
        public ActionResult AddtoCart(int Commo_id, string Commo_name, int Stocks)
        {
            var name = Session["name"];
            var cus = db.Customers.FirstOrDefault(c => c.Name == name);
            string q1 = "INSERT INTO Cart(Product_name, Quantity, Cus_id)VALUES(@Commoname, @Quantity, @Cusid)";
            
            using (SqlConnection sqlconnection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(q1, sqlconnection);
                cmd.Parameters.AddWithValue("@Commoname", Commo_name);
                cmd.Parameters.AddWithValue("@Quantity", Stocks);
                cmd.Parameters.AddWithValue("@Cusid", cus.Cus_id);
                sqlconnection.Open();
                cmd.ExecuteNonQuery();
                sqlconnection.Close();
            }

           // Commodity commodities_ent = db.Commodities.Find(Commo_id);


           // if (commodities_ent == null)
           // {
            //    return HttpNotFound();
           // }
            return RedirectToAction("SearchList");
        }
    }
}