using API_MyChampions;
using API_MyChampions.Controllers;
using DTO_MyChampions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using MyChampions.Controllers;
using StubLib;
using System.Xml.Linq;

//Tests for RunePageController 

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

        [TestMethod]
        public async Task TestGetRunePage()
        {
            //Act
            var runePageResult = await runePageController.Get();

            //Assert
            var objectResult = runePageResult as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var runePages = objectResult?.Value as IEnumerable<RunePageDTO>;
            Assert.IsNotNull(objectResult);

            Assert.AreEqual(runePages.Count(), await stubData.RunePagesMgr.GetNbItems());
        }

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