using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ChampionContext (used with Program.cs) to define Database

namespace Console_Champions
{

    public class ChampionContext : DbContext
    {

        public ChampionContext(DbContextOptions options) : base(options) { }

        //public ChampionContext() { }

        public DbSet<ChampionEntity> ChampionEntity { get; set; }
        public DbSet<SkinEntity> SkinEntity { get; set; }
        public DbSet<SkillEntity> SkillEntity { get; set; }
        public DbSet<RunePageEntity> RunePageEntity { get; set; }
        public DbSet<RuneEntity> RuneEntity { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite($"DataSource = Console_Champion.ChampionsDB.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SkinEntity>().Property<int>("ForeignChampion");

            modelBuilder.Entity<SkinEntity>()
                .HasOne(s => s.Champion)
                .WithMany(c => c.Skins)
                .HasForeignKey("ForeignChampion");

            modelBuilder.Entity<SkillEntity>()
                .HasMany(s => s.Champions)
                .WithMany(c => c.Skills);

            modelBuilder.Entity<RunePageEntity>()
                .HasMany(rp => rp.Champions)
                .WithMany(c => c.RunePages);

            modelBuilder.Entity<RuneEntity>()
                .HasMany(r => r.RunePages)
                .WithMany(rp => rp.Runes);

        }
    }
}
