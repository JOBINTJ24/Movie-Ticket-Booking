using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// movie ticket model ///

namespace ticket_booking_system.Models
{
    public class booking
    {
        public int bookingid { get; set; }
        public int userid { get; set; }
        public int movieid { get; set; }


    }
}