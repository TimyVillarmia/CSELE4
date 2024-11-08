using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSELE4_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class ProductFKCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Product",
                newName: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Product",
                newName: "Category");
        }
    }
}
