using System;
using System.Collections.Generic;

namespace ACSWeb.Models
{
    public class GPA
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string GTDType { get; set; }
        public string VCNType { get; set; }
        public int StationNumber { get; set; }
        public string CompShopNumber { get; set; }
        //----------------------------------------------------------------------
        public KS KS { get; set; }
        public SAK SAK { get; set; }
    }
}
