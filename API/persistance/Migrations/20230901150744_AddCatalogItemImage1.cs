using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddCatalogItemImage1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                schema: "realestate",
                table: "CatalogItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                schema: "realestate",
                table: "CatalogItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImagePath",
                value: null);
        }
    }
}
