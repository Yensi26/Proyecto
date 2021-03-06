﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Domain;

namespace API.Controllers
{
    public class ExcercisesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Excercises
        public IQueryable<Excercise> GetExcercises()
        {
            return db.Excercises;
        }

        // GET: api/Excercises/5
        [ResponseType(typeof(Excercise))]
        public async Task<IHttpActionResult> GetExcercise(int id)
        {
            Excercise excercise = await db.Excercises.FindAsync(id);
            if (excercise == null)
            {
                return NotFound();
            }

            return Ok(excercise);
        }

        // PUT: api/Excercises/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExcercise(int id, Excercise excercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != excercise.ExcerciseId)
            {
                return BadRequest();
            }

            db.Entry(excercise).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExcerciseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Excercises
        [ResponseType(typeof(Excercise))]
        public async Task<IHttpActionResult> PostExcercise(Excercise excercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Excercises.Add(excercise);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = excercise.ExcerciseId }, excercise);
        }

        // DELETE: api/Excercises/5
        [ResponseType(typeof(Excercise))]
        public async Task<IHttpActionResult> DeleteExcercise(int id)
        {
            Excercise excercise = await db.Excercises.FindAsync(id);
            if (excercise == null)
            {
                return NotFound();
            }

            db.Excercises.Remove(excercise);
            await db.SaveChangesAsync();

            return Ok(excercise);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExcerciseExists(int id)
        {
            return db.Excercises.Count(e => e.ExcerciseId == id) > 0;
        }
    }
}