using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    ProductInStockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for Product 1", "Product1", 480m },
                    { 73, "Description for Product 73", "Product73", 475m },
                    { 72, "Description for Product 72", "Product72", 969m },
                    { 71, "Description for Product 71", "Product71", 801m },
                    { 70, "Description for Product 70", "Product70", 647m },
                    { 69, "Description for Product 69", "Product69", 992m },
                    { 68, "Description for Product 68", "Product68", 345m },
                    { 67, "Description for Product 67", "Product67", 950m },
                    { 66, "Description for Product 66", "Product66", 435m },
                    { 65, "Description for Product 65", "Product65", 611m },
                    { 64, "Description for Product 64", "Product64", 860m },
                    { 63, "Description for Product 63", "Product63", 503m },
                    { 62, "Description for Product 62", "Product62", 491m },
                    { 61, "Description for Product 61", "Product61", 271m },
                    { 60, "Description for Product 60", "Product60", 530m },
                    { 59, "Description for Product 59", "Product59", 264m },
                    { 58, "Description for Product 58", "Product58", 858m },
                    { 57, "Description for Product 57", "Product57", 848m },
                    { 56, "Description for Product 56", "Product56", 587m },
                    { 55, "Description for Product 55", "Product55", 853m },
                    { 54, "Description for Product 54", "Product54", 416m },
                    { 53, "Description for Product 53", "Product53", 286m },
                    { 74, "Description for Product 74", "Product74", 761m },
                    { 52, "Description for Product 52", "Product52", 313m },
                    { 75, "Description for Product 75", "Product75", 244m },
                    { 77, "Description for Product 77", "Product77", 907m },
                    { 98, "Description for Product 98", "Product98", 225m },
                    { 97, "Description for Product 97", "Product97", 360m },
                    { 96, "Description for Product 96", "Product96", 939m },
                    { 95, "Description for Product 95", "Product95", 792m },
                    { 94, "Description for Product 94", "Product94", 857m },
                    { 93, "Description for Product 93", "Product93", 130m },
                    { 92, "Description for Product 92", "Product92", 636m },
                    { 91, "Description for Product 91", "Product91", 227m },
                    { 90, "Description for Product 90", "Product90", 569m },
                    { 89, "Description for Product 89", "Product89", 541m },
                    { 88, "Description for Product 88", "Product88", 778m },
                    { 87, "Description for Product 87", "Product87", 638m },
                    { 86, "Description for Product 86", "Product86", 557m },
                    { 85, "Description for Product 85", "Product85", 730m },
                    { 84, "Description for Product 84", "Product84", 290m },
                    { 83, "Description for Product 83", "Product83", 911m },
                    { 82, "Description for Product 82", "Product82", 599m },
                    { 81, "Description for Product 81", "Product81", 844m },
                    { 80, "Description for Product 80", "Product80", 133m },
                    { 79, "Description for Product 79", "Product79", 596m },
                    { 78, "Description for Product 78", "Product78", 950m },
                    { 76, "Description for Product 76", "Product76", 340m },
                    { 51, "Description for Product 51", "Product51", 565m },
                    { 50, "Description for Product 50", "Product50", 160m },
                    { 49, "Description for Product 49", "Product49", 625m },
                    { 22, "Description for Product 22", "Product22", 893m },
                    { 21, "Description for Product 21", "Product21", 104m },
                    { 20, "Description for Product 20", "Product20", 575m },
                    { 19, "Description for Product 19", "Product19", 725m },
                    { 18, "Description for Product 18", "Product18", 764m },
                    { 17, "Description for Product 17", "Product17", 265m },
                    { 16, "Description for Product 16", "Product16", 295m },
                    { 15, "Description for Product 15", "Product15", 623m },
                    { 14, "Description for Product 14", "Product14", 149m },
                    { 13, "Description for Product 13", "Product13", 640m },
                    { 12, "Description for Product 12", "Product12", 145m },
                    { 11, "Description for Product 11", "Product11", 259m },
                    { 10, "Description for Product 10", "Product10", 382m },
                    { 9, "Description for Product 9", "Product9", 156m },
                    { 8, "Description for Product 8", "Product8", 754m },
                    { 7, "Description for Product 7", "Product7", 929m },
                    { 6, "Description for Product 6", "Product6", 876m },
                    { 5, "Description for Product 5", "Product5", 493m },
                    { 4, "Description for Product 4", "Product4", 368m },
                    { 3, "Description for Product 3", "Product3", 508m },
                    { 2, "Description for Product 2", "Product2", 351m },
                    { 23, "Description for Product 23", "Product23", 503m },
                    { 24, "Description for Product 24", "Product24", 650m },
                    { 25, "Description for Product 25", "Product25", 203m },
                    { 26, "Description for Product 26", "Product26", 962m },
                    { 48, "Description for Product 48", "Product48", 205m },
                    { 47, "Description for Product 47", "Product47", 218m },
                    { 46, "Description for Product 46", "Product46", 170m },
                    { 45, "Description for Product 45", "Product45", 153m },
                    { 44, "Description for Product 44", "Product44", 552m },
                    { 43, "Description for Product 43", "Product43", 986m },
                    { 42, "Description for Product 42", "Product42", 764m },
                    { 41, "Description for Product 41", "Product41", 431m },
                    { 40, "Description for Product 40", "Product40", 963m },
                    { 39, "Description for Product 39", "Product39", 388m },
                    { 99, "Description for Product 99", "Product99", 941m },
                    { 38, "Description for Product 38", "Product38", 295m },
                    { 36, "Description for Product 36", "Product36", 975m },
                    { 35, "Description for Product 35", "Product35", 156m },
                    { 34, "Description for Product 34", "Product34", 395m },
                    { 33, "Description for Product 33", "Product33", 194m },
                    { 32, "Description for Product 32", "Product32", 824m },
                    { 31, "Description for Product 31", "Product31", 770m },
                    { 30, "Description for Product 30", "Product30", 295m },
                    { 29, "Description for Product 29", "Product29", 351m },
                    { 28, "Description for Product 28", "Product28", 537m },
                    { 27, "Description for Product 27", "Product27", 705m },
                    { 37, "Description for Product 37", "Product37", 494m },
                    { 100, "Description for Product 100", "Product100", 718m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 12 },
                    { 73, 73, 1 },
                    { 72, 72, 13 },
                    { 71, 71, 16 },
                    { 70, 70, 13 },
                    { 69, 69, 11 },
                    { 68, 68, 13 },
                    { 67, 67, 3 },
                    { 66, 66, 15 },
                    { 65, 65, 4 },
                    { 64, 64, 2 },
                    { 63, 63, 16 },
                    { 62, 62, 15 },
                    { 61, 61, 18 },
                    { 60, 60, 11 },
                    { 59, 59, 15 },
                    { 58, 58, 7 },
                    { 57, 57, 11 },
                    { 56, 56, 14 },
                    { 55, 55, 13 },
                    { 54, 54, 18 },
                    { 53, 53, 15 },
                    { 74, 74, 8 },
                    { 52, 52, 3 },
                    { 75, 75, 10 },
                    { 77, 77, 16 },
                    { 98, 98, 18 },
                    { 97, 97, 4 },
                    { 96, 96, 8 },
                    { 95, 95, 15 },
                    { 94, 94, 10 },
                    { 93, 93, 1 },
                    { 92, 92, 2 },
                    { 91, 91, 12 },
                    { 90, 90, 5 },
                    { 89, 89, 14 },
                    { 88, 88, 0 },
                    { 87, 87, 14 },
                    { 86, 86, 9 },
                    { 85, 85, 4 },
                    { 84, 84, 8 },
                    { 83, 83, 10 },
                    { 82, 82, 4 },
                    { 81, 81, 13 },
                    { 80, 80, 13 },
                    { 79, 79, 3 },
                    { 78, 78, 15 },
                    { 76, 76, 13 },
                    { 51, 51, 7 },
                    { 50, 50, 18 },
                    { 49, 49, 4 },
                    { 22, 22, 17 },
                    { 21, 21, 14 },
                    { 20, 20, 14 },
                    { 19, 19, 2 },
                    { 18, 18, 3 },
                    { 17, 17, 10 },
                    { 16, 16, 6 },
                    { 15, 15, 18 },
                    { 14, 14, 11 },
                    { 13, 13, 1 },
                    { 12, 12, 3 },
                    { 11, 11, 5 },
                    { 10, 10, 17 },
                    { 9, 9, 14 },
                    { 8, 8, 4 },
                    { 7, 7, 9 },
                    { 6, 6, 10 },
                    { 5, 5, 3 },
                    { 4, 4, 19 },
                    { 3, 3, 3 },
                    { 2, 2, 14 },
                    { 23, 23, 2 },
                    { 24, 24, 15 },
                    { 25, 25, 3 },
                    { 26, 26, 12 },
                    { 48, 48, 7 },
                    { 47, 47, 18 },
                    { 46, 46, 10 },
                    { 45, 45, 12 },
                    { 44, 44, 7 },
                    { 43, 43, 1 },
                    { 42, 42, 1 },
                    { 41, 41, 3 },
                    { 40, 40, 14 },
                    { 39, 39, 1 },
                    { 99, 99, 3 },
                    { 38, 38, 16 },
                    { 36, 36, 4 },
                    { 35, 35, 19 },
                    { 34, 34, 7 },
                    { 33, 33, 19 },
                    { 32, 32, 9 },
                    { 31, 31, 13 },
                    { 30, 30, 11 },
                    { 29, 29, 7 },
                    { 28, 28, 14 },
                    { 27, 27, 11 },
                    { 37, 37, 9 },
                    { 100, 100, 17 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                schema: "Catalog",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
