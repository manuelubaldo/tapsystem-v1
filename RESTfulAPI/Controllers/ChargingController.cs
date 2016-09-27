using RESTfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTfulAPI.Controllers
{
    public class ChargingController : ApiController
    {
        private TapSystemEntities db = new TapSystemEntities();

        public IHttpActionResult Get()
        {
            return Ok();
        }

        public IHttpActionResult Post(Fair fair)
        {
            Fair result = new Fair();
            result.CardNo = fair.CardNo;
            result.Destination = fair.Destination;
            bool save = false;

            var Accounts = from acc in db.tblEnrolledAccounts
                                         where acc.tCardNo == fair.CardNo
                                         select acc;
            if (Accounts.Count() < 1)
            {
                result.Remarks = "Card no. not active";
            }

            var account = Accounts.First();

            result.PhoneNo = account.tContactNumber;
            

            var Destination = from dest in db.tblSubroutes
                              where dest.tRouteName == fair.Destination
                              select dest;
            if (Destination.Count() < 1)
            {
                result.Remarks = "Destination not valid";
            }
            var destination = Destination.First();

            var Route = from r in db.tblRoutes
                        where r.tFrom + " to " + r.tTo == fair.Route
                        select r;

            var route = Route.First();

            if(destination.nFareAmount>(double)account.iLoadAmount)
            {
                result.Remarks = "Insufficient Funds";
            }
            else
            {
                account.iLoadAmount -=(decimal) destination.nFareAmount;
                result.Remarks = "Thank you";
                result.Balance = (double) account.iLoadAmount;
                save = true;
            }

            db.Entry(account).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                if (save)
                {
                    var trans = new tblTransaction();
                    trans.iAmount = (int)destination.nFareAmount;
                    trans.iRouteID = route.iRouteID;
                    trans.iSeatNo = Int32.Parse(fair.SeatNo);
                    trans.iSubrouteID = destination.iSubrouteID;
                    trans.tLogMessage = "Fare Charging";
                    trans.tPlateNo = fair.BusPlateNo;
                    trans.dTransDate = DateTime.Now;
                    db.tblTransactions.Add(trans);
                    db.SaveChanges();
                }
                
            }
            catch (Exception)
            {
                result.Remarks = "Error Occured";
            }

            return Ok(result);
        }

    }
}
