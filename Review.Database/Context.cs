using Microsoft.EntityFrameworkCore;
using Review.Database.Configs;
using Reviews.Shared;
using static Review.Database.DataInit;

namespace Review.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<ReviewModel> ReviewModels { get; set; }

        public DbSet<UToken> UTokens { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ReviewDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configs.UserConfig());
            modelBuilder.ApplyConfiguration(new Configs.ReviewConfigs());
            modelBuilder.ApplyConfiguration(new Configs.TokenConfigs());

            modelBuilder.ApplyConfiguration(new RoleDataInit());
            modelBuilder.ApplyConfiguration(new UserDataInit());
            modelBuilder.ApplyConfiguration(new ReviewDataInit());
        }
    }
}