using System;
using System.Collections.Generic;

namespace ACSWeb.Models
{
    public class SAK
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MTBase { get; set; }
        public string Manufacturer { get; set; }
        public DateTime CommisioningDate { get; set; }

        public GPA GPA { get; set; }
    }
}
