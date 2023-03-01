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

        public ChampionContext(DbContextOptions options) : base(options) { }

        public ChampionContext() { }

        public DbSet<ChampionEntity> ChampionEntity { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder options) { 
            base.OnConfiguring(options);
            options.UseSqlite($"DataSource = Console_Champion.ChampionsDB.db");
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite($"DataSource = Console_Champion.ChampionsDB.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkinEntity>().Property<int>("ForeignChampion");

            modelBuilder.Entity<SkinEntity>()
                .HasOne(s => s.Champion)
                .WithMany(c => c.Skins)
                .HasForeignKey("ForeignChampion");

            modelBuilder.Entity<SkillEntity>()
                .HasMany<ChampionEntity>(s => s.Champions)
                .WithMany(c => c.Skills);
        }
    }
}
