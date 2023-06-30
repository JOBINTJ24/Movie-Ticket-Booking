using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// movie adding model ///

namespace ticket_booking_system.Models
{
    public class movies
    {       
        public int Id { get; set; }
        public string movie_name { get; set; }
        public string description { get; set; }
        public string movie_image { get; set; }
        public string streaming_date { get; set; }
        public string genre { get; set; }
        public string duration { get; set; }
        public string language { get; set; }

    }
}
