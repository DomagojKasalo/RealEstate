using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace persistance.Migrations
{
    /// <inheritdoc />
    public partial class FileUpload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImage",
                schema: "realestate",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "BackgroundImageURL",
                schema: "realestate",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "ListCatalogImageId",
                schema: "realestate",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "TitleImage",
                schema: "realestate",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "TitleImageId",
                schema: "realestate",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "TitleImageURL",
                schema: "realestate",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "UnitInsideTag",
                schema: "realestate",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "UnitOutsideTag",
                schema: "realestate",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "BundleUrlAndroid",
                schema: "realestate",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "BundleUrlIos",
                schema: "realestate",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "BundleUrlOsx",
                schema: "realestate",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "BundleUrlWebGl",
                schema: "realestate",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "BundleUrlWindows",
                schema: "realestate",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "CardImageURL",
                schema: "realestate",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "DaySceneName",
                schema: "realestate",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "DetailImageId",
                schema: "realestate",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "ListImageId",
                schema: "realestate",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "ModelImage",
                schema: "realestate",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "ModelImageUrl",
                schema: "realestate",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "NightSceneName",
                schema: "realestate",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "TitleImage",
                schema: "realestate",
                table: "CatalogItems");

            migrationBuilder.DropColumn(
                name: "UnitIndex",
                schema: "realestate",
                table: "CatalogItems");

            migrationBuilder.RenameColumn(
                name: "UnitTag",
                schema: "realestate",
                table: "CatalogItems",
                newName: "ImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                schema: "realestate",
                table: "CatalogItems",
                newName: "UnitTag");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundImage",
                schema: "realestate",
                table: "Catalogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BackgroundImageURL",
                schema: "realestate",
                table: "Catalogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListCatalogImageId",
                schema: "realestate",
                table: "Catalogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleImage",
                schema: "realestate",
                table: "Catalogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TitleImageId",
                schema: "realestate",
                table: "Catalogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleImageURL",
                schema: "realestate",
                table: "Catalogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitInsideTag",
                schema: "realestate",
                table: "Catalogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitOutsideTag",
                schema: "realestate",
                table: "Catalogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BundleUrlAndroid",
                schema: "realestate",
                table: "CatalogItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BundleUrlIos",
                schema: "realestate",
                table: "CatalogItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BundleUrlOsx",
                schema: "realestate",
                table: "CatalogItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BundleUrlWebGl",
                schema: "realestate",
                table: "CatalogItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BundleUrlWindows",
                schema: "realestate",
                table: "CatalogItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardImageURL",
                schema: "realestate",
                table: "CatalogItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DaySceneName",
                schema: "realestate",
                table: "CatalogItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DetailImageId",
                schema: "realestate",
                table: "CatalogItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListImageId",
                schema: "realestate",
                table: "CatalogItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelImage",
                schema: "realestate",
                table: "CatalogItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelImageUrl",
                schema: "realestate",
                table: "CatalogItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NightSceneName",
                schema: "realestate",
                table: "CatalogItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleImage",
                schema: "realestate",
                table: "CatalogItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitIndex",
                schema: "realestate",
                table: "CatalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "DaySceneName", "DetailImageId", "ListImageId", "ModelImage", "ModelImageUrl", "NightSceneName", "TitleImage", "UnitIndex" },
                values: new object[] { null, null, null, null, null, "", null, null, null, null, null, null, "Image", 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "DaySceneName", "DetailImageId", "ListImageId", "ModelImage", "ModelImageUrl", "NightSceneName", "TitleImage", "UnitIndex" },
                values: new object[] { null, null, null, null, null, "", null, null, null, null, null, null, "Image", 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "DaySceneName", "DetailImageId", "ListImageId", "ModelImage", "ModelImageUrl", "NightSceneName", "TitleImage", "UnitIndex" },
                values: new object[] { null, null, null, null, null, "", null, null, null, null, null, null, "Image", 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "DaySceneName", "DetailImageId", "ListImageId", "ModelImage", "ModelImageUrl", "NightSceneName", "TitleImage", "UnitIndex" },
                values: new object[] { null, null, null, null, null, "", null, null, null, null, null, null, "Image", 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "DaySceneName", "DetailImageId", "ListImageId", "ModelImage", "ModelImageUrl", "NightSceneName", "TitleImage", "UnitIndex" },
                values: new object[] { null, null, null, null, null, "", null, null, null, null, null, null, "Image", 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "DaySceneName", "DetailImageId", "ListImageId", "ModelImage", "ModelImageUrl", "NightSceneName", "TitleImage", "UnitIndex" },
                values: new object[] { null, null, null, null, null, "", null, null, null, null, null, null, "Image", 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "DaySceneName", "DetailImageId", "ListImageId", "ModelImage", "ModelImageUrl", "NightSceneName", "TitleImage", "UnitIndex" },
                values: new object[] { null, null, null, null, null, "", null, null, null, null, null, null, "Image", 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "DaySceneName", "DetailImageId", "ListImageId", "ModelImage", "ModelImageUrl", "NightSceneName", "TitleImage", "UnitIndex" },
                values: new object[] { null, null, null, null, null, "", null, null, null, null, null, null, "Image", 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "DaySceneName", "DetailImageId", "ListImageId", "ModelImage", "ModelImageUrl", "NightSceneName", "TitleImage", "UnitIndex" },
                values: new object[] { null, null, null, null, null, "", null, null, null, null, null, null, "Image", 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "DaySceneName", "DetailImageId", "ListImageId", "ModelImage", "ModelImageUrl", "NightSceneName", "TitleImage", "UnitIndex" },
                values: new object[] { null, null, null, null, null, "", null, null, null, null, null, null, "Image", 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "DaySceneName", "DetailImageId", "ListImageId", "ModelImage", "ModelImageUrl", "NightSceneName", "TitleImage", "UnitIndex" },
                values: new object[] { null, null, null, null, null, "", null, null, null, null, null, null, "Image", 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "DaySceneName", "DetailImageId", "ListImageId", "ModelImage", "ModelImageUrl", "NightSceneName", "TitleImage", "UnitIndex" },
                values: new object[] { null, null, null, null, null, "", null, null, null, null, null, null, "Image", 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "DaySceneName", "DetailImageId", "ListImageId", "ModelImage", "ModelImageUrl", "NightSceneName", "TitleImage", "UnitIndex" },
                values: new object[] { null, null, null, null, null, "", null, null, null, null, null, null, "Image", 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "DaySceneName", "DetailImageId", "ListImageId", "ModelImage", "ModelImageUrl", "NightSceneName", "TitleImage", "UnitIndex" },
                values: new object[] { null, null, null, null, null, "", null, null, null, null, null, null, "Image", 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "DaySceneName", "DetailImageId", "ListImageId", "ModelImage", "ModelImageUrl", "NightSceneName", "TitleImage", "UnitIndex" },
                values: new object[] { null, null, null, null, null, "", null, null, null, null, null, null, "Image", 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "CatalogItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BundleUrlAndroid", "BundleUrlIos", "BundleUrlOsx", "BundleUrlWebGl", "BundleUrlWindows", "CardImageURL", "DaySceneName", "DetailImageId", "ListImageId", "ModelImage", "ModelImageUrl", "NightSceneName", "TitleImage", "UnitIndex" },
                values: new object[] { null, null, null, null, null, "", null, null, null, null, null, null, "Image", 0 });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "Catalogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BackgroundImage", "BackgroundImageURL", "ListCatalogImageId", "TitleImage", "TitleImageId", "TitleImageURL", "UnitInsideTag", "UnitOutsideTag" },
                values: new object[] { "This is background image", "", null, "Image123", null, "", null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "Catalogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BackgroundImage", "BackgroundImageURL", "ListCatalogImageId", "TitleImage", "TitleImageId", "TitleImageURL", "UnitInsideTag", "UnitOutsideTag" },
                values: new object[] { "This is background image", "", null, "Image123", null, "", null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "Catalogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BackgroundImage", "BackgroundImageURL", "ListCatalogImageId", "TitleImage", "TitleImageId", "TitleImageURL", "UnitInsideTag", "UnitOutsideTag" },
                values: new object[] { "This is background image", "", null, "Image123", null, "", null, null });

            migrationBuilder.UpdateData(
                schema: "realestate",
                table: "Catalogs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BackgroundImage", "BackgroundImageURL", "ListCatalogImageId", "TitleImage", "TitleImageId", "TitleImageURL", "UnitInsideTag", "UnitOutsideTag" },
                values: new object[] { "This is background image", "", null, "Image123", null, "", null, null });
        }
    }
}
