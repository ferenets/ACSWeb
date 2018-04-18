using System;
using System.Collections.Generic;

namespace ACSWeb.Models
{
    public class AOType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public string ControllerName { get; set; } //Имя контроллера, который будет обрабатывать по ID
        public string AOTableName { get; set; } //Имя таблицы, на которую ссылаться по ID
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }


        public string Notes { get; set; }  //Primechaniya



    }
}
