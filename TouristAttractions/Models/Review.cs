using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TouristAttractions.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Author { get; set; }
        public string Comments { get; set; }

        public int TouristAttractionId { get; set; }
        public TouristAttraction TouristAttraction { get; set; }
    }
}