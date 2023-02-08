using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Champions
{
    public class ChampionContext : DbContext
    {
        public ChampionContext() { }

        public ChampionContext(DbContextOptions options) : base(options) { }

        public DbSet<ChampionEntity> ChampionEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) { 
            base.OnConfiguring(options);
            options.UseSqlite($"DataSource = Console_Champion.ChampionsDB.db");
        }

        public DbSet<Champion> Champions { get; set; }
        public DbSet<Skin> Skins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChampionEntity>().HasKey(c => c.Id);
            modelBuilder.Entity<ChampionEntity>().Property(c => c.Id)
                                           .ValueGeneratedOnAdd();

            modelBuilder.Entity<SkinEntity>().HasKey(s => s.Name); //définition de la clé primaire
            modelBuilder.Entity<SkinEntity>().Property(s => s.Name)
                                            .ValueGeneratedOnAdd();

            modelBuilder.Entity<SkinEntity>()
                .Property<int>("SkinForeignKey");

            modelBuilder.Entity<SkinEntity>()
                .HasOne(s => s.Champion)
                .WithMany(c => c.Skins)
                .HasForeignKey("ChampionForeignKey");
        }
    }
}
