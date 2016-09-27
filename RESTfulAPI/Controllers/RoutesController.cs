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
    public class RoutesController : ApiController
    {
        private TapSystemEntities db = new TapSystemEntities();

        // GET: api/Routes
        public IQueryable<tblRoute> GettblRoutes()
        {
            return db.tblRoutes;
        }

        // GET: api/Routes/5
        [ResponseType(typeof(tblRoute))]
        public IHttpActionResult GettblRoute(int id)
        {
            tblRoute tblRoute = db.tblRoutes.Find(id);
            if (tblRoute == null)
            {
                return NotFound();
            }

            return Ok(tblRoute);
        }

        // PUT: api/Routes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblRoute(int id, tblRoute tblRoute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblRoute.iRouteID)
            {
                return BadRequest();
            }

            db.Entry(tblRoute).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblRouteExists(id))
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

        // POST: api/Routes
        [ResponseType(typeof(tblRoute))]
        public IHttpActionResult PosttblRoute(tblRoute tblRoute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblRoutes.Add(tblRoute);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblRoute.iRouteID }, tblRoute);
        }

        // DELETE: api/Routes/5
        [ResponseType(typeof(tblRoute))]
        public IHttpActionResult DeletetblRoute(int id)
        {
            tblRoute tblRoute = db.tblRoutes.Find(id);
            if (tblRoute == null)
            {
                return NotFound();
            }

            db.tblRoutes.Remove(tblRoute);
            db.SaveChanges();

            return Ok(tblRoute);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblRouteExists(int id)
        {
            return db.tblRoutes.Count(e => e.iRouteID == id) > 0;
        }
    }
}