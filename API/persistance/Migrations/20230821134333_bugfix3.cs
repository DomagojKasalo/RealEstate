using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace persistance.Migrations
{
    /// <inheritdoc />
    public partial class bugfix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Units",
                schema: "realestate",
                table: "CatalogItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Rooms",
                schema: "realestate",
                table: "CatalogItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "NetArea",
                schema: "realestate",
                table: "CatalogItems",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<bool>(
                name: "IsFeatured",
                schema: "realestate",
                table: "CatalogItems",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsEnabled",
                schema: "realestate",
                table: "CatalogItems",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDisclamer",
                schema: "realestate",
                table: "CatalogItems",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "GaragePlaces",
                schema: "realestate",
                table: "CatalogItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "Floors",
                schema: "realestate",
                table: "CatalogItems",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "Floor",
                schema: "realestate",
                table: "CatalogItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "BruttoArea",
                schema: "realestate",
                table: "CatalogItems",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "Bathrooms",
                schema: "realestate",
                table: "CatalogItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Units",
                schema: "realestate",
                table: "CatalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Rooms",
                schema: "realestate",
                table: "CatalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "NetArea",
                schema: "realestate",
                table: "CatalogItems",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsFeatured",
                schema: "realestate",
                table: "CatalogItems",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsEnabled",
                schema: "realestate",
                table: "CatalogItems",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDisclamer",
                schema: "realestate",
                table: "CatalogItems",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GaragePlaces",
                schema: "realestate",
                table: "CatalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Floors",
                schema: "realestate",
                table: "CatalogItems",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Floor",
                schema: "realestate",
                table: "CatalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "BruttoArea",
                schema: "realestate",
                table: "CatalogItems",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Bathrooms",
                schema: "realestate",
                table: "CatalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { 0, 0f, 0, 0f, 0, false, false, false, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { 0, 0f, 0, 0f, 0, false, false, false, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { 0, 0f, 0, 0f, 0, false, false, false, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { 0, 0f, 0, 0f, 0, false, false, false, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { 0, 0f, 0, 0f, 0, false, false, false, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { 0, 0f, 0, 0f, 0, false, false, false, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { 0, 0f, 0, 0f, 0, false, false, false, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { 0, 0f, 0, 0f, 0, false, false, false, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { 0, 0f, 0, 0f, 0, false, false, false, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { 0, 0f, 0, 0f, 0, false, false, false, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { 0, 0f, 0, 0f, 0, false, false, false, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { 0, 0f, 0, 0f, 0, false, false, false, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { 0, 0f, 0, 0f, 0, false, false, false, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { 0, 0f, 0, 0f, 0, false, false, false, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { 0, 0f, 0, 0f, 0, false, false, false, 0f, 0, 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Bathrooms", "BruttoArea", "Floor", "Floors", "GaragePlaces", "IsDisclamer", "IsEnabled", "IsFeatured", "NetArea", "Rooms", "Units" },
                values: new object[] { 0, 0f, 0, 0f, 0, false, false, false, 0f, 0, 0 });
        }
    }
}
