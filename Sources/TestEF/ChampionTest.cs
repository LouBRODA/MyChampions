using Console_Champions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Model;

namespace TestEF
{
    public class ChampionTest
    {
        [Fact]
        public void Add_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");
            //connection.Open();

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseSqlite(connection)
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                //context.Database.OpenConnection();
                context.Database.EnsureCreated();

                ChampionEntity akali = new ChampionEntity() { Name="Akali", Icon="iconAkali", Image="imageAkali", Bio="bioAkali" };
                ChampionEntity aatrox = new ChampionEntity() { Name = "Aatrox", Icon = "iconAatrox", Image = "imageAatrox", Bio = "bioAatrox" };
                ChampionEntity ahri = new ChampionEntity() { Name = "Ahri", Icon = "iconAhri", Image = "imageAhri", Bio = "bioAhri" };

                context.ChampionEntity.Add(akali);
                context.ChampionEntity.Add(aatrox);
                context.ChampionEntity.Add(ahri);
                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(3, context.ChampionEntity.Count());
                Assert.Equal("Akali", context.ChampionEntity.First().Name);
            }
        }

        [Fact]
        public void Modify_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");
            //connection.Open();

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseSqlite(connection)
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                //context.Database.OpenConnection();
                context.Database.EnsureCreated();
                context.ChampionEntity.RemoveRange(context.ChampionEntity);

                ChampionEntity akali = new ChampionEntity() { Name = "Akali", Icon = "iconAkali", Image = "imageAkali", Bio = "bioAkali" };
                ChampionEntity aatrox = new ChampionEntity() { Name = "Aatrox", Icon = "iconAatrox", Image = "imageAatrox", Bio = "bioAatrox" };
                ChampionEntity ahri = new ChampionEntity() { Name = "Ahri", Icon = "iconAhri", Image = "imageAhri", Bio = "bioAhri" };

                context.ChampionEntity.Add(akali);
                context.ChampionEntity.Add(aatrox);
                context.ChampionEntity.Add(ahri);
                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "a";
                Assert.Equal(3, context.ChampionEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
                nameToFind = "ah";
                Assert.Equal(1, context.ChampionEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
                var ahri = context.ChampionEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).First();
                ahri.Name = "Ahri";
                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "ak";
                Assert.Equal(1, context.ChampionEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
                nameToFind = "aa";
                Assert.Equal(1, context.ChampionEntity.Where(n => n.Name.ToLower().Contains(nameToFind)).Count());
            }
        }
    }
}