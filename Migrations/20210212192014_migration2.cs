using Microsoft.EntityFrameworkCore.Migrations;

namespace EFProjektTry3.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordGenre",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Loans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecordGenre",
                table: "Records",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Loans",
                type: "TEXT",
                nullable: true);
        }
    }
}
