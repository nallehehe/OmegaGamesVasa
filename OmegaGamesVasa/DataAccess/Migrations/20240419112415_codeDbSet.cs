using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class codeDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCode_Products_ProductId",
                table: "ProductCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCode",
                table: "ProductCode");

            migrationBuilder.RenameTable(
                name: "ProductCode",
                newName: "ProductCodes");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCode_ProductId",
                table: "ProductCodes",
                newName: "IX_ProductCodes_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCodes",
                table: "ProductCodes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCodes_Products_ProductId",
                table: "ProductCodes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCodes_Products_ProductId",
                table: "ProductCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCodes",
                table: "ProductCodes");

            migrationBuilder.RenameTable(
                name: "ProductCodes",
                newName: "ProductCode");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCodes_ProductId",
                table: "ProductCode",
                newName: "IX_ProductCode_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCode",
                table: "ProductCode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCode_Products_ProductId",
                table: "ProductCode",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
