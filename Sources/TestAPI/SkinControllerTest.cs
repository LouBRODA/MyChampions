﻿using API_MyChampions;
using API_MyChampions.Controllers;
using DTO_MyChampions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using MyChampions.Controllers;
using StubLib;
using System.Xml.Linq;

//Tests for SkinController 

namespace TestAPI
{
    [TestClass]
    public class SkinControllerTest
    {
        private readonly SkinController skinController;
        private readonly StubData stubData;

        public SkinControllerTest()
        {
            stubData = new StubData();
            skinController = new SkinController(new StubData(), new NullLogger<SkinController>());
        }

        [TestMethod]
        public async Task TestGetChampion()
        {
            //Act
            var skinResult = await skinController.Get();

            //Assert
            var objectResult = skinResult as OkObjectResult;
            Assert.IsNotNull(objectResult);

            var skins = objectResult?.Value as IEnumerable<SkinDTO>;
            Assert.IsNotNull(objectResult);

            Assert.AreEqual(skins.Count(), await stubData.SkinsMgr.GetNbItems());
        }

        //[TestMethod]
        public async Task TestPostSkin()
        {
            ////Arrange
            //var skinDTO = new SkinDTO
            //{
            //    Name = "TestPost"
            //};

            ////Act
            //var skinResult = await skinController.Post(skinDTO);

            ////Assert
            //var createdResult = skinResult as CreatedAtActionResult;
            //Assert.IsNotNull(createdResult);

            //var skin = createdResult?.Value as SkinDTO;
            //Assert.IsNotNull(skin);
        }

        [TestMethod]
        public async Task TestPutSkin()
        {
            //Arange
            string name = "Skin";
            var newSkin = new SkinDTO { Name = "TestPut" };

            // Act
            var result = await skinController.Put(name, newSkin);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ObjectResult));
            Assert.IsNotNull(stubData.SkinsMgr.GetItemsByName("TestPut", 0, await stubData.SkinsMgr.GetNbItems()));
        }

        [TestMethod]
        public async Task TestDeleteSkin()
        {
            //Arrange
            var skinDTO = new SkinDTO
            {
                Name = "TestDelete"
            };

            //Act
            var skinResult = await skinController.Delete(skinDTO.Name);

            //Assert
            var createdResult = skinResult as CreatedAtActionResult;
            Assert.IsNull(createdResult);

            var skin = createdResult?.Value as SkinDTO;
            Assert.IsNull(skin);
        }

    }
}