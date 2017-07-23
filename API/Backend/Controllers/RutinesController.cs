using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Backend.Models;
using Domain;

namespace Backend.Controllers
{
    public class RutinesController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Rutines
        public async Task<ActionResult> Index()
        {
            return View(await db.Rutines.ToListAsync());
        }

        // GET: Rutines/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rutine rutine = await db.Rutines.FindAsync(id);
            if (rutine == null)
            {
                return HttpNotFound();
            }
            return View(rutine);
        }

        // GET: Rutines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rutines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RutineId,Name,Picture")] Rutine rutine)
        {
            if (ModelState.IsValid)
            {
                db.Rutines.Add(rutine);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rutine);
        }

        // GET: Rutines/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rutine rutine = await db.Rutines.FindAsync(id);
            if (rutine == null)
            {
                return HttpNotFound();
            }
            return View(rutine);
        }

        // POST: Rutines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RutineId,Name,Picture")] Rutine rutine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rutine).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rutine);
        }

        // GET: Rutines/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rutine rutine = await db.Rutines.FindAsync(id);
            if (rutine == null)
            {
                return HttpNotFound();
            }
            return View(rutine);
        }

        // POST: Rutines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Rutine rutine = await db.Rutines.FindAsync(id);
            db.Rutines.Remove(rutine);
            await db.SaveChangesAsync();
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
