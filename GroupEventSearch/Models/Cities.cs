using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupEventSearch.Models
{
    public class Cities
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
