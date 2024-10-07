using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSELE4_Activity.Migrations
{
    /// <inheritdoc />
    public partial class AddProductContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImageFile",
                table: "Product");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "Product",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "ProductImageFile",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
