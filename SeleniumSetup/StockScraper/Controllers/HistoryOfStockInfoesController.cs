using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StockScraper.Models;

namespace StockScraper.Controllers
{
    public class HistoryOfStockInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HistoryOfStockInfoes
        public ActionResult Index()
        {
            return View(db.HistoryOfStockInfoes.ToList());
        }

        // GET: HistoryOfStockInfoes/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryOfStockInfo historyOfStockInfo = db.HistoryOfStockInfoes.Find(id);
            if (historyOfStockInfo == null)
            {
                return HttpNotFound();
            }
            return View(historyOfStockInfo);
        }

        // GET: HistoryOfStockInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistoryOfStockInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StockId,Date,Symbol,PercentChange,AverageVolume,LastPrice,MarketTime,OpenPrice,HighPrice,LowPrice,YearWeekHigh,YearWeekLow")] HistoryOfStockInfo historyOfStockInfo)
        {
            if (ModelState.IsValid)
            {
                db.HistoryOfStockInfoes.Add(historyOfStockInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(historyOfStockInfo);
        }

        // GET: HistoryOfStockInfoes/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryOfStockInfo historyOfStockInfo = db.HistoryOfStockInfoes.Find(id);
            if (historyOfStockInfo == null)
            {
                return HttpNotFound();
            }
            return View(historyOfStockInfo);
        }

        // POST: HistoryOfStockInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StockId,Date,Symbol,PercentChange,AverageVolume,LastPrice,MarketTime,OpenPrice,HighPrice,LowPrice,YearWeekHigh,YearWeekLow")] HistoryOfStockInfo historyOfStockInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historyOfStockInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(historyOfStockInfo);
        }

        // GET: HistoryOfStockInfoes/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryOfStockInfo historyOfStockInfo = db.HistoryOfStockInfoes.Find(id);
            if (historyOfStockInfo == null)
            {
                return HttpNotFound();
            }
            return View(historyOfStockInfo);
        }

        // POST: HistoryOfStockInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            HistoryOfStockInfo historyOfStockInfo = db.HistoryOfStockInfoes.Find(id);
            db.HistoryOfStockInfoes.Remove(historyOfStockInfo);
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
