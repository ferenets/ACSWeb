﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACSWeb.Models
{
    public class KSPipeline //Промежуточный класс для реализации многие ко многим
    {
        public int ID { get; set; }
        public int KSID { get; set; }
        public KS KS { get; set; }
        public int PipelineID { get; set; }
        public Pipeline Pipeline { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
    }
}
