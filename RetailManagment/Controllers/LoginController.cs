using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using RetailManagment.Models;
using RetailManagment.Data;
using System.ComponentModel.DataAnnotations;
using System.Web.SessionState;

namespace RetailManagment.Controllers
{
   
    public class LoginController : Controller
    {
        private readonly string _connectionString = "data source=LAPTOP-UN9M6QIN;initial catalog=Retail_management;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        private Model1 db = new Model1();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        // GET: Login
        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            //string namequery = "SELECT * FROM Customer WHERE  Customer.Username = Username AND Customer.Password = Password";

           // SqlCommand sql1= new SqlCommand(namequery, db);

            if(!ModelState.IsValid)
            {
                return View(customer);
            }

            string query = "SELECT Name FROM Customer WHERE Email = @Email AND Password = @Password";
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                // assign data post by login to variable that use for query
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Password", customer.Password);

                // connect to database and execute the query
                sqlConnection.Open();
               
                //Start reader to read the cmd result
                SqlDataReader reader = cmd.ExecuteReader(); 
                // Validate if there is Matching data from database
                if(reader.HasRows)
                {
                    reader.Read();
                    string name = reader.GetString(0);

                    // Automatically start session
                    Session["Name"] = name;
                    Session["IsLoggedIn"] = true;

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error Email and Error Password");
                    return View(customer);
                }
            }

           

        }
      
    }
}