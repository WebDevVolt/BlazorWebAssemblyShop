﻿// <auto-generated />
using System;
using GameShop.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameShop.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240115094842_Orders")]
    partial class Orders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GameShop.Shared.CartItem", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("GameShop.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Playstation",
                            Url = "ps-games"
                        },
                        new
                        {
                            Id = 2,
                            Name = "xbox",
                            Url = "xbox-games"
                        },
                        new
                        {
                            Id = 3,
                            Name = "PC",
                            Url = "pc-games"
                        });
                });

            modelBuilder.Entity("GameShop.Shared.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("USerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GameShop.Shared.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("GameShop.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "God of War Ragnarök is an action-adventure game developed by Santa Monica Studio \r\n                                and published by Sony Interactive Entertainment. Loosely based on Norse mythology, \r\n                                the game is set in ancient Scandinavia and features series protagonist, \r\n                                Kratos, and his now teenage son, Atreus. Concluding the Norse era of the series, the game covers \r\n                                Ragnarök, the eschatological event which is central to Norse mythology and was foretold to \r\n                                happen in the previous game after Kratos killed the Aesir god Baldur.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/ee/God_of_War_Ragnar%C3%B6k_cover.jpg",
                            Price = 69.99m,
                            SalePrice = 49.99m,
                            Title = "God of War Ragnarök (Playstation)"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Peter Parker and Miles Morales struggle to navigate the next steps in their personal \r\n                                        lives while combating several new threats, including a private militia led by Kraven the Hunter, who transforms \r\n                                        New York City into a hunting ground for super-powered individuals; and the extraterrestrial Venom symbiote, \r\n                                        which bonds itself to Parker and negatively influences him, threatening \r\n                                        to destroy his personal relationships.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0f/SpiderMan2PS5BoxArt.jpeg",
                            Price = 69.99m,
                            SalePrice = 69.99m,
                            Title = "Spider-Man 2 (Playstation)"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Resident Evil 4 is a 2023 survival horror game developed and published by Capcom. \r\n                                        A remake of the 2005 game Resident Evil 4, it was released for PlayStation 4, PlayStation 5, \r\n                                        Windows, and Xbox Series X/S on March 24, 2023. Versions for iOS,[b] iPadOS, \r\n                                        and macOS were released on December 20, 2023.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/df/Resident_Evil_4_remake_cover_art.jpg",
                            Price = 79.99m,
                            SalePrice = 59.99m,
                            Title = "Resident Evil 4 Remake (Playstation)"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "God of War Ragnarök is an action-adventure game developed by Santa Monica Studio \r\n                                and published by Sony Interactive Entertainment. Loosely based on Norse mythology, \r\n                                the game is set in ancient Scandinavia and features series protagonist, \r\n                                Kratos, and his now teenage son, Atreus. Concluding the Norse era of the series, the game covers \r\n                                Ragnarök, the eschatological event which is central to Norse mythology and was foretold to \r\n                                happen in the previous game after Kratos killed the Aesir god Baldur.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b6/Ghost_of_Tsushima.jpg",
                            Price = 69.99m,
                            SalePrice = 39.99m,
                            Title = "Ghost of Tsushima (Playstation)"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "EA Sports FC 24 is an association football-themed simulation video game developed \r\n                                        by EA Vancouver and EA Romania and published by EA Sports. It is the inaugural installment in the EA \r\n                                        Sports FC series following on from the successful FIFA video game series after Electronic Arts's partnership \r\n                                        with FIFA concluded with FIFA 23.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/b/b3/EA_FC24_Cover.jpg/270px-EA_FC24_Cover.jpg",
                            Price = 59.99m,
                            SalePrice = 59.99m,
                            Title = "EA Sports FC 24 (Playstation)"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Description = "The game is set in post-apocalyptic Oregon two years after the start of a pandemic that \r\n                                        turned a portion of humanity into vicious zombie-like creatures. \r\n                                        Former outlaw-turned-drifter Deacon St.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/16/Days_Gone_cover_art.jpg",
                            Price = 79.99m,
                            SalePrice = 29.99m,
                            Title = "Days Gone (Playstation)"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Description = "EA Sports FC 24[1] is an association football-themed simulation video game developed \r\n                                        by EA Vancouver and EA Romania and published by EA Sports. It is the inaugural installment in the EA \r\n                                        Sports FC series following on from the successful FIFA video game series after Electronic Arts's partnership \r\n                                        with FIFA concluded with FIFA 23.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/b/b3/EA_FC24_Cover.jpg/270px-EA_FC24_Cover.jpg",
                            Price = 59.99m,
                            SalePrice = 59.99m,
                            Title = "EA Sports FC 24 (xbox)"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Description = "Forza Motorsport 7 is a racing video game featuring over 700 cars—including new Forza \r\n                                        Edition cars, most of which have been brought over from Forza Horizon 3 and more \r\n                                        than 200 different configurations to race on across 32 locations at launch, including \r\n                                        all from Forza Motorsport 6; a fictional street circuit in Dubai is one of the new circuits and several \r\n                                        tracks returning from Forza Motorsport 4 including Maple Valley Raceway, Mugello Circuit and Suzuka Circuit..",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/2f/Forza_7_art.jpg",
                            Price = 59.99m,
                            SalePrice = 29.99m,
                            Title = "Forza Motorsport 7 (xbox)"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            Description = "The game takes place in a space-themed setting, and is the first new intellectual \r\n                                        property developed by Bethesda in 25 years. \r\n                                        It was described by director Todd Howard as \"Skyrim\" in space.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/6d/Bethesda_Starfield.jpg",
                            Price = 69.99m,
                            SalePrice = 59.99m,
                            Title = "Starfield (xbox)"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            Description = "The game is set within the fictional titular island town of Redfall, Massachusetts. \r\n                                        After a failed scientific experiment, a legion of vampires occupied the isolated town and cut \r\n                                        off communication to the outside world.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/ad/Redfall_cover.jpg",
                            Price = 19.99m,
                            SalePrice = 19.99m,
                            Title = "Redfall (xbox)"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            Description = "EA Sports FC 24 is an association football-themed simulation video game developed \r\n                                        by EA Vancouver and EA Romania and published by EA Sports. It is the inaugural installment in the EA \r\n                                        Sports FC series following on from the successful FIFA video game series after Electronic Arts's partnership \r\n                                        with FIFA concluded with FIFA 23.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/b/b3/EA_FC24_Cover.jpg/270px-EA_FC24_Cover.jpg",
                            Price = 59.99m,
                            SalePrice = 19.99m,
                            Title = "EA Sports FC 24 (PC)"
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            Description = "Sekiro: Shadows Die Twice is a 2019 action-adventure game developed by FromSoftware. \r\n                                        It was released in Japan by FromSoftware and internationally by Activision for the PlayStation 4,\r\n                                        Windows and Xbox One in March 2019 and for Stadia in October 2020.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/6e/Sekiro_art.jpg",
                            Price = 69.99m,
                            SalePrice = 49.99m,
                            Title = "Sekiro: Shadows Die Twice (PC)"
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 3,
                            Description = "Sifu is a run based action beat 'em up game played from a third-person perspective. \r\n                                        The game, which is inspired by Bak Mei kung fu, includes over 150 unique attacks.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e3/Sifu_cover_art.jpg",
                            Price = 69.99m,
                            SalePrice = 49.99m,
                            Title = "Sifu (PC)"
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 3,
                            Description = "You must survive being stranded on one of several maps filled with roaming dinosaurs, \r\n                                        fictional fantasy monsters, and other prehistoric animals, natural hazards, \r\n                                        and potentially hostile human players.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/2b/ArkSurvivalEvolved.png",
                            Price = 69.99m,
                            SalePrice = 19.99m,
                            Title = "Ark: Survival Evolved (Playstation)"
                        });
                });

            modelBuilder.Entity("GameShop.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GameShop.Shared.OrderItem", b =>
                {
                    b.HasOne("GameShop.Shared.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameShop.Shared.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GameShop.Shared.Product", b =>
                {
                    b.HasOne("GameShop.Shared.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GameShop.Shared.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
