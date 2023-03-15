using API_MyChampions;
using API_MyChampions.Mapper;
using DTO_MyChampions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Model;
using StubLib;
using System.Collections.Generic;
using System.Xml.Linq;
using static StubLib.StubData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyChampions.Controllers
{
    [ApiVersion("2.0")]
    [ApiVersion("2.1")]
    [Route("api/v{version:apiVersion}/version")]
    [ApiController]
    public class ChampionsControllerV2 : ControllerBase
    {
        private IDataManager dataManager;
        private readonly ILogger<ChampionsController> _logger;

        public ChampionsControllerV2(IDataManager dataManager, ILogger<ChampionsController> logger)
        {
            this.ChampionsManager = dataManager.ChampionsMgr;
            _logger = logger;
        }

        private IChampionsManager ChampionsManager;

        [HttpGet, MapToApiVersion("2.0")]
        public string GetHello() => "Hello : ApiVersion2.0";

    }

}
