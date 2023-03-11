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
    public class SkinTest
    {

        [Fact]
        public void Get_Skin_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Get_Skin_Test_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                ChampionEntity akali = new ChampionEntity() { Name = "Akali", Icon = "iconAkali", Image = "imageAkali", Bio = "bioAkali" };
                SkinEntity stinger = new SkinEntity() { Name = "Stinger", Champion = akali  };

                var name = stinger.Name;
                var champion = stinger.Champion;

                context.SkinEntity.Add(stinger);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                ChampionEntity akali = new ChampionEntity() { Name = "Akali", Icon = "iconAkali", Image = "imageAkali", Bio = "bioAkali" };

                Assert.Equal("Stinger", context.SkinEntity.First().Name);

            }
        }

        [Fact]
        public void Add_Skin_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Add_Skin_Test_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                ChampionEntity akali = new ChampionEntity() { Name = "Akali", Icon = "iconAkali", Image = "imageAkali", Bio = "bioAkali" };

                SkinEntity stinger = new SkinEntity() { Name = "Stinger", Champion = akali };
                SkinEntity infernal = new SkinEntity() { Name = "Infernal", Champion = akali };
                SkinEntity all_star = new SkinEntity() { Name = "All-Star", Champion = akali };

                context.SkinEntity.Add(stinger);
                context.SkinEntity.Add(infernal);
                context.SkinEntity.Add(all_star);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(3, context.SkinEntity.Count());
            }
        }

        [Fact]
        public void Modify_Skin_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Modify_Skin_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                ChampionEntity akali = new ChampionEntity() { Name = "Akali", Icon = "iconAkali", Image = "imageAkali", Bio = "bioAkali" };

                SkinEntity stinger = new SkinEntity() { Name = "Stinger", Champion = akali };
                SkinEntity infernal = new SkinEntity() { Name = "Infernal", Champion = akali };
                SkinEntity all_star = new SkinEntity() { Name = "All-Star", Champion = akali };

                context.SkinEntity.Add(stinger);
                context.SkinEntity.Add(infernal);
                context.SkinEntity.Add(all_star);
                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "i";
                Assert.Equal(2, context.SkinEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
                nameToFind = "stin";
                Assert.Equal(1, context.SkinEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
                var stinger = context.SkinEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).First();
                stinger.Name = "Stinger";
                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "sta";
                Assert.Equal(1, context.SkinEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
                nameToFind = "nal";
                Assert.Equal(1, context.SkinEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
            }
        }

        [Fact]
        public void Delete_Skin_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Delete_Skin_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                ChampionEntity akali = new ChampionEntity() { Name = "Akali", Icon = "iconAkali", Image = "imageAkali", Bio = "bioAkali" };

                SkinEntity stinger = new SkinEntity() { Name = "Stinger", Champion = akali };

                context.SkinEntity.Add(stinger);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                var skin = context.SkinEntity.First();
                context.SkinEntity.Remove(skin);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(0, context.SkinEntity.Count());
            }
        }

    }
}
