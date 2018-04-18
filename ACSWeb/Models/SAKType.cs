using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACSWeb.Models
{
    public class SAKType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }  //Primechaniya
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }

    }
}
