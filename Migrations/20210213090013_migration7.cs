using Microsoft.EntityFrameworkCore.Migrations;

namespace EFProjektTry3.Migrations
{
    public partial class migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RocordId",
                table: "Loans");

            migrationBuilder.AddColumn<string>(
                name: "RecordName",
                table: "Loans",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordName",
                table: "Loans");

            migrationBuilder.AddColumn<int>(
                name: "RocordId",
                table: "Loans",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
