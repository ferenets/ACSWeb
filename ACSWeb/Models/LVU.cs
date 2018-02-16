using System;
using System.Collections.Generic;

namespace ACSWeb.Models
{
    public class LVU
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int UMGID { get; set; }  //foreign key


        //---------------------------------------------------------
        public UMG UMG { get; set; }  //navigation property
        public ICollection<KS> KSList { get; set; } //navigation property
    }
}
