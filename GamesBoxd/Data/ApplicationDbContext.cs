using GamesBoxd.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamesBoxd.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
    IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
    {
        public DbSet<UserProfile> Users { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<UserGame> UserGames { get; set; } = null!;
        public DbSet<UserFriend> UserFriends { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<GameList> GameLists { get; set; } = null!;
        public DbSet<GameListGame> GameListGames { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<GamePlatform> GamePlatforms { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserFriend>(entity =>
            {
                entity.HasKey(uf => uf.Id);

                entity.HasOne(uf => uf.User)
                    .WithMany(u => u.Friends)
                    .HasForeignKey(uf => uf.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(uf => uf.Friend)
                    .WithMany()
                    .HasForeignKey(uf => uf.FriendId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
