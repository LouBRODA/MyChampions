using API_MyChampions;
using API_MyChampions.Controllers;
using DTO_MyChampions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using MyChampions.Controllers;
using StubLib;
using System.Xml.Linq;

//Tests for RuneController 

namespace TestAPI
{
    [TestClass]
    public class RuneControllerTest
    {
        private readonly RuneController runeController;
        private readonly StubData stubData;

        public RuneControllerTest()
        {
            stubData = new StubData();
            runeController = new RuneController(new StubData(), new NullLogger<RuneController>());
        }

        [TestMethod]
        public async Task TestGetChampion()
        {
            //Act
            var runeResult = await runeController.Get();

            //Assert
            var objectResult = runeResult as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var runes = objectResult?.Value as IEnumerable<RuneDTO>;
            Assert.IsNotNull(objectResult);

            Assert.AreEqual(runes.Count(), await stubData.RunesMgr.GetNbItems());
        }

        [TestMethod]
        public async Task TestPostRune()
        {
            //Arrange
            var runeDTO = new RuneDTO
            {
                Name = "TestPost"
            };

            //Act
            var runeResult = await runeController.Post(runeDTO);

            //Assert
            var createdResult = runeResult as CreatedAtActionResult;
            Assert.IsNotNull(createdResult);

            var rune = createdResult?.Value as RuneDTO;
            Assert.IsNotNull(rune);
        }

        [TestMethod]
        public async Task TestPutRune()
        {
            //Arange
            string name = "Rune";
            var newRune = new RuneDTO { Name = "TestPut" };

            // Act
            var result = await runeController.Put(name, newRune);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ObjectResult));
            Assert.IsNotNull(stubData.RunesMgr.GetItemsByName("TestPut", 0, await stubData.RunesMgr.GetNbItems()));
        }

        [TestMethod]
        public async Task TestDeleteRune()
        {
            //Arrange
            var runeDTO = new RuneDTO
            {
                Name = "TestDelete"
            };

            //Act
            var runeResult = await runeController.Delete(runeDTO.Name);

            //Assert
            var createdResult = runeResult as CreatedAtActionResult;
            Assert.IsNull(createdResult);

            var rune = createdResult?.Value as RuneDTO;
            Assert.IsNull(rune);
        }

    }
}