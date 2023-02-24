using API_MyChampions;
using API_MyChampions.Mapper;
using DTO_MyChampions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Model;
using StubLib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyChampions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionsController : ControllerBase
    {
        private IDataManager dataManager;
        private readonly ILogger<ChampionsController> _logger;
        //private readonly IOptions<KeyConfig> _keyConfig;

        public ChampionsController(IDataManager dataManager, ILogger<ChampionsController> logger)
        {
            this.dataManager= dataManager;
            _logger = logger;
        }

        // GET: api/<ChampionsController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageRequest? pageRequest)
        {
            //var champions = (await dataManager.ChampionsMgr.GetItems(0, (await dataManager.ChampionsMgr.GetNbItems()))).Select(champion=>champion?.ToDTO());

            //_logger.LogInformation(_keyConfig.Value.Key);

            if(pageRequest.Count > 50)
            {
                _logger.LogWarning("ERR : Count superior to the limit !");
            }

            int total = await dataManager.ChampionsMgr.GetNbItems();

            _logger.LogInformation("Method Get call");

            var dtos = (await dataManager.ChampionsMgr.GetItems(pageRequest.Index, pageRequest.Count)).Select(champion => champion?.ToDTO());

            var page = new ChampionPageDto()
            {
                Data = dtos,
                Count = pageRequest.Index,
                Index = pageRequest.Count,
                TotalCount = total,
            };

            return Ok(page);
        }   

        // GET api/<ChampionsController>/5
        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var champions = (await dataManager.ChampionsMgr.GetItems(0, (await dataManager.ChampionsMgr.GetNbItems()))).Select(champion => champion?.ToDTO());
            var champName = champions.Where(c => c.Name.Equals(name));
            return Ok(champName);
        }

        // POST api/<ChampionsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChampionDTO champion)
        {
            var championModel = champion.ToModel();
            var championResult = await dataManager.ChampionsMgr.AddItem(championModel);
            var championDto = championResult.ToDTO();
            return CreatedAtAction("Get", new { Id = 1 }, championDto);
        }

        // PUT api/<ChampionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChampionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
