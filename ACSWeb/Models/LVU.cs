using System;
using System.Collections.Generic;

namespace ACSWeb.Models
{
    public class LVU
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int UMGID { get; set; }  //foreign key
        public string Notes { get; set; }  //Primechaniya
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }


        //---------------------------------------------------------
        public UMG UMG { get; set; }  //navigation property
        public ICollection<KS> KSList { get; set; } //navigation property
    }
}
