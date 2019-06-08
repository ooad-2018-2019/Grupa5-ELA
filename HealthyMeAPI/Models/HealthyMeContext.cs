using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HealthyMeAPI
{
    public partial class HealthyMeContext : DbContext
    {
        public HealthyMeContext()
        {
        }

        public HealthyMeContext(DbContextOptions<HealthyMeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Aktivnost> Aktivnost { get; set; }
        public virtual DbSet<DnevniPlan> DnevniPlan { get; set; }
        public virtual DbSet<Dpaktivnost> Dpaktivnost { get; set; }
        public virtual DbSet<Dpobrok> Dpobrok { get; set; }
        public virtual DbSet<Namirnica> Namirnica { get; set; }
        public virtual DbSet<Obrok> Obrok { get; set; }
        public virtual DbSet<ObrokNamirnica> ObrokNamirnica { get; set; }
        public virtual DbSet<Odgovor> Odgovor { get; set; }
        public virtual DbSet<Pidozvoljena> Pidozvoljena { get; set; }
        public virtual DbSet<Pitanje> Pitanje { get; set; }
        public virtual DbSet<Pitest> Pitest { get; set; }
        public virtual DbSet<Pizabranjena> Pizabranjena { get; set; }
        public virtual DbSet<PlanIshrane> PlanIshrane { get; set; }
        public virtual DbSet<Podsjetnik> Podsjetnik { get; set; }
        public virtual DbSet<Recenzija> Recenzija { get; set; }
        public virtual DbSet<Registrovani> Registrovani { get; set; }
        public virtual DbSet<Rpodsjetnik> Rpodsjetnik { get; set; }
        public virtual DbSet<Test> Test { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:healthy-me.database.windows.net,1433;Initial Catalog=HealthyMe;Persist Security Info=False;User ID=ela2019;Password=Amila0712;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NivoPristupa)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username).IsRequired();
            });

            modelBuilder.Entity<Aktivnost>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv).IsRequired();
            });

            modelBuilder.Entity<DnevniPlan>(entity =>
            {
                entity.HasIndex(e => e.RegistrovaniId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RegistrovaniId).HasColumnName("RegistrovaniID");

                entity.HasOne(d => d.Registrovani)
                    .WithMany(p => p.DnevniPlan)
                    .HasForeignKey(d => d.RegistrovaniId);
            });

            modelBuilder.Entity<Dpaktivnost>(entity =>
            {
                entity.ToTable("DPAktivnost");

                entity.HasIndex(e => e.AktivnostId);

                entity.HasIndex(e => e.DnevniPlanId);

                entity.Property(e => e.DpaktivnostId).HasColumnName("DPAktivnostID");

                entity.Property(e => e.AktivnostId).HasColumnName("AktivnostID");

                entity.Property(e => e.DnevniPlanId).HasColumnName("DnevniPlanID");

                entity.HasOne(d => d.Aktivnost)
                    .WithMany(p => p.Dpaktivnost)
                    .HasForeignKey(d => d.AktivnostId);

                entity.HasOne(d => d.DnevniPlan)
                    .WithMany(p => p.Dpaktivnost)
                    .HasForeignKey(d => d.DnevniPlanId);
            });

            modelBuilder.Entity<Dpobrok>(entity =>
            {
                entity.ToTable("DPObrok");

                entity.HasIndex(e => e.DnevniPlanId);

                entity.HasIndex(e => e.ObrokId);

                entity.Property(e => e.DpobrokId).HasColumnName("DPObrokID");

                entity.Property(e => e.DnevniPlanId).HasColumnName("DnevniPlanID");

                entity.Property(e => e.ObrokId).HasColumnName("ObrokID");

                entity.HasOne(d => d.DnevniPlan)
                    .WithMany(p => p.Dpobrok)
                    .HasForeignKey(d => d.DnevniPlanId);

                entity.HasOne(d => d.Obrok)
                    .WithMany(p => p.Dpobrok)
                    .HasForeignKey(d => d.ObrokId);
            });

            modelBuilder.Entity<Namirnica>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv).IsRequired();
            });

            modelBuilder.Entity<Obrok>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<ObrokNamirnica>(entity =>
            {
                entity.HasIndex(e => e.NamirnicaId);

                entity.HasIndex(e => e.ObrokId);

                entity.Property(e => e.ObrokNamirnicaId).HasColumnName("ObrokNamirnicaID");

                entity.Property(e => e.NamirnicaId).HasColumnName("NamirnicaID");

                entity.Property(e => e.ObrokId).HasColumnName("ObrokID");

                entity.HasOne(d => d.Namirnica)
                    .WithMany(p => p.ObrokNamirnica)
                    .HasForeignKey(d => d.NamirnicaId);

                entity.HasOne(d => d.Obrok)
                    .WithMany(p => p.ObrokNamirnica)
                    .HasForeignKey(d => d.ObrokId);
            });

            modelBuilder.Entity<Odgovor>(entity =>
            {
                entity.HasIndex(e => e.PitanjeId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv).IsRequired();

                entity.Property(e => e.PitanjeId).HasColumnName("PitanjeID");

                entity.HasOne(d => d.Pitanje)
                    .WithMany(p => p.Odgovor)
                    .HasForeignKey(d => d.PitanjeId);
            });

            modelBuilder.Entity<Pidozvoljena>(entity =>
            {
                entity.ToTable("PIDozvoljena");

                entity.HasIndex(e => e.NamirnicaId);

                entity.HasIndex(e => e.PlanIshraneId);

                entity.Property(e => e.PidozvoljenaId).HasColumnName("PIDozvoljenaID");

                entity.Property(e => e.NamirnicaId).HasColumnName("NamirnicaID");

                entity.Property(e => e.PlanIshraneId).HasColumnName("PlanIshraneID");

                entity.HasOne(d => d.Namirnica)
                    .WithMany(p => p.Pidozvoljena)
                    .HasForeignKey(d => d.NamirnicaId);

                entity.HasOne(d => d.PlanIshrane)
                    .WithMany(p => p.Pidozvoljena)
                    .HasForeignKey(d => d.PlanIshraneId);
            });

            modelBuilder.Entity<Pitanje>(entity =>
            {
                entity.HasIndex(e => e.TestId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv).IsRequired();

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Pitanje)
                    .HasForeignKey(d => d.TestId);
            });

            modelBuilder.Entity<Pitest>(entity =>
            {
                entity.ToTable("PITest");

                entity.HasIndex(e => e.OdgovorId);

                entity.HasIndex(e => e.PlanIshraneId);

                entity.HasIndex(e => e.RegistrovaniId);

                entity.Property(e => e.PitestId).HasColumnName("PITestID");

                entity.Property(e => e.OdgovorId).HasColumnName("OdgovorID");

                entity.Property(e => e.PlanIshraneId).HasColumnName("PlanIshraneID");

                entity.Property(e => e.RegistrovaniId).HasColumnName("RegistrovaniID");

                entity.HasOne(d => d.Odgovor)
                    .WithMany(p => p.Pitest)
                    .HasForeignKey(d => d.OdgovorId);

                entity.HasOne(d => d.PlanIshrane)
                    .WithMany(p => p.Pitest)
                    .HasForeignKey(d => d.PlanIshraneId);

                entity.HasOne(d => d.Registrovani)
                    .WithMany(p => p.Pitest)
                    .HasForeignKey(d => d.RegistrovaniId);
            });

            modelBuilder.Entity<Pizabranjena>(entity =>
            {
                entity.ToTable("PIZabranjena");

                entity.HasIndex(e => e.NamirnicaId);

                entity.HasIndex(e => e.PlanIshraneId);

                entity.Property(e => e.PizabranjenaId).HasColumnName("PIZabranjenaID");

                entity.Property(e => e.NamirnicaId).HasColumnName("NamirnicaID");

                entity.Property(e => e.PlanIshraneId).HasColumnName("PlanIshraneID");

                entity.HasOne(d => d.Namirnica)
                    .WithMany(p => p.Pizabranjena)
                    .HasForeignKey(d => d.NamirnicaId);

                entity.HasOne(d => d.PlanIshrane)
                    .WithMany(p => p.Pizabranjena)
                    .HasForeignKey(d => d.PlanIshraneId);
            });

            modelBuilder.Entity<PlanIshrane>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv).IsRequired();
            });

            modelBuilder.Entity<Podsjetnik>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Opis).IsRequired();
            });

            modelBuilder.Entity<Recenzija>(entity =>
            {
                entity.HasIndex(e => e.RegistrovaniId)
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Komentar).IsRequired();

                entity.Property(e => e.RegistrovaniId).HasColumnName("RegistrovaniID");

                entity.HasOne(d => d.Registrovani)
                    .WithOne(p => p.Recenzija)
                    .HasForeignKey<Recenzija>(d => d.RegistrovaniId);
            });

            modelBuilder.Entity<Registrovani>(entity =>
            {
                entity.HasIndex(e => e.PlanIshraneId);

                entity.HasIndex(e => e.TestId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.PlanIshraneId).HasColumnName("PlanIshraneID");

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.Property(e => e.Username).IsRequired();

                entity.HasOne(d => d.PlanIshrane)
                    .WithMany(p => p.Registrovani)
                    .HasForeignKey(d => d.PlanIshraneId);

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Registrovani)
                    .HasForeignKey(d => d.TestId);
            });

            modelBuilder.Entity<Rpodsjetnik>(entity =>
            {
                entity.ToTable("RPodsjetnik");

                entity.HasIndex(e => e.PodsjetnikId);

                entity.HasIndex(e => e.RegistrovaniId);

                entity.Property(e => e.RpodsjetnikId).HasColumnName("RPodsjetnikID");

                entity.Property(e => e.PodsjetnikId).HasColumnName("PodsjetnikID");

                entity.Property(e => e.RegistrovaniId).HasColumnName("RegistrovaniID");

                entity.HasOne(d => d.Podsjetnik)
                    .WithMany(p => p.Rpodsjetnik)
                    .HasForeignKey(d => d.PodsjetnikId);

                entity.HasOne(d => d.Registrovani)
                    .WithMany(p => p.Rpodsjetnik)
                    .HasForeignKey(d => d.RegistrovaniId);
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");
            });
        }
    }
}
