using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooklyProjectAcunmedya.Entities
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public string Name { get; set; }
        public string Commment { get; set; }
        public int Review { get; set; }
    }
}