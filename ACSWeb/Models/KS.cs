using System;
using System.Collections.Generic;

namespace ACSWeb.Models
{
    public class KS
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int LVUID { get; set; }  //foreign key
        //public IList<int> PipelineIDList { get; set; } //foreign key (test for multiple values in 1 KS)
        //public ICollection<int> GPAIDList { get; set; } //foreign key (test for multiple values in 1 KS)
        public string Notes { get; set; }  //Primechaniya
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }

        //---------------------------------------------------------
        public LVU LVU { get; set; } //navigation property
        public ICollection<KSPipeline> PipelineList { get; set; } //navigation property с ПРОМЕЖУТОЧНЫМ ТИПОМ ДАННЫХ
        //public List<MessageEnum> EnumMetas { get; set; }
        public ICollection<GPA> GPAList { get; set; } //navigation property
    }
}
