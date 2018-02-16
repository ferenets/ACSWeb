﻿using System;
using System.Collections.Generic;

namespace ACSWeb.Models
{
    public class SAK
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MTBase { get; set; }
        public string Manufacturer { get; set; }

        public string Seller { get; set; }
        public DateTime CommisioningDate { get; set; }

        public int GPAID { get; set; }  //foreign key
        public int SAKTypeID { get; set; } //foreign key


        public SAKType SAKType { get; set; } //navigation property
        public GPA GPA { get; set; } //navigation property

    }
}
