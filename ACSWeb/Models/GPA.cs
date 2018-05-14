using System;
using System.Collections.Generic;

namespace ACSWeb.Models
{
    public class GPA
    {
        public int ID { get; set; }
        public string Name { get; set; }//ГТК-10І
        public float Power { get; set; } //MW
        public string EngineType { get; set; } //ГТД
        public string EngineManufacturer { get; set; } //ЗОРЯ-МАШПРОЕКТ
        public string EngineName { get; set; } //ДГ-90Л2
        public string VCNManufacturer { get; set; } //Сумське НПО
        public string VCNName { get; set; } //650-22-2
        public int StationNumber { get; set; }
        //public string CompShopName { get; set; } КС прирівнюмо до КЦ. Наприклад Шебелинка-1, Шебелинка-2
        //-------
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
        //-------

        public int KSID { get; set; }//foreign key
        public int AOTypeID { get; set; } //foreign key   указание какого именно типа этот ОА
        //public int SAKID { get; set; } //foreign key  привязка обьекта САУ к ОА (наверное не нужно т к обратным поиском по САУ по ИД от ОА)
        public string Notes { get; set; }  //Primechaniya



        //----------------------------------------------------------------------
        public KS KS { get; set; } //navigation property
        public SAK SAK { get; set; } //navigation property  The child/dependent side could not be determined for the one-to-one relationship that was detected between 'GPA.SAK' and 'SAK.GPA'. To identify the child/dependent side of the relationship, configure the foreign key property. If these navigations should not be part of the same relationship configure them without specifying the inverse. See http://go.microsoft.com/fwlink/?LinkId=724062 for more details.
        public AOType AOType { get; set; } //navigation property

    }
}
