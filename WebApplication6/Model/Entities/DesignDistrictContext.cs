using DesignDistrict.Frontend.Model;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Model;

namespace ProductApi.Models.Entites
{
    public class DesignDistrictContext : DbContext
    {
        public DesignDistrictContext(DbContextOptions<DesignDistrictContext> options) : base(options)
        {

        }
       
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<DesignPost> DesignPosts { get; set; }
        public DbSet<Category> Categories { get; set; }


        public DbSet<Style> Styles { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().HasIndex(r => r.Email).IsUnique();
            modelBuilder.Entity<UserAccount>().HasIndex(r => r.PhoneNumber).IsUnique();

            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, Name = "Living Room" }, 
                new Category { CategoryId = 2, Name = "Bedroom" }, 
                new Category { CategoryId = 3, Name = "Office" }, 
                new Category { CategoryId = 4, Name = "Bathroom" }, 
                new Category { CategoryId = 5, Name = "Outdoor" });

            modelBuilder.Entity<Style>().HasData(new Style { StyleId = 1, Name = "Modern" }, 
                new Style { StyleId = 2, Name = "Rustic" }, 
                new Style { StyleId = 3, Name = "Classic" }, 
                new Style { StyleId = 4, Name = "Cosy" });

            modelBuilder.Entity<ItemType>().HasData(new ItemType { ItemTypeId = 1, Name = "Chair" },
                new ItemType { ItemTypeId = 2, Name = "Table" },
                new ItemType { ItemTypeId = 3, Name = "Closet" },
                new ItemType { ItemTypeId = 4, Name = "Sofa/Couch" },
                new ItemType { ItemTypeId = 5, Name = "Carpet" },
                new ItemType { ItemTypeId = 6, Name = "Curtain" },
                new ItemType { ItemTypeId = 7, Name = "Cabinet" },
                new ItemType { ItemTypeId = 8, Name = "Shelves" },
                new ItemType { ItemTypeId = 9, Name = "Shoe Closet" }  

                );
        }
    }
}

        