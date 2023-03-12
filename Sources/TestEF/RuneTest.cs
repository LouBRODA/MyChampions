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
    public class RuneTest
    {
        [Fact]
        public void Get_Rune_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Get_Rune_Test_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                RuneEntity rune1 = new RuneEntity{ Id = 1, Name = "Conqueror", Family = RuneFamilyEntity.Precision };
                RunePageEntity runePage1 = new RunePageEntity { Id = 1, Name = "RunePage1", Runes = new List<RuneEntity> { rune1 } };

                context.RunePageEntity.Add(runePage1);
                context.RuneEntity.Add(rune1);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                //Assert.Equal("Rune1", context.RunePageEntity.First().Runes.First().Name);

            }
        }

        [Fact]
        public void Add_Rune_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Add_Rune_Test_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                RuneEntity rune1 = new RuneEntity { Id = 1, Name = "Conqueror", Family = RuneFamilyEntity.Precision };
                RuneEntity rune2 = new RuneEntity { Id = 2, Name = "Triumph", Family = RuneFamilyEntity.Precision };
                RuneEntity rune3 = new RuneEntity { Id = 3, Name = "Legend: Alacrity", Family = RuneFamilyEntity.Precision };
                RuneEntity rune4 = new RuneEntity { Id = 4, Name = "Legend: Tenacity", Family = RuneFamilyEntity.Precision };

                context.RuneEntity.Add(rune1);
                context.RuneEntity.Add(rune2);
                context.RuneEntity.Add(rune3);
                context.RuneEntity.Add(rune4);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(4, context.RuneEntity.Count());
            }
        }

        [Fact]
        public void Modify_RunePage_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Modify_RunePage_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                RuneEntity rune1 = new RuneEntity { Id = 1, Name = "Conqueror", Family = RuneFamilyEntity.Precision };
                RuneEntity rune2 = new RuneEntity { Id = 2, Name = "Triumph", Family = RuneFamilyEntity.Precision };
                RuneEntity rune3 = new RuneEntity { Id = 3, Name = "Legend: Alacrity", Family = RuneFamilyEntity.Precision };

                context.RuneEntity.Add(rune1);
                context.RuneEntity.Add(rune2);
                context.RuneEntity.Add(rune3);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "or";
                Assert.Equal(1, context.RuneEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
                string nameToFind2 = "e";
                Assert.Equal(2, context.RuneEntity.Where(n => n.Name.ToLower().Contains(nameToFind2)).Count());
                var rune1 = context.RuneEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).First();
                rune1.Name = "Conquist";

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "or";
                Assert.Equal(0, context.RuneEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
                string nameToFind2 = "ist";
                Assert.Equal(1, context.RuneEntity.Where(n => n.Name.ToLower().Contains(nameToFind2)).Count());
            }
        }

        [Fact]
        public void Delete_Rune_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Delete_Rune_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                RuneEntity rune1 = new RuneEntity { Id = 1, Name = "Conqueror", Family = RuneFamilyEntity.Precision };
                RuneEntity rune2 = new RuneEntity { Id = 2, Name = "Triumph", Family = RuneFamilyEntity.Precision };

                context.RuneEntity.Add(rune1);
                context.RuneEntity.Add(rune2);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                var rune1 = context.RuneEntity.First();
                context.RuneEntity.Remove(rune1);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(1, context.RuneEntity.Count());
            }
        }
    }
}
