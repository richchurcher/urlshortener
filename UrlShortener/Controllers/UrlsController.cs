using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    public class UrlsController : Controller
    {
        private UrlShortenerDbContext db = new UrlShortenerDbContext();

        // GET: Urls
        public ActionResult Index()
        {
            NewUrlAndAllViewModel viewModel = new NewUrlAndAllViewModel
            {
                NewUrl = new Url(),
                All = db.Urls.ToList()
            };
            return View(viewModel);
        }

        // GET: Urls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Url url = db.Urls.Find(id);
            if (url == null)
            {
                return HttpNotFound();
            }
            return View(url);
        }

        // GET: Urls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Urls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewUrlAndAllViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.NewUrl.Shortform = UrlMunger.Shortform(viewModel.NewUrl.Address);
                db.Urls.Add(viewModel.NewUrl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Urls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Url url = db.Urls.Find(id);
            if (url == null)
            {
                return HttpNotFound();
            }
            return View(url);
        }

        // POST: Urls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address")] Url url)
        {
            if (ModelState.IsValid)
            {
                db.Entry(url).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(url);
        }

        // GET: Urls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Url url = db.Urls.Find(id);
            if (url == null)
            {
                return HttpNotFound();
            }
            return View(url);
        }

        // POST: Urls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Url url = db.Urls.Find(id);
            db.Urls.Remove(url);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Go(string shortformUrl)
        {
            if (shortformUrl != null)
            {
                Url url = db.Urls.SingleOrDefault(u => u.Shortform == shortformUrl);
                if (url != null)
                {
                    url.Counter++;
                    db.SaveChanges();
                    return Redirect(url.Address);
                }
            }

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
