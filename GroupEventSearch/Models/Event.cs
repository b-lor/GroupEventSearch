﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupEventSearch.Models
{
    public class Events
    {
        public string Title { get; set; }
        public Dictionary<string, JToken> Performers { get; set; }
        public Dictionary<string, JToken> Image { get; set; }
        public DateTime StartDatetime { get; set; }
        public string Location { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}
