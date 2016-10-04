using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTfulAPI.Models
{
    public class BusAssignmentDTO
    {
        public int iConductorID { get; set; }
        public String tConductionName { get; set; }
        public int iDriveID { get; set; }
        public String tDriverName { get; set; }
        public int iInspectorID { get; set; }
        public String tInspectorName { get; set; }
        public int iBusID { get; set; }
        public String tBusPlateNo { get; set; }
        public int iRouteID { get; set; }
        public String tRouteName { get; set; }
    }
}