using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MoneyManager.DAL;
using System.Data;

namespace MoneyManager.Controllers
{
    public class CategoriesController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.CategoryRepository.Get().ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.CategoryRepository.GetByID(id);
                //.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        public ActionResult Details(string categoryName)
        {
            if (categoryName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.CategoryRepository.Get().Single(c => c.CategoryName == categoryName);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.CategoryRepository.Insert(category);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.CategoryRepository.GetByID(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.CategoryRepository.Update(category);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.CategoryRepository.GetByID(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.CategoryRepository.GetByID(id);
            db.CategoryRepository.Delete(category);
            try
            {
                db.Save();
                return RedirectToAction("Index");
            }
            catch (DataException dex)
            {
                ModelState.AddModelError("fail", "Unable to delete. Try again, and if the problem persists, see your system administrator.");
            }
            return View(category);            
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
