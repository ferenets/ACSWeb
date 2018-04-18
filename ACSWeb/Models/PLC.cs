using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACSWeb.Models
{
    public class PLC
    {
        public int ID { get; set; }
        public string Manufacturer { get; set; } //Siemens, Schneider
        public string ModelName { get; set; } //S7-410
        //public string SerieName { get; set; } //S7-400

        public string Notes { get; set; }  //Primechaniya
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
    }
}
