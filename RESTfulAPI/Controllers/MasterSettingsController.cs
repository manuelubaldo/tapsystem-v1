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
    public class MasterSettingsController : ApiController
    {
        private TapSystemEntities db = new TapSystemEntities();

        // GET: api/MasterSettings
        public IQueryable<tblMasterSetting> GettblMasterSettings()
        {
            return db.tblMasterSettings;
        }

        // GET: api/MasterSettings/5
        [ResponseType(typeof(tblMasterSetting))]
        public IHttpActionResult GettblMasterSetting(int id)
        {
            tblMasterSetting tblMasterSetting = db.tblMasterSettings.Find(id);
            if (tblMasterSetting == null)
            {
                return NotFound();
            }

            return Ok(tblMasterSetting);
        }

        // PUT: api/MasterSettings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblMasterSetting(int id, tblMasterSetting tblMasterSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblMasterSetting.ID)
            {
                return BadRequest();
            }

            db.Entry(tblMasterSetting).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblMasterSettingExists(id))
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

        // POST: api/MasterSettings
        [ResponseType(typeof(tblMasterSetting))]
        public IHttpActionResult PosttblMasterSetting(tblMasterSetting tblMasterSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblMasterSettings.Add(tblMasterSetting);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblMasterSetting.ID }, tblMasterSetting);
        }

        // DELETE: api/MasterSettings/5
        [ResponseType(typeof(tblMasterSetting))]
        public IHttpActionResult DeletetblMasterSetting(int id)
        {
            tblMasterSetting tblMasterSetting = db.tblMasterSettings.Find(id);
            if (tblMasterSetting == null)
            {
                return NotFound();
            }

            db.tblMasterSettings.Remove(tblMasterSetting);
            db.SaveChanges();

            return Ok(tblMasterSetting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblMasterSettingExists(int id)
        {
            return db.tblMasterSettings.Count(e => e.ID == id) > 0;
        }
    }
}