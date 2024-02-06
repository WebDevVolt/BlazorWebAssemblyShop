namespace GameShop.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .HasKey(ci => new { ci.UserId, ci.ProductId });

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId });

            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Title = "God of War Ragnarök (Playstation)",
                        Description = @"God of War Ragnarök is an action-adventure game developed by Santa Monica Studio 
                                and published by Sony Interactive Entertainment. Loosely based on Norse mythology, 
                                the game is set in ancient Scandinavia and features series protagonist, 
                                Kratos, and his now teenage son, Atreus. Concluding the Norse era of the series, the game covers 
                                Ragnarök, the eschatological event which is central to Norse mythology and was foretold to 
                                happen in the previous game after Kratos killed the Aesir god Baldur.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/ee/God_of_War_Ragnar%C3%B6k_cover.jpg",
                        CategoryId = 1,
                        Price = 69.99m,
                        SalePrice = 49.99m,
                    },
                    new Product
                    {
                        Id = 2,
                        Title = "Spider-Man 2 (Playstation)",
                        Description = @"Peter Parker and Miles Morales struggle to navigate the next steps in their personal 
                                        lives while combating several new threats, including a private militia led by Kraven the Hunter, who transforms 
                                        New York City into a hunting ground for super-powered individuals; and the extraterrestrial Venom symbiote, 
                                        which bonds itself to Parker and negatively influences him, threatening 
                                        to destroy his personal relationships.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0f/SpiderMan2PS5BoxArt.jpeg",
                        CategoryId = 1,
                        Price = 69.99m,
                        SalePrice = 69.99m,
                    },
                    new Product
                    {
                        Id = 3,
                        Title = "Resident Evil 4 Remake (Playstation)",
                        Description = @"Resident Evil 4 is a 2023 survival horror game developed and published by Capcom. 
                                        A remake of the 2005 game Resident Evil 4, it was released for PlayStation 4, PlayStation 5, 
                                        Windows, and Xbox Series X/S on March 24, 2023. Versions for iOS,[b] iPadOS, 
                                        and macOS were released on December 20, 2023.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/df/Resident_Evil_4_remake_cover_art.jpg",
                        CategoryId = 1,
                        Price = 79.99m,
                        SalePrice = 59.99m,
                    },

                    new Product
                    {
                        Id = 4,
                        Title = "Ghost of Tsushima (Playstation)",
                        Description = @"God of War Ragnarök is an action-adventure game developed by Santa Monica Studio 
                                and published by Sony Interactive Entertainment. Loosely based on Norse mythology, 
                                the game is set in ancient Scandinavia and features series protagonist, 
                                Kratos, and his now teenage son, Atreus. Concluding the Norse era of the series, the game covers 
                                Ragnarök, the eschatological event which is central to Norse mythology and was foretold to 
                                happen in the previous game after Kratos killed the Aesir god Baldur.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b6/Ghost_of_Tsushima.jpg",
                        CategoryId = 1,
                        Price = 69.99m,
                        SalePrice = 39.99m,
                    },
                    new Product
                    {
                        Id = 5,
                        Title = "EA Sports FC 24 (Playstation)",
                        Description = @"EA Sports FC 24 is an association football-themed simulation video game developed 
                                        by EA Vancouver and EA Romania and published by EA Sports. It is the inaugural installment in the EA 
                                        Sports FC series following on from the successful FIFA video game series after Electronic Arts's partnership 
                                        with FIFA concluded with FIFA 23.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/b/b3/EA_FC24_Cover.jpg/270px-EA_FC24_Cover.jpg",
                        CategoryId = 1,
                        Price = 59.99m,
                        SalePrice = 59.99m
                    },
                    new Product
                    {
                        Id = 6,
                        Title = "Days Gone (Playstation)",
                        Description = @"The game is set in post-apocalyptic Oregon two years after the start of a pandemic that 
                                        turned a portion of humanity into vicious zombie-like creatures. 
                                        Former outlaw-turned-drifter Deacon St.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/16/Days_Gone_cover_art.jpg",
                        CategoryId = 1,
                        Price = 79.99m,
                        SalePrice = 29.99m,
                    },
                    new Product
                    {
                        Id = 7,
                        Title = "EA Sports FC 24 (xbox)",
                        Description = @"EA Sports FC 24[1] is an association football-themed simulation video game developed 
                                        by EA Vancouver and EA Romania and published by EA Sports. It is the inaugural installment in the EA 
                                        Sports FC series following on from the successful FIFA video game series after Electronic Arts's partnership 
                                        with FIFA concluded with FIFA 23.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/b/b3/EA_FC24_Cover.jpg/270px-EA_FC24_Cover.jpg",
                        CategoryId = 2,
                        Price = 59.99m,
                        SalePrice = 59.99m
                    },
                    new Product
                    {
                        Id = 8,
                        Title = "Forza Motorsport 7 (xbox)",
                        Description = @"Forza Motorsport 7 is a racing video game featuring over 700 cars—including new Forza 
                                        Edition cars, most of which have been brought over from Forza Horizon 3 and more 
                                        than 200 different configurations to race on across 32 locations at launch, including 
                                        all from Forza Motorsport 6; a fictional street circuit in Dubai is one of the new circuits and several 
                                        tracks returning from Forza Motorsport 4 including Maple Valley Raceway, Mugello Circuit and Suzuka Circuit..",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/2f/Forza_7_art.jpg",
                        CategoryId = 2,
                        Price = 59.99m,
                        SalePrice = 29.99m
                    },
                    new Product
                    {
                        Id = 9,
                        Title = "Starfield (xbox)",
                        Description = @"The game takes place in a space-themed setting, and is the first new intellectual 
                                        property developed by Bethesda in 25 years. 
                                        It was described by director Todd Howard as ""Skyrim"" in space.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/6d/Bethesda_Starfield.jpg",
                        CategoryId = 2,
                        Price = 69.99m,
                        SalePrice = 59.99m,
                    },
                    new Product
                    {
                        Id = 10,
                        Title = "Redfall (xbox)",
                        Description = @"The game is set within the fictional titular island town of Redfall, Massachusetts. 
                                        After a failed scientific experiment, a legion of vampires occupied the isolated town and cut 
                                        off communication to the outside world.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/ad/Redfall_cover.jpg",
                        CategoryId = 2,
                        Price = 19.99m,
                        SalePrice = 19.99m
                    },
                    new Product
                    {
                        Id = 11,
                        Title = "EA Sports FC 24 (PC)",
                        Description = @"EA Sports FC 24 is an association football-themed simulation video game developed 
                                        by EA Vancouver and EA Romania and published by EA Sports. It is the inaugural installment in the EA 
                                        Sports FC series following on from the successful FIFA video game series after Electronic Arts's partnership 
                                        with FIFA concluded with FIFA 23.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/b/b3/EA_FC24_Cover.jpg/270px-EA_FC24_Cover.jpg",
                        CategoryId = 3,
                        Price = 59.99m,
                        SalePrice = 19.99m
                    },
                    new Product
                    {
                        Id = 12,
                        Title = "Sekiro: Shadows Die Twice (PC)",
                        Description = @"Sekiro: Shadows Die Twice is a 2019 action-adventure game developed by FromSoftware. 
                                        It was released in Japan by FromSoftware and internationally by Activision for the PlayStation 4,
                                        Windows and Xbox One in March 2019 and for Stadia in October 2020.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/6e/Sekiro_art.jpg",
                        CategoryId = 3,
                        Price = 69.99m,
                        SalePrice = 49.99m
                    },
                    new Product
                    {
                        Id = 13,
                        Title = "Sifu (PC)",
                        Description = @"Sifu is a run based action beat 'em up game played from a third-person perspective. 
                                        The game, which is inspired by Bak Mei kung fu, includes over 150 unique attacks.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e3/Sifu_cover_art.jpg",
                        CategoryId = 3,
                        Price = 69.99m,
                        SalePrice = 49.99m
                    },
                    new Product
                    {
                        Id = 14,
                        Title = "Ark: Survival Evolved (Playstation)",
                        Description = @"You must survive being stranded on one of several maps filled with roaming dinosaurs, 
                                        fictional fantasy monsters, and other prehistoric animals, natural hazards, 
                                        and potentially hostile human players.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/2b/ArkSurvivalEvolved.png",
                        CategoryId = 3,
                        Price = 69.99m,
                        SalePrice = 19.99m
                    }
                );

            modelBuilder.Entity<Category>().HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Playstation",
                        Url = "ps-games"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "xbox",
                        Url = "xbox-games"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "PC",
                        Url = "pc-games"
                    }
                );
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
