using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StreamOutfitRandomizer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamOutfitRandomizer.Contexts
{
    public class CategoryContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlite(@"Data Source=categories.db");
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSeeding((context, _) =>
                {
                    if (!context.Set<Category>().Any())
                    {
                        context.Set<Category>().AddRange(SeedCategories());
                        context.SaveChanges();
                    }
                })
                .UseAsyncSeeding(async (context, _, cancellationToken) =>
                {
                    if (!context.Set<Category>().Any())
                    {
                        context.Set<Category>().AddRange(SeedCategories());
                        await context.SaveChangesAsync(cancellationToken);
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            
        }

        private Category[] SeedCategories()
        {
            Random random = new Random();
            return
            [
                new Category
                {
                    Name = "Outfits",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Hair",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Dresses",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Outerwear",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Tops",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Bottoms",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Socks",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Shoes",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Hair Accessories",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Headwear",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Earrings",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Neckwear",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Bracelets",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Chokers",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Gloves",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Face Decorations",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Chest Accessories",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Pendants",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Backpieces",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Rings",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Arm Decorations",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Handlhelds",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Eureka Head",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Eureka Hands",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
                new Category
                {
                    Name = "Eureka Feet",
                    NumberOfItems = 50,
                    RandomChoice = random.Next(50)
                },
            ];
        }
    }
}
