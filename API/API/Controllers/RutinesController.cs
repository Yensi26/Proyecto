using System;
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
    public class RutinesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Rutines
        public IQueryable<Rutine> GetRutines()
        {
            return db.Rutines;
        }

        // GET: api/Rutines/5
        [ResponseType(typeof(Rutine))]
        public async Task<IHttpActionResult> GetRutine(int id)
        {
            Rutine rutine = await db.Rutines.FindAsync(id);
            if (rutine == null)
            {
                return NotFound();
            }

            return Ok(rutine);
        }

        // PUT: api/Rutines/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRutine(int id, Rutine rutine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rutine.RutineId)
            {
                return BadRequest();
            }

            db.Entry(rutine).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutineExists(id))
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

        // POST: api/Rutines
        [ResponseType(typeof(Rutine))]
        public async Task<IHttpActionResult> PostRutine(Rutine rutine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rutines.Add(rutine);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rutine.RutineId }, rutine);
        }

        // DELETE: api/Rutines/5
        [ResponseType(typeof(Rutine))]
        public async Task<IHttpActionResult> DeleteRutine(int id)
        {
            Rutine rutine = await db.Rutines.FindAsync(id);
            if (rutine == null)
            {
                return NotFound();
            }

            db.Rutines.Remove(rutine);
            await db.SaveChangesAsync();

            return Ok(rutine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RutineExists(int id)
        {
            return db.Rutines.Count(e => e.RutineId == id) > 0;
        }
    }
}