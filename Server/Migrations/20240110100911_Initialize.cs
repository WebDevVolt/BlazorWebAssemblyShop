using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameShop.Server.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.UserId, x.ProductId });
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[] { 1, "Playstation", "ps-games" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[] { 2, "xbox", "xbox-games" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[] { 3, "PC", "pc-games" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price", "SalePrice", "Title" },
                values: new object[,]
                {
                    { 1, 1, "God of War Ragnarök is an action-adventure game developed by Santa Monica Studio \r\n                                and published by Sony Interactive Entertainment. Loosely based on Norse mythology, \r\n                                the game is set in ancient Scandinavia and features series protagonist, \r\n                                Kratos, and his now teenage son, Atreus. Concluding the Norse era of the series, the game covers \r\n                                Ragnarök, the eschatological event which is central to Norse mythology and was foretold to \r\n                                happen in the previous game after Kratos killed the Aesir god Baldur.", "https://upload.wikimedia.org/wikipedia/en/e/ee/God_of_War_Ragnar%C3%B6k_cover.jpg", 69.99m, 49.99m, "God of War Ragnarök (Playstation)" },
                    { 2, 1, "Peter Parker and Miles Morales struggle to navigate the next steps in their personal \r\n                                        lives while combating several new threats, including a private militia led by Kraven the Hunter, who transforms \r\n                                        New York City into a hunting ground for super-powered individuals; and the extraterrestrial Venom symbiote, \r\n                                        which bonds itself to Parker and negatively influences him, threatening \r\n                                        to destroy his personal relationships.", "https://upload.wikimedia.org/wikipedia/en/0/0f/SpiderMan2PS5BoxArt.jpeg", 69.99m, 69.99m, "Spider-Man 2 (Playstation)" },
                    { 3, 1, "Resident Evil 4 is a 2023 survival horror game developed and published by Capcom. \r\n                                        A remake of the 2005 game Resident Evil 4, it was released for PlayStation 4, PlayStation 5, \r\n                                        Windows, and Xbox Series X/S on March 24, 2023. Versions for iOS,[b] iPadOS, \r\n                                        and macOS were released on December 20, 2023.", "https://upload.wikimedia.org/wikipedia/en/d/df/Resident_Evil_4_remake_cover_art.jpg", 79.99m, 59.99m, "Resident Evil 4 Remake (Playstation)" },
                    { 4, 1, "God of War Ragnarök is an action-adventure game developed by Santa Monica Studio \r\n                                and published by Sony Interactive Entertainment. Loosely based on Norse mythology, \r\n                                the game is set in ancient Scandinavia and features series protagonist, \r\n                                Kratos, and his now teenage son, Atreus. Concluding the Norse era of the series, the game covers \r\n                                Ragnarök, the eschatological event which is central to Norse mythology and was foretold to \r\n                                happen in the previous game after Kratos killed the Aesir god Baldur.", "https://upload.wikimedia.org/wikipedia/en/b/b6/Ghost_of_Tsushima.jpg", 69.99m, 39.99m, "Ghost of Tsushima (Playstation)" },
                    { 5, 1, "EA Sports FC 24 is an association football-themed simulation video game developed \r\n                                        by EA Vancouver and EA Romania and published by EA Sports. It is the inaugural installment in the EA \r\n                                        Sports FC series following on from the successful FIFA video game series after Electronic Arts's partnership \r\n                                        with FIFA concluded with FIFA 23.", "https://upload.wikimedia.org/wikipedia/en/thumb/b/b3/EA_FC24_Cover.jpg/270px-EA_FC24_Cover.jpg", 59.99m, 59.99m, "EA Sports FC 24 (Playstation)" },
                    { 6, 1, "The game is set in post-apocalyptic Oregon two years after the start of a pandemic that \r\n                                        turned a portion of humanity into vicious zombie-like creatures. \r\n                                        Former outlaw-turned-drifter Deacon St.", "https://upload.wikimedia.org/wikipedia/en/1/16/Days_Gone_cover_art.jpg", 79.99m, 29.99m, "Days Gone (Playstation)" },
                    { 7, 2, "EA Sports FC 24[1] is an association football-themed simulation video game developed \r\n                                        by EA Vancouver and EA Romania and published by EA Sports. It is the inaugural installment in the EA \r\n                                        Sports FC series following on from the successful FIFA video game series after Electronic Arts's partnership \r\n                                        with FIFA concluded with FIFA 23.", "https://upload.wikimedia.org/wikipedia/en/thumb/b/b3/EA_FC24_Cover.jpg/270px-EA_FC24_Cover.jpg", 59.99m, 59.99m, "EA Sports FC 24 (xbox)" },
                    { 8, 2, "Forza Motorsport 7 is a racing video game featuring over 700 cars—including new Forza \r\n                                        Edition cars, most of which have been brought over from Forza Horizon 3 and more \r\n                                        than 200 different configurations to race on across 32 locations at launch, including \r\n                                        all from Forza Motorsport 6; a fictional street circuit in Dubai is one of the new circuits and several \r\n                                        tracks returning from Forza Motorsport 4 including Maple Valley Raceway, Mugello Circuit and Suzuka Circuit..", "https://upload.wikimedia.org/wikipedia/en/2/2f/Forza_7_art.jpg", 59.99m, 29.99m, "Forza Motorsport 7 (xbox)" },
                    { 9, 2, "The game takes place in a space-themed setting, and is the first new intellectual \r\n                                        property developed by Bethesda in 25 years. \r\n                                        It was described by director Todd Howard as \"Skyrim\" in space.", "https://upload.wikimedia.org/wikipedia/en/6/6d/Bethesda_Starfield.jpg", 69.99m, 59.99m, "Starfield (xbox)" },
                    { 10, 2, "The game is set within the fictional titular island town of Redfall, Massachusetts. \r\n                                        After a failed scientific experiment, a legion of vampires occupied the isolated town and cut \r\n                                        off communication to the outside world.", "https://upload.wikimedia.org/wikipedia/en/a/ad/Redfall_cover.jpg", 19.99m, 19.99m, "Redfall (xbox)" },
                    { 11, 3, "EA Sports FC 24 is an association football-themed simulation video game developed \r\n                                        by EA Vancouver and EA Romania and published by EA Sports. It is the inaugural installment in the EA \r\n                                        Sports FC series following on from the successful FIFA video game series after Electronic Arts's partnership \r\n                                        with FIFA concluded with FIFA 23.", "https://upload.wikimedia.org/wikipedia/en/thumb/b/b3/EA_FC24_Cover.jpg/270px-EA_FC24_Cover.jpg", 59.99m, 19.99m, "EA Sports FC 24 (PC)" },
                    { 12, 3, "Sekiro: Shadows Die Twice is a 2019 action-adventure game developed by FromSoftware. \r\n                                        It was released in Japan by FromSoftware and internationally by Activision for the PlayStation 4,\r\n                                        Windows and Xbox One in March 2019 and for Stadia in October 2020.", "https://upload.wikimedia.org/wikipedia/en/6/6e/Sekiro_art.jpg", 69.99m, 49.99m, "Sekiro: Shadows Die Twice (PC)" },
                    { 13, 3, "Sifu is a run based action beat 'em up game played from a third-person perspective. \r\n                                        The game, which is inspired by Bak Mei kung fu, includes over 150 unique attacks.", "https://upload.wikimedia.org/wikipedia/en/e/e3/Sifu_cover_art.jpg", 69.99m, 49.99m, "Sifu (PC)" },
                    { 14, 3, "You must survive being stranded on one of several maps filled with roaming dinosaurs, \r\n                                        fictional fantasy monsters, and other prehistoric animals, natural hazards, \r\n                                        and potentially hostile human players.", "https://upload.wikimedia.org/wikipedia/en/2/2b/ArkSurvivalEvolved.png", 69.99m, 19.99m, "Ark: Survival Evolved (Playstation)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
