using System;
using System.Collections.Generic;

namespace ACSWeb.Models
{
    public class UMG
    {
        public int ID { get; set; }  // идентификатор УМГ
        public string Name { get; set; } // Полное название
        public string ShortName { get; set; } // Сокращенное название (КТГ)
        public string City { get; set; }
        public ICollection<LVU> VLUList { get; set; }

    }
}
