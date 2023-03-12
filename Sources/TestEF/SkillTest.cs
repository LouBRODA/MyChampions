using Console_Champions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEF
{
    public class SkillTest
    {

        [Fact]
        public void Get_Skill_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Get_Skill_Test_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                SkillEntity firepower = new SkillEntity { Id = 1, Name = "FirePower", Type = SkillTypeEntity.Basic };
                ChampionEntity akali = new ChampionEntity() { Name = "Akali", Icon = "iconAkali", Image = "imageAkali", Bio = "bioAkali", Skills = new List<SkillEntity> { firepower } };

                context.SkillEntity.Add(firepower);
                context.ChampionEntity.Add(akali);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                //Assert.Equal("FirePower", context.ChampionEntity.First().Skills.First().Name);

            }
        }

        [Fact]
        public void Add_Skill_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Add_Skill_Test_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                SkillEntity firepower = new SkillEntity { Id = 1, Name = "FirePower", Type = SkillTypeEntity.Basic };
                SkillEntity mentalstrenght = new SkillEntity { Id = 2, Name = "MentalStrenght", Type = SkillTypeEntity.Passive };
                SkillEntity ultimend = new SkillEntity { Id = 3, Name = "UltimEnd", Type = SkillTypeEntity.Ultimate };

                context.SkillEntity.Add(firepower);
                context.SkillEntity.Add(mentalstrenght);
                context.SkillEntity.Add(ultimend);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(3, context.SkillEntity.Count());
            }
        }

        [Fact]
        public void Modify_Skill_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Modify_Skill_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                SkillEntity firepower = new SkillEntity { Id = 1, Name = "FirePower", Type = SkillTypeEntity.Basic };
                SkillEntity mentalstrenght = new SkillEntity { Id = 2, Name = "MentalStrenght", Type = SkillTypeEntity.Passive };
                SkillEntity ultimend = new SkillEntity { Id = 3, Name = "UltimEnd", Type = SkillTypeEntity.Ultimate };

                context.SkillEntity.Add(firepower);
                context.SkillEntity.Add(mentalstrenght);
                context.SkillEntity.Add(ultimend);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "en";
                Assert.Equal(2, context.SkillEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
                string nameToFind2 = "ow";
                Assert.Equal(1, context.SkillEntity.Where(n => n.Name.ToLower().Contains(nameToFind2)).Count());
                var firepower = context.SkillEntity.Where(n => n.Name.ToLower().Contains(nameToFind2)).First();
                firepower.Name = "WaterPower";

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "Fire";
                Assert.Equal(0, context.SkillEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
                //string nameToFind2 = "Water";
                //Assert.Equal(1, context.SkillEntity.Where(n => n.Name.ToLower().Contains(nameToFind2)).Count());
            }
        }

        [Fact]
        public void Delete_Skill_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Delete_Skill_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                SkillEntity firepower = new SkillEntity { Id = 1, Name = "FirePower", Type = SkillTypeEntity.Basic };

                context.SkillEntity.Add(firepower);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                var skill = context.SkillEntity.First();
                context.SkillEntity.Remove(skill);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(0, context.SkillEntity.Count());
            }
        }

    }
}
