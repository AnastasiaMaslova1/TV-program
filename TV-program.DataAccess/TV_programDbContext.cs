using Microsoft.EntityFrameworkCore;
using TV_program.DataAccess.Entities;

namespace TV_program.DataAccess
{
    public class TV_programDbContext : DbContext
    {
        public DbSet<ActorEntity> Actor { get; set; }
        public DbSet<AdminEntity> Admin { get; set; }
        public DbSet<ChannelEntity> Channel { get; set; }
        public DbSet<GenreEntity> Genre { get; set; }
        public DbSet<ShowActorEntity> ShowActor { get; set; }
        public DbSet<ShowGenreEntity> ShowGenre { get; set; }
        public DbSet<TVShowEntity> TVShow { get; set; }
        public DbSet<UserChannelEntity> UserChannel { get; set; }
        public DbSet<UserEntity> User { get; set; }

        public TV_programDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<AdminEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<AdminEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<UserChannelEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<UserChannelEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<UserChannelEntity>().HasOne(x => x.User)
                                                    .WithMany(x => x.UserChannel)
                                                    .HasForeignKey(x => x.IdUser);
            modelBuilder.Entity<UserChannelEntity>().HasOne(x => x.Channel)
                                                    .WithMany(x => x.UserChannel)
                                                    .HasForeignKey(x => x.IdChannel);

            modelBuilder.Entity<ChannelEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ChannelEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<GenreEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<GenreEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<ActorEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ActorEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<ShowActorEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ShowActorEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<ShowActorEntity>().HasOne(x => x.TVShow)
                                                   .WithMany(x => x.ShowActor)
                                                   .HasForeignKey(x => x.IdShow);
            modelBuilder.Entity<ShowActorEntity>().HasOne(x => x.Actor)
                                                   .WithMany(x => x.ShowActor)
                                                   .HasForeignKey(x => x.IdActor);

            modelBuilder.Entity<ShowGenreEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ShowGenreEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<ShowGenreEntity>().HasOne(x => x.TVShow)
                                                   .WithMany(x => x.ShowGenre)
                                                   .HasForeignKey(x => x.IdShow);
            modelBuilder.Entity<ShowGenreEntity>().HasOne(x => x.Genre)
                                                   .WithMany(x => x.ShowGenre)
                                                   .HasForeignKey(x => x.IdGenre);

            modelBuilder.Entity<TVShowEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<TVShowEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<TVShowEntity>().HasOne(x => x.Channel)
                                                .WithMany(x => x.TVShow)
                                                .HasForeignKey(x => x.IdChannel);
        }
    }
}

