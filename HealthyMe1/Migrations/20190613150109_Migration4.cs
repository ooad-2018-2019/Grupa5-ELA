using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyMe1.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Registrovani",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Administrator",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Registrovani",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Administrator",
                newName: "Username");
        }
    }
}
