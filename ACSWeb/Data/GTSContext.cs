using ACSWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ACSWeb.Data
{
    public class GTSContext : IdentityDbContext<ApplicationUser> //НЕ ПРОСТО DbContext!!!!!!!! решает все вопросы с таблицами и хранением пользователей
    {
        public GTSContext(DbContextOptions<GTSContext> options) : base(options)
        {
        }

        public DbSet<UMG> UMGs { get; set; } //Имя DbSet а саме UMGs - имя таблиці БД
        public DbSet<LVU> LVUs { get; set; }
        public DbSet<KS> KSs { get; set; }
        public DbSet<GPA> GPAs { get; set; } 
        public DbSet<SAK> SAKs { get; set; }
        public DbSet<SAKType> SAKTypes { get; set; }
        public DbSet<Pipeline> Pipelines { get; set; }
        //public DbSet<ApplicationUser> Users { get; set; }   // Таблица для пользователей

        protected override void OnModelCreating(ModelBuilder modelBuilder) //переопределим формирование ИМЕН таблиц БД на следующие:
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UMG>().ToTable("UMG");
            modelBuilder.Entity<LVU>().ToTable("LVU");
            modelBuilder.Entity<KS>().ToTable("KS");
            modelBuilder.Entity<GPA>().ToTable("GPA");
            modelBuilder.Entity<SAK>().ToTable("SAK");
            modelBuilder.Entity<SAKType>().ToTable("SAKType");
            modelBuilder.Entity<Pipeline>().ToTable("Pipeline");
            //modelBuilder.Entity<ApplicationUser>().ToTable("Users"); // Таблица для пользователей
        }


    }
}
