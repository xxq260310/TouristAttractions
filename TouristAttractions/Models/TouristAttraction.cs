using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Web;

namespace TouristAttractions.Models
{
    public class TouristAttraction
    {
        public int TouristAttractionId { get; set; }
        public string Name { get; set; }
        public DbGeography Location { get; set; }

        public List<Review> Reviews { get; set; }
    }
}