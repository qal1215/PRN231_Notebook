using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SE162024.ProductManagement.Repo.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductName", "UnitPrice", "UnitsInStock" },
                values: new object[,]
                {
                    { 1, 1, "Chai", 18.00m, 0 },
                    { 2, 1, "Chang", 19.00m, 0 },
                    { 3, 2, "Aniseed Syrup", 10.00m, 0 },
                    { 4, 2, "Chef Anton's Cajun Seasoning", 22.00m, 0 },
                    { 5, 2, "Chef Anton's Gumbo Mix", 21.35m, 0 },
                    { 6, 2, "Grandma's Boysenberry Spread", 25.00m, 0 },
                    { 7, 7, "Uncle Bob's Organic Dried Pears", 30.00m, 0 },
                    { 8, 2, "Northwoods Cranberry Sauce", 40.00m, 0 },
                    { 9, 6, "Mishi Kobe Niku", 97.00m, 0 },
                    { 10, 8, "Ikura", 31.00m, 0 },
                    { 11, 4, "Queso Cabrales", 21.00m, 0 },
                    { 12, 4, "Queso Manchego La Pastora", 38.00m, 0 },
                    { 13, 8, "Konbu", 6.00m, 0 },
                    { 14, 7, "Tofu", 23.25m, 0 },
                    { 15, 2, "Genen Shouyu", 15.50m, 0 },
                    { 16, 3, "Pavlova", 17.45m, 0 },
                    { 17, 6, "Alice Mutton", 39.00m, 0 },
                    { 18, 8, "Carnarvon Tigers", 62.50m, 0 },
                    { 19, 3, "Teatime Chocolate Biscuits", 9.20m, 0 },
                    { 20, 3, "Sir Rodney's Marmalade", 81.00m, 0 },
                    { 21, 3, "Sir Rodney's Scones", 10.00m, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21);
        }
    }
}
