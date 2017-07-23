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
    public class ExcercisesController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Excercises
        public async Task<ActionResult> Index()
        {
            var excercises = db.Excercises.Include(e => e.Rutine);
            return View(await excercises.ToListAsync());
        }

        // GET: Excercises/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excercise excercise = await db.Excercises.FindAsync(id);
            if (excercise == null)
            {
                return HttpNotFound();
            }
            return View(excercise);
        }

        // GET: Excercises/Create
        public ActionResult Create()
        {
            ViewBag.RutineId = new SelectList(db.Rutines, "RutineId", "Name");
            return View();
        }

        // POST: Excercises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ExcerciseId,Name,Picture,RutineId,Sets,Repetitions,Description,Duration,Rest")] Excercise excercise)
        {
            if (ModelState.IsValid)
            {
                db.Excercises.Add(excercise);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RutineId = new SelectList(db.Rutines, "RutineId", "Name", excercise.RutineId);
            return View(excercise);
        }

        // GET: Excercises/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excercise excercise = await db.Excercises.FindAsync(id);
            if (excercise == null)
            {
                return HttpNotFound();
            }
            ViewBag.RutineId = new SelectList(db.Rutines, "RutineId", "Name", excercise.RutineId);
            return View(excercise);
        }

        // POST: Excercises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ExcerciseId,Name,Picture,RutineId,Sets,Repetitions,Description,Duration,Rest")] Excercise excercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(excercise).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RutineId = new SelectList(db.Rutines, "RutineId", "Name", excercise.RutineId);
            return View(excercise);
        }

        // GET: Excercises/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excercise excercise = await db.Excercises.FindAsync(id);
            if (excercise == null)
            {
                return HttpNotFound();
            }
            return View(excercise);
        }

        // POST: Excercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Excercise excercise = await db.Excercises.FindAsync(id);
            db.Excercises.Remove(excercise);
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
