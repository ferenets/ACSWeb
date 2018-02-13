﻿using System;
using System.Collections.Generic;

namespace ACSWeb.Models
{
    public class KS
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public LVU LVU { get; set; }
        public ICollection<GPA> GPAs { get; set; }
    }
}