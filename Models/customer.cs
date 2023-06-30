using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// registration model in ticket booking ///

namespace ticket_booking_system.Models
{
    public class customer
    {
        public int Id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string dateofbirth { get; set; }
        public string gender { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
}