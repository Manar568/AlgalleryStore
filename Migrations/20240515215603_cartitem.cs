using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlGallery.Migrations
{
    /// <inheritdoc />
    public partial class cartitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_CustomersId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Products_ProductsId",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "CartItems");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_ProductsId",
                table: "CartItems",
                newName: "IX_CartItems_ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_CustomersId",
                table: "CartItems",
                newName: "IX_CartItems_CustomersId");

            migrationBuilder.AddColumn<string>(
                name: "Inquiry",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_AspNetUsers_CustomersId",
                table: "CartItems",
                column: "CustomersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductsId",
                table: "CartItems",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_AspNetUsers_CustomersId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductsId",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Inquiry",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ProductsId",
                table: "Carts",
                newName: "IX_Carts_ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CustomersId",
                table: "Carts",
                newName: "IX_Carts_CustomersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_CustomersId",
                table: "Carts",
                column: "CustomersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Products_ProductsId",
                table: "Carts",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
