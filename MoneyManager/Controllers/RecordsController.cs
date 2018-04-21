using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MoneyManager.Models;
using MoneyManager.DAL;
using System;

namespace MoneyManager.Controllers
{
    public class RecordsController : Controller
    {
        //private IRecordRepository _recordRepository;
        private UnitOfWork db = new UnitOfWork();

        //public RecordsController()
        //{
        //    _recordRepository = new RecordRepository(new MoneyManagerContext());
        //}

        //public RecordsController(IRecordRepository recordRepository)
        //{
        //    _recordRepository = recordRepository;
        //}

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
            newRecord.Categories = db.CategoryRepository.Get().ToList();
            return View(newRecord);
        }

        // POST: Records/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRecordViewModel record)
        {
            if (ModelState.IsValid)
            {
                var addRecord = new Record() { IsExpense = record.IsExpense, SpendingDate = record.SpendingDate, Comment = record.Comment, Sum = record.Sum };
                //addRecord.CategoryID = record.SelectedCategoryID;

                addRecord.Category = db.CategoryRepository.GetByID(Int32.Parse(record.SelectedCategoryID));
                //addRecord.CategoryID = _recordRepository.Categories.Where(c => c.CategoryName == record.SelectedCategory).First().CategoryID;
                db.RecordRepository.Insert(addRecord);
                //.Records.Add(addRecord);
                db.Save();
                //.SaveChanges();
                return RedirectToAction("Index");
            }
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        var addRecord = new Record() { IsExpense = record.IsExpense, SpendingDate = record.SpendingDate, Comment = record.Comment, Sum = record.Sum };
            //        //addRecord.CategoryID = record.SelectedCategoryID;
                    
            //        addRecord.Category = db.CategoryRepository.GetByID(Int32.Parse(record.SelectedCategoryID));
            //        //addRecord.CategoryID = _recordRepository.Categories.Where(c => c.CategoryName == record.SelectedCategory).First().CategoryID;
            //        db.RecordRepository.Insert(addRecord);
            //        //.Records.Add(addRecord);
            //        db.Save();
            //        //.SaveChanges();
            //        return RedirectToAction("Index");
            //    }
            //}
            //catch (DataException dex)
            //{
            //    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            //}
            //PopulateCategoriesDropDown(record.SelectedCategoryID);

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
            if (record == null)
            {
                return HttpNotFound();
            }
            //PopulateCategoriesDropDown(record.CategoryID);
            return View(record);
        }

        // POST: Records/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordID,IsExpense,Sum,SpendingDate,Comment,CategoryID")] Record record)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.RecordRepository.Update(record);
                    //.Entry(record).State = EntityState.Modified;
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

        private void PopulateCategoriesDropDown(object selectedCategory = null)
        {
            //var categoriesQuery = from c in _recordRepository
            //ViewBag.CategoryID = new SelectList(categoriesQuery, "CategoryID", "Name", selectedCategory);
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
