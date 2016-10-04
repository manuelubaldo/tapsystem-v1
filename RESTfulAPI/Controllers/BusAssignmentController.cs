using RESTfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTfulAPI.Controllers
{
    public class BusAssignmentController : ApiController
    {
        private TapSystemEntities db = new TapSystemEntities();

        public IHttpActionResult Get(int id)
        {
            var busAssignment = from b in db.tblBusAssignments
                                where b.iConductorID == id && b.bActive == 1
                                select new BusAssignmentDTO
                                {
                                    iBusID = b.iBusID,
                                    tBusPlateNo = b.tblBus.tPlateNo,
                                    iConductorID = b.iConductorID,
                                    tConductionName = b.conductor.tFullName,
                                    iDriveID = b.iDriverID,
                                    tDriverName = b.driver.tFullName,
                                    iInspectorID = b.iInspector,
                                    tInspectorName = b.inspector.tFullName,
                                    iRouteID = b.iRouteID,
                                    tRouteName = b.tblRoute.tFrom + " to " + b.tblRoute.tTo
                                };

            if(busAssignment.Count()>0)
            {
                return Ok(busAssignment.First());
            }
            else
            {
                return Ok(new BusAssignmentDTO());
            }

            
        }

    }
}
