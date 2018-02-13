using ACSWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ACSWeb.Data
{
    public class GTSContext : DbContext
    {
        public GTSContext(DbContextOptions<GTSContext> options) : base(options)
        {
        }

        public DbSet<UMG> UMGs { get; set; } //Имя DbSet а саме UMGs - имя таблиці БД
        public DbSet<LVU> LVUs { get; set; }
        public DbSet<KS> KSs { get; set; }
        public DbSet<GPA> GPAs { get; set; }
        public DbSet<SAK> SAKs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //переопределим формирование ИМЕН таблиц БД на следующие:
        {
            modelBuilder.Entity<UMG>().ToTable("UMG");
            modelBuilder.Entity<LVU>().ToTable("LVU");
            modelBuilder.Entity<KS>().ToTable("KS");
            modelBuilder.Entity<GPA>().ToTable("GPA");
            modelBuilder.Entity<SAK>().ToTable("SAK");
        }


    }
}
