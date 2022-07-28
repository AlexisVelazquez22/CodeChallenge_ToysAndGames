using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class RenameColumnFromCompanyTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Company_Name",
                table: "Company",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Company",
                newName: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Company",
                newName: "Company_Name");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Company",
                newName: "Id");
        }
    }
}
