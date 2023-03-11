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
    public class RunePageTest
    {
        [Fact]
        public void Get_RunePage_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Get_RunePage_Test_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                RunePageEntity runePage1 = new RunePageEntity { Id = 1, Name = "RunePage1" };
                ChampionEntity akali = new ChampionEntity() { Name = "Akali", Icon = "iconAkali", Image = "imageAkali", Bio = "bioAkali", RunePages = new List<RunePageEntity> { runePage1 } };

                context.RunePageEntity.Add(runePage1);
                context.ChampionEntity.Add(akali);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                //Assert.Equal("RunePage1", context.ChampionEntity.First().RunePages.First().Name);

            }
        }

        [Fact]
        public void Add_RunePage_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Add_RunePage_Test_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                RunePageEntity runePage1 = new RunePageEntity { Id = 1, Name = "RunePage1" };
                RunePageEntity runePage2 = new RunePageEntity { Id = 2, Name = "RunePage2" };

                context.RunePageEntity.Add(runePage1);
                context.RunePageEntity.Add(runePage2);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(2, context.RunePageEntity.Count());
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

                RunePageEntity runePage1 = new RunePageEntity { Id = 1, Name = "RunePage1" };
                RunePageEntity runePage2 = new RunePageEntity { Id = 2, Name = "RunePage2" };

                context.RunePageEntity.Add(runePage1);
                context.RunePageEntity.Add(runePage2);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "age";
                Assert.Equal(2, context.RunePageEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
                string nameToFind2 = "1";
                Assert.Equal(1, context.RunePageEntity.Where(n => n.Name.ToLower().Contains(nameToFind2)).Count());
                var runePage1 = context.RunePageEntity.Where(n => n.Name.ToLower().Contains(nameToFind2)).First();
                runePage1.Name = "RunePage3";

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "1";
                Assert.Equal(0, context.RunePageEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
                string nameToFind2 = "3";
                Assert.Equal(1, context.RunePageEntity.Where(n => n.Name.ToLower().Contains(nameToFind2)).Count());
            }
        }

        [Fact]
        public void Delete_RunePage_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Delete_RunePage_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                RunePageEntity runePage1 = new RunePageEntity { Id = 1, Name = "RunePage1" };

                context.RunePageEntity.Add(runePage1);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                var runePage = context.RunePageEntity.First();
                context.RunePageEntity.Remove(runePage);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(0, context.RunePageEntity.Count());
            }
        }
    }     

}

