using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlGallery.Migrations
{
    /// <inheritdoc />
    public partial class cartitems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Inquiry",
                table: "Contact",
                newName: "ProductOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductOrder",
                table: "Contact",
                newName: "Inquiry");
        }
    }
}
