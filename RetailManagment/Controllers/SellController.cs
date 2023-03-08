using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RetailManagment.Data;
using RetailManagment.Models;

namespace RetailManagment.Controllers
{
    public class SellController : Controller
    {
        private Model1 db = new Model1();
        // GET: Sell
        public ActionResult Index()
        {
            return View(db.Sellers.ToList());
        }

        // GET:Sell/ Post_Your_Product
        public ActionResult Post_Your_Product()
        {
            return View();
        }

        // POST: Sell/Post_Your_Product
        [HttpPost]
        public ActionResult Post_Your_Product([Bind(Include = "Commo_id,Price,Commo_name,Category,Stocks, Commodities_img")] Commodity commodity)
        {
            if (ModelState.IsValid)
            {
                             
                db.Commodities.Add(commodity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(commodity);
        }


            // GET: Sell/Edit/5
            public ActionResult Edit(int id)
            {
                return View();
            }

            // POST: Sell/Edit/5
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

            // GET: Sell/Delete/5
            public ActionResult Delete(int id)
            {
                return View();
            }

            // POST: Sell/Delete/5
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

