using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACSWeb.Models
{
    public class Pipeline
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Notes { get; set; }  //Primechaniya


        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
        public ICollection<KSPipeline> KSList { get; set; } //navigation property
        //public ICollection<KS> KSList { get; set; } //navigation property
    }
}
