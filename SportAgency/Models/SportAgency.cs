using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportAgency.Models
{
    public class SportAgency
    {
        public string athlete_firstname { get; set; }
        public string athlete_lastname { get; set; }
        public string dob { get; set; }
        public string sport { get; set; }
        public string AgentName { get; set; }
    }
}