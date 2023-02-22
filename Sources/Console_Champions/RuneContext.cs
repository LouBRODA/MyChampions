using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Champions
{
    public class RuneContext
    {
        public RuneContext() { }

        public DbSet<RuneEntity> RuneEntity { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseSqlite($"DataSource = Console_Champion.ChampionsDB.db");
        }*/
    }
}
