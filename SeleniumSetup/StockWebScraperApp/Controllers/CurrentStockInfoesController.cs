using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StockWebScraperApp.Models;

namespace StockWebScraperApp.Controllers
{
    public class CurrentStockInfoesController : Controller
    {
        private StockInfoEntities db = new StockInfoEntities();

        // GET: CurrentStockInfoes
        public ActionResult Index()
        {
            return View(db.CurrentStockInfoes.ToList());
        }

        // GET: CurrentStockInfoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentStockInfo currentStockInfo = db.CurrentStockInfoes.Find(id);
            if (currentStockInfo == null)
            {
                return HttpNotFound();
            }
            return View(currentStockInfo);
        }

        // GET: CurrentStockInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrentStockInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stock_Id,Symbol,PercentChange,AverageVolume,LastPrice,MarketTime,OpenPrice,HighPrice,LowPrice,YearWeekHigh,YearWeekLow,Date")] CurrentStockInfo currentStockInfo)
        {
            if (ModelState.IsValid)
            {
                db.CurrentStockInfoes.Add(currentStockInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(currentStockInfo);
        }

        // GET: CurrentStockInfoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentStockInfo currentStockInfo = db.CurrentStockInfoes.Find(id);
            if (currentStockInfo == null)
            {
                return HttpNotFound();
            }
            return View(currentStockInfo);
        }

        // POST: CurrentStockInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stock_Id,Symbol,PercentChange,AverageVolume,LastPrice,MarketTime,OpenPrice,HighPrice,LowPrice,YearWeekHigh,YearWeekLow,Date")] CurrentStockInfo currentStockInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currentStockInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(currentStockInfo);
        }

        // GET: CurrentStockInfoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentStockInfo currentStockInfo = db.CurrentStockInfoes.Find(id);
            if (currentStockInfo == null)
            {
                return HttpNotFound();
            }
            return View(currentStockInfo);
        }

        // POST: CurrentStockInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CurrentStockInfo currentStockInfo = db.CurrentStockInfoes.Find(id);
            db.CurrentStockInfoes.Remove(currentStockInfo);
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
