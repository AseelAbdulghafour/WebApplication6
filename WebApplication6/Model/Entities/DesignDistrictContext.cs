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


        public DbSet<Post> Posts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().HasIndex(r => r.Email).IsUnique();
            modelBuilder.Entity<UserAccount>().HasIndex(r => r.PhoneNumber).IsUnique();


        }
    }
    
}