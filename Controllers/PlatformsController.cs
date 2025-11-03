using System;


using System.Linq;
using System.Web.Mvc;
using GameCatalog.Models;

namespace web_server_app_dev_final.Controllers
{
    public class PlatformsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlatformsController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            var platforms = _context.Platforms.ToList();
            return View(platforms);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Platform platform)
        {
            if (!ModelState.IsValid)
                return View(platform);

            _context.Platforms.Add(platform);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            var platform = _context.Platforms.Find(id);
            if (platform == null)
                return HttpNotFound();

            return View(platform);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Platform platform)
        {
            if (!ModelState.IsValid)
                return View(platform);

            _context.Entry(platform).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var platform = _context.Platforms.Find(id);
            if (platform == null)
                return HttpNotFound();

            return View(platform);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var platform = _context.Platforms.Find(id);
            _context.Platforms.Remove(platform);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }
    }
}
