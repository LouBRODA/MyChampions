using DTO_MyChampions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using MyChampions.Controllers;
using StubLib;
using System.Xml.Linq;

namespace TestAPI
{
    [TestClass]
    public class ChampionsControllerTest
    {
        private readonly ChampionsController championsController;
        private readonly StubData stubData;

        public ChampionsControllerTest()
        {
            stubData = new StubData();
            championsController = new ChampionsController(new StubData(), new NullLogger<ChampionsController>());
        }

        //[TestMethod]
        //public async Task TestGetChampion()
        //{
        //    //Act
        //    var championsResult = await championsController.Get(null);

        //    //Assert
        //    var objectResult = championsResult as OkObjectResult;
        //    Assert.IsNotNull(objectResult);

        //    var champions = objectResult?.Value as IEnumerable<ChampionDTO>;
        //    Assert.IsNotNull(objectResult);

        //    Assert.AreEqual(champions.Count(), await stubData.ChampionsMgr.GetNbItems());
        //}

        [TestMethod]
        public async Task TestPostChampion()
        {
            //Arrange
            var championDTO = new ChampionDTO
            {
                Name = "TestPost"
            };

            //Act
            var championsResult = await championsController.Post(championDTO);

            //Assert
            var createdResult = championsResult as CreatedAtActionResult;
            Assert.IsNotNull(createdResult);

            var champion = createdResult?.Value as ChampionDTO;
            Assert.IsNotNull(champion);
        }

        //[TestMethod]
        //public async Task TestPutChampion()
        //{
        //    //Arrange
        //    var championDTO = new ChampionDTO
        //    {
        //        Name = "TestPut"
        //    };

        //    //Act
        //    var championsResultPut = await championsController.Put("NameChanged",championDTO);

        //    //Assert
        //    var champion = championsResultPut as ChampionDTO;
        //    Assert.AreNotEqual("TestPut",championDTO.Name);
        //}

        [TestMethod]
        public async Task TestDeleteChampion()
        {
            //Arrange
            var championDTO = new ChampionDTO
            {
                Name = "TestDelete"
            };

            //Act
            var championsResult = await championsController.Delete(championDTO.Name);

            //Assert
            var createdResult = championsResult as CreatedAtActionResult;
            Assert.IsNull(createdResult);

            var champion = createdResult?.Value as ChampionDTO;
            Assert.IsNull(champion);
        }

    }
}