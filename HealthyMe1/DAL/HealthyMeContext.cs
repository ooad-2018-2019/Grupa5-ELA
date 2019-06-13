using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HealthyMe1.Models;

namespace HealthyMe1.DAL
{
    public class HealthyMeContext : DbContext
    {
        public static HealthyMeContext instance;

        public static HealthyMeContext GetInstance()
        {
            return instance;
        }

        public HealthyMeContext(DbContextOptions<HealthyMeContext> options) : base(options)
        {
            instance = this;
        }

        public DbSet<Administrator> Administratori { get; set; }
        public DbSet<Aktivnost> Aktivnosti { get; set; }
        public DbSet<DnevniPlan> DnevniPlanovi { get; set; }
        public DbSet<DPAktivnost> DPAktivnosti { get; set; }
        public DbSet<DPObrok> DPObroci { get; set; }
        public DbSet<Obrok> Obroci { get; set; }
        public DbSet<Namirnica> Namirnice { get; set; }
        public DbSet<ObrokNamirnica> ObrokNamirnice { get; set; }
        public DbSet<Odgovor> Odgovori { get; set; }
        public DbSet<PIDozvoljena> PIDozvoljene { get; set; }
        public DbSet<PIZabranjena> PIZabranjene { get; set; }
        public DbSet<Pitanje> Pitanja { get; set; }
        public DbSet<PITest> PITestovi { get; set; }
        public DbSet<PlanIshrane> PlanoviIshrane { get; set; }
        public DbSet<Podsjetnik> Podsjetnici { get; set; }
        public DbSet<Recenzija> Recenzije { get; set; }
        public DbSet<Registrovani> Registrovani { get; set; }
        public DbSet<RPodsjetnik> RPodsjetnici { get; set; }
        public DbSet<Test> Testovi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>().ToTable("Administrator");
            modelBuilder.Entity<Aktivnost>().ToTable("Aktivnost");
            modelBuilder.Entity<DnevniPlan>().ToTable("DnevniPlan");
            modelBuilder.Entity<DPAktivnost>().ToTable("DPAktivnost");
            modelBuilder.Entity<DPObrok>().ToTable("DPObrok");
            modelBuilder.Entity<Namirnica>().ToTable("Namirnica");
            modelBuilder.Entity<Obrok>().ToTable("Obrok");
            modelBuilder.Entity<ObrokNamirnica>().ToTable("ObrokNamirnica");
            modelBuilder.Entity<Odgovor>().ToTable("Odgovor");
            modelBuilder.Entity<PIDozvoljena>().ToTable("PIDozvoljena");
            modelBuilder.Entity<PIZabranjena>().ToTable("PIZabranjena");
            modelBuilder.Entity<Pitanje>().ToTable("Pitanje");
            modelBuilder.Entity<PITest>().ToTable("PITest");
            modelBuilder.Entity<PlanIshrane>().ToTable("PlanIshrane");
            modelBuilder.Entity<Podsjetnik>().ToTable("Podsjetnik");
            modelBuilder.Entity<Recenzija>().ToTable("Recenzija");
            modelBuilder.Entity<Registrovani>().ToTable("Registrovani");
            modelBuilder.Entity<RPodsjetnik>().ToTable("RPodsjetnik");
            modelBuilder.Entity<Test>().ToTable("Test");

        }

    }
}