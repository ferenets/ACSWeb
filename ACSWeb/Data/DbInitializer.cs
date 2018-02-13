using ACSWeb.Models;
using System;
using System.Linq;

namespace ACSWeb.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GTSContext context)
        {
            context.Database.EnsureCreated();

            // Look for any SAKs.
            if (context.SAKs.Any())
            {
                return;   // DB has been seeded
            }

            var kss = new KS[]
            {
                new KS{Name="КС Лубни"},
                new KS{Name="КС Диканька"},

            };
            foreach (KS k in kss)
            {
                context.KSs.Add(k);
            }
            context.SaveChanges();


            var saks = new SAK[]
            {
                new SAK{ Name="ІНЕК Fanuc 9030", MTBase="Fanuc 9030", Manufacturer="АТТІЗ", CommisioningDate=DateTime.Parse("01.01.2005")},
                new SAK{ Name="ІНЕК Fanuc 9030", MTBase="Fanuc 9030", Manufacturer="АТТІЗ", CommisioningDate=DateTime.Parse("02.01.2004")},
                new SAK{ Name="ІНЕК Fanuc 9030", MTBase="Fanuc 9030", Manufacturer="АТТІЗ", CommisioningDate=DateTime.Parse("03.03.2007")}
            };

            foreach (SAK s in saks)
            {
                context.SAKs.Add(s); //добавляем каждую САУ из списка saks в контекст
            }

            context.SaveChanges();  //сохраняем (наверное пишем в БД)

            var gpas = new GPA[]
            {
                new GPA{ Type="ГТ-750-6", GTDType="ДГ-90", VCNType="650-22-2", StationNumber=1},
                new GPA{ Type="ГТ-750-6", GTDType="ДГ-90", VCNType="650-22-2", StationNumber=2},
                new GPA{ Type="ГТ-750-6", GTDType="ДГ-90", VCNType="650-22-2", StationNumber=3},
                new GPA{ Type="ГТ-750-6", GTDType="ДГ-90", VCNType="650-22-2", StationNumber=4},
                new GPA{ Type="ГТ-750-6", GTDType="ДГ-90", VCNType="650-22-2", StationNumber=5},
            };

            foreach (GPA g in gpas)
            {
                context.GPAs.Add(g);
            }

            context.SaveChanges();


        }
    }
}
