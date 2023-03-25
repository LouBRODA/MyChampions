using API_MyChampions;
using DTO_MyChampions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using MyChampions.Controllers;
using StubLib;
using System.Xml.Linq;

//Tests for ChampionsController 

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
        //    //Arrange
        //    var pageRequest = new PageRequest();
        //    var championDTO = new ChampionDTO
        //    {
        //        Name = "TestGet"
        //    };

        //    //Act
        //    var championsResult = await championsController.Get(pageRequest, championDTO.Name);

        //    //Assert
        //    var objectResult = championsResult as OkObjectResult;
        //    Assert.IsNotNull(objectResult);

        //    var champions = objectResult.Value as IEnumerable<ChampionDTO>;    
        //    Assert.IsNotNull(champions);

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

        [TestMethod]
        public async Task TestPutChampion()
        {
            //Arange
            string name = "Akali";
            var newChamp = new ChampionDTO { Name = "TestPut" };

            // Act
            var result = await championsController.Put(name, newChamp);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
            Assert.IsNotNull(stubData.ChampionsMgr.GetItemsByName("TestPut", 0, await stubData.ChampionsMgr.GetNbItems()));
        }

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