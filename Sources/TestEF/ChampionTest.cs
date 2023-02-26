using Console_Champions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Model;

namespace TestEF
{
    public class ChampionTest
    {

        [Fact]
        public void Get_Champion_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Get_Champion_Test_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                ChampionEntity akali = new ChampionEntity() { Name = "Akali", Icon = "iconAkali", Image = "imageAkali", Bio = "bioAkali" };

                var name = akali.Name;
                var icon = akali.Icon;
                var image = akali.Image;
                var bio = akali.Bio;

                context.ChampionEntity.Add(akali);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal("Akali", context.ChampionEntity.First().Name);
                Assert.Equal("iconAkali", context.ChampionEntity.First().Icon);
                Assert.Equal("imageAkali", context.ChampionEntity.First().Image);
                Assert.Equal("bioAkali", context.ChampionEntity.First().Bio);
            }
        }

        [Fact]
        /*public void GetList_Champion_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "GetList_Champion_Test_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();
                var skin1 = new SkinEntity { Name = "Skin Akali 1" };
                var skin2 = new SkinEntity { Name = "Skin Akali 2" };
                var akali = new ChampionEntity { Skins = new List<SkinEntity> { skin1, skin2 } };

                context.ChampionEntity.Add(akali);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                var skin1 = new SkinEntity { Name = "Skin Akali 1" };
                var skin2 = new SkinEntity { Name = "Skin Akali 2" };

                Assert.Equal(2, context.ChampionEntity.First().Skins.Count());
                Assert.True(context.ChampionEntity.First().Skins.Contains(skin1));
                Assert.True(context.ChampionEntity.First().Skins.Contains(skin2));
            }

        }*/

        [Fact]
        public void Add_Champion_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Add_Champion_Test_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

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

                Assert.Equal(3, context.ChampionEntity.Count());
                Assert.Equal("Akali", context.ChampionEntity.First().Name);
            }
        }

        [Fact]
        public void Modify_Champion_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Modify_Champion_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

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

        [Fact]
        public void Delete_Champion_Test()
        {
            //connection must be opened to use In-memory database
            var connection = new SqliteConnection("DataSource=:memory:");

            var options = new DbContextOptionsBuilder<ChampionContext>()
                .UseInMemoryDatabase(databaseName: "Delete_Champion_database")
                .Options;

            //prepares the database with one instance of the context
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                ChampionEntity akali = new ChampionEntity() { Name = "Akali", Icon = "iconAkali", Image = "imageAkali", Bio = "bioAkali" };

                context.ChampionEntity.Add(akali);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                var champion = context.ChampionEntity.First();
                context.ChampionEntity.Remove(champion);

                context.SaveChanges();
            }

            //uses another instance of the context to do the tests
            using (var context = new ChampionContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(0, context.ChampionEntity.Count());
            }
        }
    }
}