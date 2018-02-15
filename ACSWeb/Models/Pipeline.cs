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
        public ICollection<KS> KSList { get; set; }
    }
}
