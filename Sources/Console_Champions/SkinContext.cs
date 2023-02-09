﻿using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Champions
{
    public class SkinContext : DbContext
    {
        public SkinContext() { }

        public DbSet<SkinEntity> SkinEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseSqlite($"DataSource = Console_Champion.ChampionsDB.db");
        }
    }
}