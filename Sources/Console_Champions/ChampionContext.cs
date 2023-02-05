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

        public ChampionContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ChampionEntity> ChampionEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) { 
            base.OnConfiguring(options);
            options.UseSqlite($"DataSource = Console_Champion.ChampionsDB.db");
        }
            
    }
}
