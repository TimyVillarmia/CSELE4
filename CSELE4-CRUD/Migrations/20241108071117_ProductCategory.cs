using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSELE4_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class ProductCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryCategoryID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryCategoryID",
                table: "Product",
                column: "ProductCategoryCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_ProductCategoryCategoryID",
                table: "Product",
                column: "ProductCategoryCategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_ProductCategoryCategoryID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductCategoryCategoryID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductCategoryCategoryID",
                table: "Product");
        }
    }
}
