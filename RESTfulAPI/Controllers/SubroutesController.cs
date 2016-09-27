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
    public class SubroutesController : ApiController
    {
        private TapSystemEntities db = new TapSystemEntities();

        // GET: api/Subroutes
        public IQueryable<tblSubroute> GettblSubroutes()
        {
            return db.tblSubroutes;
        }

        // GET: api/Subroutes/5
        [ResponseType(typeof(tblSubroute))]
        public IHttpActionResult GettblSubroute(int id)
        {
            tblSubroute tblSubroute = db.tblSubroutes.Find(id);
            if (tblSubroute == null)
            {
                return NotFound();
            }

            return Ok(tblSubroute);
        }

        // PUT: api/Subroutes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblSubroute(int id, tblSubroute tblSubroute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblSubroute.iSubrouteID)
            {
                return BadRequest();
            }

            db.Entry(tblSubroute).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblSubrouteExists(id))
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

        // POST: api/Subroutes
        [ResponseType(typeof(tblSubroute))]
        public IHttpActionResult PosttblSubroute(tblSubroute tblSubroute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblSubroutes.Add(tblSubroute);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblSubroute.iSubrouteID }, tblSubroute);
        }

        // DELETE: api/Subroutes/5
        [ResponseType(typeof(tblSubroute))]
        public IHttpActionResult DeletetblSubroute(int id)
        {
            tblSubroute tblSubroute = db.tblSubroutes.Find(id);
            if (tblSubroute == null)
            {
                return NotFound();
            }

            db.tblSubroutes.Remove(tblSubroute);
            db.SaveChanges();

            return Ok(tblSubroute);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblSubrouteExists(int id)
        {
            return db.tblSubroutes.Count(e => e.iSubrouteID == id) > 0;
        }
    }
}