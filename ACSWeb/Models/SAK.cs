using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACSWeb.Models
{
    public class SAK
    {
        public int ID { get; set; }
        public string Name { get; set; }
        //public string BaseManufacturer { get; set; } //Siemens, Schneider
        public int PLCID { get; set; } //S7-400
        public string Manufacturer { get; set; }  //SAS

        public string Seller { get; set; } //
        
/*        [Display(Name = "CommisioningDate")]
        [Column("CommisioningDate", TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]*/
        
        [Display(Name = "CommisioningDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CommisioningDate { get; set; }
        
        
        public int AOTypeID { get; set; }  //foreign key
        public int AOID { get; set; }  //Ссылка на ИД в нужной=выбранной таблице
        public int SAKTypeID { get; set; } //foreign key

        public string Notes { get; set; }  //Primechaniya
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }

        public SAKType SAKType { get; set; } //navigation property
        public AOType AOType { get; set; } //navigation property
        public PLC PLC { get; set; } //navigation property

    }
}
