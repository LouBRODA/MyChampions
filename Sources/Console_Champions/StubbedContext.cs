using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Champions
{
    public class StubbedContext : ChampionContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SkillEntity firepower = new SkillEntity { Id = 1, Name = "FirePower", Type = SkillTypeEntity.Basic };
            SkillEntity mentalstrenght = new SkillEntity { Id = 2, Name = "MentalStrenght", Type = SkillTypeEntity.Passive };
            SkillEntity ultimend = new SkillEntity { Id = 3, Name = "UltimEnd", Type = SkillTypeEntity.Ultimate };

            ChampionEntity akali = new ChampionEntity { Id = 1, Name = "Akali", Class = ChampClassEntity.Assassin, Skills = new List<SkillEntity> { firepower, mentalstrenght } };
            ChampionEntity aatrox = new ChampionEntity { Id = 2, Name = "Aatrox", Class = ChampClassEntity.Fighter, Skills = new List<SkillEntity> { firepower, ultimend } };
            ChampionEntity ahri = new ChampionEntity { Id = 3, Name = "Ahri", Class = ChampClassEntity.Mage, Skills = new List<SkillEntity> { mentalstrenght, ultimend } };

            modelBuilder.Entity<ChampionEntity>().HasData(akali, aatrox, ahri);

            modelBuilder.Entity<SkinEntity>().HasData(new { Id = 1, ForeignChampion = 1, Name = "Stinger" },
                                    new { Id = 2, ForeignChampion = 1, Name = "Infernal" },
                                    new { Id = 3, ForeignChampion = 1, Name = "All-Star" },
                                    new { Id = 4, ForeignChampion = 2, Name = "Justicar" },
                                    new { Id = 5, ForeignChampion = 2, Name = "Mecha" },
                                    new { Id = 6, ForeignChampion = 2, Name = "Sea Hunter" },
                                    new { Id = 7, ForeignChampion = 3, Name = "Dynasty" },
                                    new { Id = 8, ForeignChampion = 3, Name = "Midnight" },
                                    new { Id = 9, ForeignChampion = 3, Name = "Foxfire" }
                );

            modelBuilder.Entity<RuneEntity>().HasData(new { Id = 1, Name = "Conqueror", Type = RuneFamilyEntity.Precision },
                                    new { Id = 2, Name = "Triumph", Type = RuneFamilyEntity.Precision },
                                    new { Id = 3, Name = "Legend: Alacrity", Type = RuneFamilyEntity.Precision },
                                    new { Id = 4, Name = "Legend: Tenacity", Type = RuneFamilyEntity.Precision },
                                    new { Id = 5, Name = "last stand", Type = RuneFamilyEntity.Domination },
                                    new { Id = 6, Name = "last stand 2", Type = RuneFamilyEntity.Domination }
                );


            RunePageEntity runePage1 = new RunePageEntity { Id = 1, Name = "RunePage1" };
            RunePageEntity runePage2 = new RunePageEntity { Id = 2, Name = "RunePage2" };

            modelBuilder.Entity<RunePageEntity>().HasData(runePage1, runePage2);

        }
    }
}
