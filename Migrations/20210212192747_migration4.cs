using Microsoft.EntityFrameworkCore.Migrations;

namespace EFProjektTry3.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecordGenre",
                table: "Records",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RocordId",
                table: "Loans",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordGenre",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "RocordId",
                table: "Loans");
        }
    }
}
