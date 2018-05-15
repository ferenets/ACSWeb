using System;
using System.Collections.Generic;

namespace ACSWeb.Models
{
    public class KS
    {
        public int ID { get; set; }
        public string Name { get; set; } //Шебелинка-1
        public string ShortCompShopName { get; set; }//Ц081
        public int LVUID { get; set; }  //foreign key
        public int AOTypeID { get; set; } //foreign key

        //public int SAKID { get; set; } //foreign key  привязка обьекта САУ к ОА
        //public IList<int> PipelineIDList { get; set; } //foreign key (test for multiple values in 1 KS)
        //public ICollection<int> GPAIDList { get; set; } //foreign key (test for multiple values in 1 KS)

        public string Notes { get; set; }  //Primechaniya
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }

        //---------------------------------------------------------
        public LVU LVU { get; set; } //navigation property
        public AOType AOType { get; set; } //navigation property для отображения на индексхтмл имеено текста типа ОА
        public ICollection<KSPipeline> PipelineList { get; set; } //navigation property с ПРОМЕЖУТОЧНЫМ ТИПОМ ДАННЫХ

        //public List<MessageEnum> EnumMetas { get; set; }
        public ICollection<GPA> GPAList { get; set; } //navigation property
    }
}
