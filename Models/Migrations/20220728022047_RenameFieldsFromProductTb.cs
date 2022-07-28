using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class RenameFieldsFromProductTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Company_Company_Id",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Company_Id",
                table: "Product",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "Product_Id",
                table: "Product",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Company_Id",
                table: "Product",
                newName: "IX_Product_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Company_CompanyId",
                table: "Product",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Company_CompanyId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Product",
                newName: "Company_Id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Product",
                newName: "Product_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CompanyId",
                table: "Product",
                newName: "IX_Product_Company_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Company_Company_Id",
                table: "Product",
                column: "Company_Id",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
