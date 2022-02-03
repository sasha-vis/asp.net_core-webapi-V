using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATABASE.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsOrders", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ProductsOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pizzas" },
                    { 2, "Burgers" },
                    { 3, "Drinks" },
                    { 4, "Snacks" },
                    { 5, "Sauces" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Belarus" },
                    { 2, "Russia" },
                    { 3, "USA" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Minsk" },
                    { 2, 1, "Brest" },
                    { 3, 1, "Gomel" },
                    { 4, 2, "Moscow" },
                    { 5, 2, "Saint Petersburg" },
                    { 6, 2, "Novosibirsk" },
                    { 7, 3, "New York" },
                    { 8, 3, "Los Angeles" },
                    { 9, 3, "Chicago" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Description of California Pizza", "California Pizza", 20 },
                    { 2, 1, "Description of Greek Pizza", "Greek Pizza", 20 },
                    { 3, 1, "Description of Sicilian Pizza", "Sicilian Pizza", 20 },
                    { 4, 2, "Description of Hamburger", "Hamburger", 10 },
                    { 5, 2, "Description of Cheeseburger", "Cheeseburger", 10 },
                    { 6, 3, "Description of Coca cola", "Coca cola", 5 },
                    { 7, 3, "Description of Fanta", "Fanta", 5 },
                    { 8, 3, "Description of Sprite", "Sprite", 5 },
                    { 9, 4, "Description of Fries", "Fries", 7 },
                    { 10, 4, "Description of Sushi", "Sushi", 7 },
                    { 11, 5, "Description of Ketchup", "Ketchup", 3 },
                    { 12, 5, "Description of Soy sauce", "Soy sauce", 3 },
                    { 13, 5, "Description of Tartar sauce", "Tartar sauce", 3 },
                    { 14, 5, "Description of Taco sauce", "Taco sauce", 3 },
                    { 15, 5, "Description of Barbecue sauce", "Barbecue sauce", 3 },
                    { 16, 5, "Description of Cheese sauce", "Cheese sauce", 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "CityId", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, 23, 1, "Aleksandr", "Vysotski" },
                    { 2, 22, 1, "Pavel", "Motuz" },
                    { 3, 22, 1, "Artemiy", "Kasabuka" },
                    { 4, 33, 2, "Ivan", "Ivanov" },
                    { 5, 29, 3, "Nikolai", "Krasko" },
                    { 6, 40, 4, "Maksim", "Galkin" },
                    { 7, 58, 4, "Alla", "Pugacheva" },
                    { 8, 9, 5, "Egor", "Zhelobanov" },
                    { 9, 78, 6, "Nikita", "Milyavskiy" },
                    { 10, 18, 7, "Tom", "Kruz" },
                    { 11, 28, 7, "Leonardo", "Dicaprio" },
                    { 12, 41, 8, "Dwayne", "Jonson" },
                    { 13, 38, 8, "Henry", "Cavill" },
                    { 14, 46, 8, "Brad", "Pitt" },
                    { 15, 49, 9, "Will", "Smith" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "UserId" },
                values: new object[,]
                {
                    { 1, "03.02.2022 16:28", 5 },
                    { 2, "03.02.2022 16:28", 1 },
                    { 3, "03.02.2022 16:28", 14 },
                    { 4, "03.02.2022 16:28", 9 },
                    { 5, "03.02.2022 16:28", 6 },
                    { 6, "03.02.2022 16:28", 15 }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Model", "Number", "UserId" },
                values: new object[,]
                {
                    { 1, "Xiaomi", "375293776020", 1 },
                    { 2, "Iphone", "375296332394", 2 },
                    { 3, "Iphone", "375297764345", 3 },
                    { 4, "Nokia", "375297463543", 4 },
                    { 5, "Iphone", "375256787534", 5 },
                    { 6, "Iphone", "802545346", 6 },
                    { 7, "Iphone", "802565756", 7 },
                    { 8, "Samsung", "802525645", 8 },
                    { 9, "Nokia", "802542354", 9 },
                    { 10, "Iphone", "125453434", 10 },
                    { 11, "Iphone", "123468675", 11 },
                    { 12, "Iphone", "123423444", 12 },
                    { 13, "Iphone", "123454622", 13 },
                    { 14, "Iphone", "123457783", 14 },
                    { 15, "Iphone", "123443453", 15 }
                });

            migrationBuilder.InsertData(
                table: "ProductsOrders",
                columns: new[] { "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 5, 5 },
                    { 1, 6 },
                    { 4, 8 },
                    { 3, 10 },
                    { 6, 14 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_UserId",
                table: "Phones",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsOrders_OrderId",
                table: "ProductsOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "ProductsOrders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
