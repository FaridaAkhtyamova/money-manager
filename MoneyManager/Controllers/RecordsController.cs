using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MoneyManager.Models;
using MoneyManager.DAL;
using System;
using System.Collections.Generic;

namespace MoneyManager.Controllers
{
    public class RecordsController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: Records
        public ActionResult Index()
        {
            return View(db.RecordRepository.Get());
        }

        // GET: Records/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.RecordRepository.GetByID(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // GET: Records/Create
        public ActionResult Create()
        {
            var newRecord = new CreateRecordViewModel();
            //GenerateCategories(newRecord);
            //newRecord.Categories = db.CategoryRepository.Get().ToList();
            return View(newRecord);
        }

        // GET: Records/CreateExpense
        public ActionResult CreateExpense()
        {
            var newRecord = new CreateRecordViewModel();
            newRecord.Categories = GenerateCategories();
            //newRecord.Categories = db.CategoryRepository.Get().ToList();
            return View(newRecord);
        }

        // GET: Records/CreateIncome
        public ActionResult CreateIncome()
        {
            var newRecord = new CreateIncomeViewModel();
            newRecord.Categories = GenerateCategories();
            //GenerateCategories(newRecord);
            //newRecord.Categories = db.CategoryRepository.Get().ToList();
            return View(newRecord);
        }

        // POST: Records/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordID, IsExpense,SpendingDate,Comment,Sum, SelectedCategoryID")]CreateRecordViewModel record)
        {
            //[Bind(Include = "RecordID, IsExpense,SpendingDate,Comment,Sum")] 
            try
            {
                if (ModelState.IsValid)
                {
                    var addRecord = new Record() { IsExpense = record.IsExpense, SpendingDate = record.SpendingDate, Comment = record.Comment, Sum = record.Sum };
                    addRecord.Category = db.CategoryRepository.GetByID(int.Parse(record.SelectedCategoryID));
                    db.RecordRepository.Insert(addRecord);
                    db.Save();
                    return RedirectToAction("Index");
                }
            }

            catch (DataException dex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(record);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateIncome([Bind(Include = "RecordID, IsExpense,SpendingDate,Comment,Sum, SelectedCategoryID")]CreateIncomeViewModel record)
        {
            //[Bind(Include = "RecordID, IsExpense,SpendingDate,Comment,Sum")] 
            try
            {
                if (ModelState.IsValid)
                {
                    var addRecord = new Record() { IsExpense = record.IsExpense, SpendingDate = record.SpendingDate, Comment = record.Comment, Sum = record.Sum };
                    addRecord.Category = db.CategoryRepository.GetByID(int.Parse(record.SelectedCategoryID));
                    db.RecordRepository.Insert(addRecord);
                    db.Save();
                    return RedirectToAction("Index");
                }
            }

            catch (DataException dex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(record);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateExpense([Bind(Include = "RecordID, IsExpense,SpendingDate,Comment,Sum, SelectedCategoryID")]CreateRecordViewModel record)
        {
            //[Bind(Include = "RecordID, IsExpense,SpendingDate,Comment,Sum")] 
            try
            {
                if (ModelState.IsValid)
                {
                    var addRecord = new Record() { IsExpense = record.IsExpense, SpendingDate = record.SpendingDate, Comment = record.Comment, Sum = record.Sum };
                    addRecord.Category = db.CategoryRepository.GetByID(int.Parse(record.SelectedCategoryID));
                    db.RecordRepository.Insert(addRecord);
                    db.Save();
                    return RedirectToAction("Index");
                }
            }

            catch (DataException dex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(record);
        }


        // GET: Records/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.RecordRepository.GetByID(id);
            CreateRecordViewModel modelRecord = new CreateRecordViewModel() { RecordID = record.RecordID, IsExpense = record.IsExpense, SpendingDate = record.SpendingDate, Comment = record.Comment, Sum = record.Sum };
            modelRecord.SelectedCategoryID = record.Category.CategoryName;
            modelRecord.Categories = GenerateCategories();

            if (record == null)
            {
                return HttpNotFound();
            }
            return View(modelRecord);
        }

        private List<Category> GenerateCategories()
        {
            return db.CategoryRepository.Get().ToList();
        }

        // POST: Records/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordID, IsExpense,SpendingDate,Comment,Sum, SelectedCategoryID")]CreateRecordViewModel record)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    var updateRecord = new Record() { RecordID = record.RecordID, IsExpense = record.IsExpense, SpendingDate = record.SpendingDate, Comment = record.Comment, Sum = record.Sum };
                    //var categoryID = db.CategoryRepository.GetByID(int.Parse(record.SelectedCategoryID)).CategoryID;
                    updateRecord.Category = db.CategoryRepository.GetByID(int.Parse(record.SelectedCategoryID));
                    db.RecordRepository.Update(updateRecord);
                    db.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(record);
        }

        // GET: Records/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.RecordRepository.GetByID(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Record record = db.RecordRepository.GetByID(id);
            db.RecordRepository.Delete(id);
            db.Save();
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
