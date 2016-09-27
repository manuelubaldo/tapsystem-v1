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
    public class EnrolledAccountsController : ApiController
    {
        private TapSystemEntities db = new TapSystemEntities();

        // GET: api/EnrolledAccounts
        public IQueryable<tblEnrolledAccount> GettblEnrolledAccounts()
        {
            return db.tblEnrolledAccounts;
        }

        // GET: api/EnrolledAccounts/5
        [ResponseType(typeof(tblEnrolledAccount))]
        public IHttpActionResult GettblEnrolledAccount(int id)
        {
            tblEnrolledAccount tblEnrolledAccount = db.tblEnrolledAccounts.Find(id);
            if (tblEnrolledAccount == null)
            {
                return NotFound();
            }

            return Ok(tblEnrolledAccount);
        }

        // PUT: api/EnrolledAccounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblEnrolledAccount(int id, tblEnrolledAccount tblEnrolledAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblEnrolledAccount.iAccountID)
            {
                return BadRequest();
            }

            db.Entry(tblEnrolledAccount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblEnrolledAccountExists(id))
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

        // POST: api/EnrolledAccounts
        [ResponseType(typeof(tblEnrolledAccount))]
        public IHttpActionResult PosttblEnrolledAccount(tblEnrolledAccount tblEnrolledAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblEnrolledAccounts.Add(tblEnrolledAccount);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblEnrolledAccount.iAccountID }, tblEnrolledAccount);
        }

        // DELETE: api/EnrolledAccounts/5
        [ResponseType(typeof(tblEnrolledAccount))]
        public IHttpActionResult DeletetblEnrolledAccount(int id)
        {
            tblEnrolledAccount tblEnrolledAccount = db.tblEnrolledAccounts.Find(id);
            if (tblEnrolledAccount == null)
            {
                return NotFound();
            }

            db.tblEnrolledAccounts.Remove(tblEnrolledAccount);
            db.SaveChanges();

            return Ok(tblEnrolledAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblEnrolledAccountExists(int id)
        {
            return db.tblEnrolledAccounts.Count(e => e.iAccountID == id) > 0;
        }
    }
}