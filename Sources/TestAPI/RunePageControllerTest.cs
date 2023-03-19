using API_MyChampions;
using API_MyChampions.Controllers;
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
    public class RunePageControllerTest
    {
        private readonly RunePageController runePageController;
        private readonly StubData stubData;

        public RunePageControllerTest()
        {
            stubData = new StubData();
            runePageController = new RunePageController(new StubData(), new NullLogger<RunePageController>());
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
        public async Task TestPostRunePage()
        {
            //Arrange
            var runePageDTO = new RunePageDTO
            {
                Name = "TestPost"
            };

            //Act
            var runePageResult = await runePageController.Post(runePageDTO);

            //Assert
            var createdResult = runePageResult as CreatedAtActionResult;
            Assert.IsNotNull(createdResult);

            var runePage = createdResult?.Value as RunePageDTO;
            Assert.IsNotNull(runePage);
        }

        [TestMethod]
        public async Task TestPutRunePage()
        {
            //Arange
            string name = "RunePage";
            var newRunePage = new RunePageDTO { Name = "TestPut" };

            // Act
            var result = await runePageController.Put(name, newRunePage);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ObjectResult));
            Assert.IsNotNull(stubData.SkinsMgr.GetItemsByName("TestPut", 0, await stubData.RunePagesMgr.GetNbItems()));
        }

        [TestMethod]
        public async Task TestDeleteRunePage()
        {
            //Arrange
            var runePageDTO = new RunePageDTO
            {
                Name = "TestDelete"
            };

            //Act
            var runePageResult = await runePageController.Delete(runePageDTO.Name);

            //Assert
            var createdResult = runePageResult as CreatedAtActionResult;
            Assert.IsNull(createdResult);

            var runePage = createdResult?.Value as RunePageDTO;
            Assert.IsNull(runePage);
        }

    }
}