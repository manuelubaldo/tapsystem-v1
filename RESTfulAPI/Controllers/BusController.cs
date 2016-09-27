using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RESTfulAPI.Models;

namespace RESTfulAPI.Controllers
{
    public class BusController : ApiController
    {
        private TapSystemEntities db = new TapSystemEntities();

        // GET: api/Bus
        public IQueryable<tblBus> GettblBus1()
        {
            return db.tblBus1;
        }

        // GET: api/Bus/5
        [ResponseType(typeof(tblBus))]
        public IHttpActionResult GettblBus(int id)
        {
            tblBus tblBus = db.tblBus1.Find(id);
            if (tblBus == null)
            {
                return NotFound();
            }

            return Ok(tblBus);
        }

        // PUT: api/Bus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblBus(int id, tblBus tblBus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblBus.iBusID)
            {
                return BadRequest();
            }

            db.Entry(tblBus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblBusExists(id))
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

        // POST: api/Bus
        [ResponseType(typeof(tblBus))]
        public IHttpActionResult PosttblBus(tblBus tblBus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblBus1.Add(tblBus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblBus.iBusID }, tblBus);
        }

        // DELETE: api/Bus/5
        [ResponseType(typeof(tblBus))]
        public IHttpActionResult DeletetblBus(int id)
        {
            tblBus tblBus = db.tblBus1.Find(id);
            if (tblBus == null)
            {
                return NotFound();
            }

            db.tblBus1.Remove(tblBus);
            db.SaveChanges();

            return Ok(tblBus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblBusExists(int id)
        {
            return db.tblBus1.Count(e => e.iBusID == id) > 0;
        }
    }
}