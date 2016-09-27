using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTfulAPI.Models
{
    public class Fair
    {
        public String Route { get; set; }
        public String Destination { get; set; }
        public String CardNo { get; set; }
        public String Remarks { get; set; }
        public Double Balance { get; set; }
        public String PhoneNo { get; set; }
        public String SeatNo { get; set; }
        public String BusPlateNo { get; set; }
    }
}