using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using RetailManagment.Data;
using RetailManagment.Models;
using System.Web.SessionState;
using System.Web.Routing;


namespace RetailManagment.Controllers
{

    public class CustomersController : Controller
    {
   

        private readonly string _connectionString = "data source=LAPTOP-UN9M6QIN;initial catalog=Retail_management;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        private Model1 db = new Model1();

     

    // GET: Customers

    public ActionResult Index()
        {
            if (Session["IsLoggedIn"] == null || (bool)Session["IsLoggedIn"] == false)
            {
                return RedirectToAction("Login", "Login");
            }

            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult Order_History()
        {
            return View(db.Purchaseds.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup([Bind(Include = "Cus_id,Name,Email,Username,Password")] Customer customer)
        {
          

            string q1 = "INSERT INTO Cart(Cus_id) VALUES (@CUSID)";
            
            
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            var cus_name = customer.Name;

            var cusid = db.Customers.FirstOrDefault(c => c.Name == cus_name);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(q1, sqlConnection);
                cmd.Parameters.AddWithValue("@CUSID", cusid.Cus_id);

                try
                {
                    sqlConnection.Open(); 
                    int rowaff = cmd.ExecuteNonQuery();
                    if (rowaff > 0)
                    {
                        Console.WriteLine("success open);");
                    }
                    Console.Write(cmd.CommandText);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                }

                sqlConnection.Close();
            }

            return RedirectToAction("Index");
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cus_id,Name,Email,Username,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
