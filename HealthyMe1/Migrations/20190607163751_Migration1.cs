using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyMe1.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Aktivnost",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Kalorije = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktivnost", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Namirnica",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Kalorije = table.Column<double>(nullable: false),
                    Proteini = table.Column<double>(nullable: false),
                    Ugljikohidrati = table.Column<double>(nullable: false),
                    Masti = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Namirnica", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Obrok",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kategorija = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obrok", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlanIshrane",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    DozvoljeneKalorije = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanIshrane", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Podsjetnik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true),
                    Period = table.Column<DateTime>(nullable: false),
                    Ponavljanje = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podsjetnik", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ObrokNamirnica",
                columns: table => new
                {
                    ObrokNamirnicaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ObrokID = table.Column<int>(nullable: false),
                    NamirnicaID = table.Column<int>(nullable: false),
                    Kolicina = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObrokNamirnica", x => x.ObrokNamirnicaID);
                    table.ForeignKey(
                        name: "FK_ObrokNamirnica_Namirnica_NamirnicaID",
                        column: x => x.NamirnicaID,
                        principalTable: "Namirnica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObrokNamirnica_Obrok_ObrokID",
                        column: x => x.ObrokID,
                        principalTable: "Obrok",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PIDozvoljena",
                columns: table => new
                {
                    PIDozvoljenaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NamirnicaID = table.Column<int>(nullable: false),
                    PlanIshraneID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIDozvoljena", x => x.PIDozvoljenaID);
                    table.ForeignKey(
                        name: "FK_PIDozvoljena_Namirnica_NamirnicaID",
                        column: x => x.NamirnicaID,
                        principalTable: "Namirnica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PIDozvoljena_PlanIshrane_PlanIshraneID",
                        column: x => x.PlanIshraneID,
                        principalTable: "PlanIshrane",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PIZabranjena",
                columns: table => new
                {
                    PIZabranjenaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NamirnicaID = table.Column<int>(nullable: false),
                    PlanIshraneID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIZabranjena", x => x.PIZabranjenaID);
                    table.ForeignKey(
                        name: "FK_PIZabranjena_Namirnica_NamirnicaID",
                        column: x => x.NamirnicaID,
                        principalTable: "Namirnica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PIZabranjena_PlanIshrane_PlanIshraneID",
                        column: x => x.PlanIshraneID,
                        principalTable: "PlanIshrane",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pitanje",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    TestID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitanje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pitanje_Test_TestID",
                        column: x => x.TestID,
                        principalTable: "Test",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrovani",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Spol = table.Column<int>(nullable: false),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    Visina = table.Column<double>(nullable: false),
                    Tezina = table.Column<double>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TestID = table.Column<int>(nullable: true),
                    PlanIshraneID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrovani", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Registrovani_PlanIshrane_PlanIshraneID",
                        column: x => x.PlanIshraneID,
                        principalTable: "PlanIshrane",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registrovani_Test_TestID",
                        column: x => x.TestID,
                        principalTable: "Test",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Odgovor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    PitanjeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odgovor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Odgovor_Pitanje_PitanjeID",
                        column: x => x.PitanjeID,
                        principalTable: "Pitanje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DnevniPlan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Period = table.Column<DateTime>(nullable: false),
                    PreostaleKalorije = table.Column<double>(nullable: false),
                    RegistrovaniID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DnevniPlan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DnevniPlan_Registrovani_RegistrovaniID",
                        column: x => x.RegistrovaniID,
                        principalTable: "Registrovani",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recenzija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Komentar = table.Column<string>(nullable: true),
                    Ocjena = table.Column<int>(nullable: false),
                    RegistrovaniID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recenzija_Registrovani_RegistrovaniID",
                        column: x => x.RegistrovaniID,
                        principalTable: "Registrovani",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RPodsjetnik",
                columns: table => new
                {
                    RPodsjetnikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PodsjetnikID = table.Column<int>(nullable: false),
                    RegistrovaniID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RPodsjetnik", x => x.RPodsjetnikID);
                    table.ForeignKey(
                        name: "FK_RPodsjetnik_Podsjetnik_PodsjetnikID",
                        column: x => x.PodsjetnikID,
                        principalTable: "Podsjetnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RPodsjetnik_Registrovani_RegistrovaniID",
                        column: x => x.RegistrovaniID,
                        principalTable: "Registrovani",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PITest",
                columns: table => new
                {
                    PITestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OdgovorID = table.Column<int>(nullable: false),
                    PlanIshraneID = table.Column<int>(nullable: false),
                    RegistrovaniID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PITest", x => x.PITestID);
                    table.ForeignKey(
                        name: "FK_PITest_Odgovor_OdgovorID",
                        column: x => x.OdgovorID,
                        principalTable: "Odgovor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PITest_PlanIshrane_PlanIshraneID",
                        column: x => x.PlanIshraneID,
                        principalTable: "PlanIshrane",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PITest_Registrovani_RegistrovaniID",
                        column: x => x.RegistrovaniID,
                        principalTable: "Registrovani",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DPAktivnost",
                columns: table => new
                {
                    DPAktivnostID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DnevniPlanID = table.Column<int>(nullable: false),
                    AktivnostID = table.Column<int>(nullable: false),
                    Trajanje = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DPAktivnost", x => x.DPAktivnostID);
                    table.ForeignKey(
                        name: "FK_DPAktivnost_Aktivnost_AktivnostID",
                        column: x => x.AktivnostID,
                        principalTable: "Aktivnost",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DPAktivnost_DnevniPlan_DnevniPlanID",
                        column: x => x.DnevniPlanID,
                        principalTable: "DnevniPlan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DPObrok",
                columns: table => new
                {
                    DPObrokID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DnevniPlanID = table.Column<int>(nullable: false),
                    ObrokID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DPObrok", x => x.DPObrokID);
                    table.ForeignKey(
                        name: "FK_DPObrok_DnevniPlan_DnevniPlanID",
                        column: x => x.DnevniPlanID,
                        principalTable: "DnevniPlan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DPObrok_Obrok_ObrokID",
                        column: x => x.ObrokID,
                        principalTable: "Obrok",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DnevniPlan_RegistrovaniID",
                table: "DnevniPlan",
                column: "RegistrovaniID");

            migrationBuilder.CreateIndex(
                name: "IX_DPAktivnost_AktivnostID",
                table: "DPAktivnost",
                column: "AktivnostID");

            migrationBuilder.CreateIndex(
                name: "IX_DPAktivnost_DnevniPlanID",
                table: "DPAktivnost",
                column: "DnevniPlanID");

            migrationBuilder.CreateIndex(
                name: "IX_DPObrok_DnevniPlanID",
                table: "DPObrok",
                column: "DnevniPlanID");

            migrationBuilder.CreateIndex(
                name: "IX_DPObrok_ObrokID",
                table: "DPObrok",
                column: "ObrokID");

            migrationBuilder.CreateIndex(
                name: "IX_ObrokNamirnica_NamirnicaID",
                table: "ObrokNamirnica",
                column: "NamirnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_ObrokNamirnica_ObrokID",
                table: "ObrokNamirnica",
                column: "ObrokID");

            migrationBuilder.CreateIndex(
                name: "IX_Odgovor_PitanjeID",
                table: "Odgovor",
                column: "PitanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_PIDozvoljena_NamirnicaID",
                table: "PIDozvoljena",
                column: "NamirnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_PIDozvoljena_PlanIshraneID",
                table: "PIDozvoljena",
                column: "PlanIshraneID");

            migrationBuilder.CreateIndex(
                name: "IX_Pitanje_TestID",
                table: "Pitanje",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_PITest_OdgovorID",
                table: "PITest",
                column: "OdgovorID");

            migrationBuilder.CreateIndex(
                name: "IX_PITest_PlanIshraneID",
                table: "PITest",
                column: "PlanIshraneID");

            migrationBuilder.CreateIndex(
                name: "IX_PITest_RegistrovaniID",
                table: "PITest",
                column: "RegistrovaniID");

            migrationBuilder.CreateIndex(
                name: "IX_PIZabranjena_NamirnicaID",
                table: "PIZabranjena",
                column: "NamirnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_PIZabranjena_PlanIshraneID",
                table: "PIZabranjena",
                column: "PlanIshraneID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_RegistrovaniID",
                table: "Recenzija",
                column: "RegistrovaniID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registrovani_PlanIshraneID",
                table: "Registrovani",
                column: "PlanIshraneID");

            migrationBuilder.CreateIndex(
                name: "IX_Registrovani_TestID",
                table: "Registrovani",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_RPodsjetnik_PodsjetnikID",
                table: "RPodsjetnik",
                column: "PodsjetnikID");

            migrationBuilder.CreateIndex(
                name: "IX_RPodsjetnik_RegistrovaniID",
                table: "RPodsjetnik",
                column: "RegistrovaniID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "DPAktivnost");

            migrationBuilder.DropTable(
                name: "DPObrok");

            migrationBuilder.DropTable(
                name: "ObrokNamirnica");

            migrationBuilder.DropTable(
                name: "PIDozvoljena");

            migrationBuilder.DropTable(
                name: "PITest");

            migrationBuilder.DropTable(
                name: "PIZabranjena");

            migrationBuilder.DropTable(
                name: "Recenzija");

            migrationBuilder.DropTable(
                name: "RPodsjetnik");

            migrationBuilder.DropTable(
                name: "Aktivnost");

            migrationBuilder.DropTable(
                name: "DnevniPlan");

            migrationBuilder.DropTable(
                name: "Obrok");

            migrationBuilder.DropTable(
                name: "Odgovor");

            migrationBuilder.DropTable(
                name: "Namirnica");

            migrationBuilder.DropTable(
                name: "Podsjetnik");

            migrationBuilder.DropTable(
                name: "Registrovani");

            migrationBuilder.DropTable(
                name: "Pitanje");

            migrationBuilder.DropTable(
                name: "PlanIshrane");

            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
