using System;
using System.Collections.Generic;

namespace ACSWeb.Models
{
    public class KS
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int LVUID { get; set; }  //foreign key
        public int PipelineID { get; set; } //foreign key

        //---------------------------------------------------------
        public LVU LVU { get; set; } //navigation property
        public Pipeline Pipeline { get; set; } //navigation property
        public ICollection<GPA> GPAList { get; set; } //navigation property
    }
}
