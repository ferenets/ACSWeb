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

        public int KSID { get; set; }//foreign key
        //public int SAKID { get; set; } //foreign key

        

        //----------------------------------------------------------------------
        public KS KS { get; set; } //navigation property
        public SAK SAK { get; set; } //navigation property  The child/dependent side could not be determined for the one-to-one relationship that was detected between 'GPA.SAK' and 'SAK.GPA'. To identify the child/dependent side of the relationship, configure the foreign key property. If these navigations should not be part of the same relationship configure them without specifying the inverse. See http://go.microsoft.com/fwlink/?LinkId=724062 for more details.
    }
}
