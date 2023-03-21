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
    public class CartController : Controller
    {
        private readonly string _connectionString = "data source=DESKTOP-NS6UO45;initial catalog=Retail_management;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        private Model1 db = new Model1();


        // GET: Cart/CarList
        public ActionResult CartList()
        {


            if (Session["IsLoggedIn"] == null || (bool)Session["IsLoggedIn"] == false)
            {
                return RedirectToAction("Login", "Login");
            }

            List<Particular_cart> model2 = new List<Particular_cart>();

            var nameuse = Session["name"];
            var Cusid = db.Customers.FirstOrDefault(c => c.Name == nameuse);


            string q2 = "SELECT Product_name, Quantity, Cus_id FROM Cart WHERE Cus_id = @Cusid";

            using(SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
 
                SqlCommand cmd = new SqlCommand(q2, sqlConnection);
                cmd.Parameters.AddWithValue("@Cusid", Cusid.Cus_id);

                sqlConnection.Open();

                using (SqlDataReader read = cmd.ExecuteReader())
                { 
                    while (read.Read())
                    {
                        Particular_cart cart1 = new Particular_cart();

                        cart1.Product_name = Convert.IsDBNull(read["Product_name"]) ? null : (string)read["Product_name"];
                        cart1.Quantity = Convert.IsDBNull(read["Quantity"]) ? 0 : (int)read["Quantity"];
                        cart1.Cus_id = Convert.IsDBNull(read["Cus_id"]) ? 0 : (int)read["Cus_id"];

                        model2.Add(cart1);
                        

                    }
                }
                    

            }
            return View(model2);
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
