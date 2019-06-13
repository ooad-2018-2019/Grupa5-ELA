﻿// <auto-generated />
using System;
using HealthyMe1.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthyMe1.Migrations
{
    [DbContext(typeof(HealthyMeContext))]
    [Migration("20190613150109_Migration4")]
    partial class Migration4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HealthyMe1.Models.Administrator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("NivoPristupa")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("HealthyMe1.Models.Aktivnost", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Kalorije");

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Aktivnost");
                });

            modelBuilder.Entity("HealthyMe1.Models.DPAktivnost", b =>
                {
                    b.Property<int>("DPAktivnostID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AktivnostID");

                    b.Property<int>("DnevniPlanID");

                    b.Property<double?>("Trajanje");

                    b.HasKey("DPAktivnostID");

                    b.HasIndex("AktivnostID");

                    b.HasIndex("DnevniPlanID");

                    b.ToTable("DPAktivnost");
                });

            modelBuilder.Entity("HealthyMe1.Models.DPObrok", b =>
                {
                    b.Property<int>("DPObrokID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DnevniPlanID");

                    b.Property<int>("ObrokID");

                    b.HasKey("DPObrokID");

                    b.HasIndex("DnevniPlanID");

                    b.HasIndex("ObrokID");

                    b.ToTable("DPObrok");
                });

            modelBuilder.Entity("HealthyMe1.Models.DnevniPlan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Period");

                    b.Property<double>("PreostaleKalorije");

                    b.Property<int>("RegistrovaniID");

                    b.HasKey("ID");

                    b.HasIndex("RegistrovaniID");

                    b.ToTable("DnevniPlan");
                });

            modelBuilder.Entity("HealthyMe1.Models.Namirnica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Kalorije");

                    b.Property<double>("Masti");

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.Property<double>("Proteini");

                    b.Property<double>("Ugljikohidrati");

                    b.HasKey("ID");

                    b.ToTable("Namirnica");
                });

            modelBuilder.Entity("HealthyMe1.Models.Obrok", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kategorija");

                    b.HasKey("ID");

                    b.ToTable("Obrok");
                });

            modelBuilder.Entity("HealthyMe1.Models.ObrokNamirnica", b =>
                {
                    b.Property<int>("ObrokNamirnicaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("Kolicina");

                    b.Property<int>("NamirnicaID");

                    b.Property<int>("ObrokID");

                    b.HasKey("ObrokNamirnicaID");

                    b.HasIndex("NamirnicaID");

                    b.HasIndex("ObrokID");

                    b.ToTable("ObrokNamirnica");
                });

            modelBuilder.Entity("HealthyMe1.Models.Odgovor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.Property<int>("PitanjeID");

                    b.HasKey("ID");

                    b.HasIndex("PitanjeID");

                    b.ToTable("Odgovor");
                });

            modelBuilder.Entity("HealthyMe1.Models.PIDozvoljena", b =>
                {
                    b.Property<int>("PIDozvoljenaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NamirnicaID");

                    b.Property<int>("PlanIshraneID");

                    b.HasKey("PIDozvoljenaID");

                    b.HasIndex("NamirnicaID");

                    b.HasIndex("PlanIshraneID");

                    b.ToTable("PIDozvoljena");
                });

            modelBuilder.Entity("HealthyMe1.Models.PITest", b =>
                {
                    b.Property<int>("PITestID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OdgovorID");

                    b.Property<int>("PlanIshraneID");

                    b.Property<int>("RegistrovaniID");

                    b.HasKey("PITestID");

                    b.HasIndex("OdgovorID");

                    b.HasIndex("PlanIshraneID");

                    b.HasIndex("RegistrovaniID");

                    b.ToTable("PITest");
                });

            modelBuilder.Entity("HealthyMe1.Models.PIZabranjena", b =>
                {
                    b.Property<int>("PIZabranjenaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NamirnicaID");

                    b.Property<int>("PlanIshraneID");

                    b.HasKey("PIZabranjenaID");

                    b.HasIndex("NamirnicaID");

                    b.HasIndex("PlanIshraneID");

                    b.ToTable("PIZabranjena");
                });

            modelBuilder.Entity("HealthyMe1.Models.Pitanje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.Property<int>("TestID");

                    b.HasKey("ID");

                    b.HasIndex("TestID");

                    b.ToTable("Pitanje");
                });

            modelBuilder.Entity("HealthyMe1.Models.PlanIshrane", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("DozvoljeneKalorije");

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("PlanIshrane");
                });

            modelBuilder.Entity("HealthyMe1.Models.Podsjetnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Opis")
                        .IsRequired();

                    b.Property<DateTime>("Period");

                    b.Property<int>("Ponavljanje");

                    b.HasKey("ID");

                    b.ToTable("Podsjetnik");
                });

            modelBuilder.Entity("HealthyMe1.Models.RPodsjetnik", b =>
                {
                    b.Property<int>("RPodsjetnikID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PodsjetnikID");

                    b.Property<int?>("RegistrovaniID");

                    b.HasKey("RPodsjetnikID");

                    b.HasIndex("PodsjetnikID");

                    b.HasIndex("RegistrovaniID");

                    b.ToTable("RPodsjetnik");
                });

            modelBuilder.Entity("HealthyMe1.Models.Recenzija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Komentar")
                        .IsRequired();

                    b.Property<int>("Ocjena");

                    b.Property<int>("RegistrovaniID");

                    b.HasKey("ID");

                    b.HasIndex("RegistrovaniID")
                        .IsUnique();

                    b.ToTable("Recenzija");
                });

            modelBuilder.Entity("HealthyMe1.Models.Registrovani", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Ime")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int?>("PlanIshraneID");

                    b.Property<int>("Spol");

                    b.Property<int?>("TestID");

                    b.Property<double>("Tezina");

                    b.Property<double>("Visina");

                    b.HasKey("ID");

                    b.HasIndex("PlanIshraneID");

                    b.HasIndex("TestID");

                    b.ToTable("Registrovani");
                });

            modelBuilder.Entity("HealthyMe1.Models.Test", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("HealthyMe1.Models.DPAktivnost", b =>
                {
                    b.HasOne("HealthyMe1.Models.Aktivnost", "Aktivnost")
                        .WithMany("DPAktivnosti")
                        .HasForeignKey("AktivnostID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthyMe1.Models.DnevniPlan", "DnevniPlan")
                        .WithMany("DPAktivnosti")
                        .HasForeignKey("DnevniPlanID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthyMe1.Models.DPObrok", b =>
                {
                    b.HasOne("HealthyMe1.Models.DnevniPlan", "DnevniPlan")
                        .WithMany("DPObroci")
                        .HasForeignKey("DnevniPlanID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthyMe1.Models.Obrok", "Obrok")
                        .WithMany("DPObroci")
                        .HasForeignKey("ObrokID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthyMe1.Models.DnevniPlan", b =>
                {
                    b.HasOne("HealthyMe1.Models.Registrovani", "Registrovani")
                        .WithMany("DnevniPlanovi")
                        .HasForeignKey("RegistrovaniID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthyMe1.Models.ObrokNamirnica", b =>
                {
                    b.HasOne("HealthyMe1.Models.Namirnica", "Namirnica")
                        .WithMany("ObrokNamirnice")
                        .HasForeignKey("NamirnicaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthyMe1.Models.Obrok", "Obrok")
                        .WithMany("ObrokNamirnice")
                        .HasForeignKey("ObrokID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthyMe1.Models.Odgovor", b =>
                {
                    b.HasOne("HealthyMe1.Models.Pitanje", "Pitanje")
                        .WithMany("Odgovori")
                        .HasForeignKey("PitanjeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthyMe1.Models.PIDozvoljena", b =>
                {
                    b.HasOne("HealthyMe1.Models.Namirnica", "Dozvoljena")
                        .WithMany("Dozvoljene")
                        .HasForeignKey("NamirnicaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthyMe1.Models.PlanIshrane", "PlanIshrane")
                        .WithMany("PIDozvoljene")
                        .HasForeignKey("PlanIshraneID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthyMe1.Models.PITest", b =>
                {
                    b.HasOne("HealthyMe1.Models.Odgovor", "Odgovor")
                        .WithMany("RezultatiTesta")
                        .HasForeignKey("OdgovorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthyMe1.Models.PlanIshrane", "PlanIshrane")
                        .WithMany("RezultatiTesta")
                        .HasForeignKey("PlanIshraneID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthyMe1.Models.Registrovani", "Registrovani")
                        .WithMany("RezultatiTesta")
                        .HasForeignKey("RegistrovaniID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthyMe1.Models.PIZabranjena", b =>
                {
                    b.HasOne("HealthyMe1.Models.Namirnica", "Zabranjena")
                        .WithMany("Zabranjene")
                        .HasForeignKey("NamirnicaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthyMe1.Models.PlanIshrane", "PlanIshrane")
                        .WithMany("PIZabranjene")
                        .HasForeignKey("PlanIshraneID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthyMe1.Models.Pitanje", b =>
                {
                    b.HasOne("HealthyMe1.Models.Test", "Test")
                        .WithMany("Pitanja")
                        .HasForeignKey("TestID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthyMe1.Models.RPodsjetnik", b =>
                {
                    b.HasOne("HealthyMe1.Models.Podsjetnik", "Podsjetnik")
                        .WithMany("RPodsjetnici")
                        .HasForeignKey("PodsjetnikID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HealthyMe1.Models.Registrovani", "Registrovani")
                        .WithMany("RPodsjetnici")
                        .HasForeignKey("RegistrovaniID");
                });

            modelBuilder.Entity("HealthyMe1.Models.Recenzija", b =>
                {
                    b.HasOne("HealthyMe1.Models.Registrovani", "Registrovani")
                        .WithOne("Recenzija")
                        .HasForeignKey("HealthyMe1.Models.Recenzija", "RegistrovaniID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HealthyMe1.Models.Registrovani", b =>
                {
                    b.HasOne("HealthyMe1.Models.PlanIshrane", "PlanIshrane")
                        .WithMany("RKorisnici")
                        .HasForeignKey("PlanIshraneID");

                    b.HasOne("HealthyMe1.Models.Test", "Test")
                        .WithMany("RKorisnici")
                        .HasForeignKey("TestID");
                });
#pragma warning restore 612, 618
        }
    }
}
