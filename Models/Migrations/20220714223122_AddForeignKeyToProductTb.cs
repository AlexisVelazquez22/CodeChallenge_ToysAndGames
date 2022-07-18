using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class AddForeignKeyToProductTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Company_Id",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Company_Id",
                table: "Product",
                column: "Company_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Company_Company_Id",
                table: "Product",
                column: "Company_Id",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Company_Company_Id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_Company_Id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Company_Id",
                table: "Product");
        }
    }
}
