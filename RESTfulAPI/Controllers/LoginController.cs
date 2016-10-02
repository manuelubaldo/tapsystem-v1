using RESTfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTfulAPI.Controllers
{
    public class LoginController : ApiController
    {
        private TapSystemEntities db = new TapSystemEntities();
        public IHttpActionResult Post(tblUser User)
        {

            var result = from u in db.tblUsers
                         where u.tUserName == User.tUserName && u.tPassword == User.tPassword
                         select u;

            if (result.Count()<1)
            {
                return Ok(new tblUser());
            }
            else
            {
                return Ok(result.First());
            }
        }
    }
}
