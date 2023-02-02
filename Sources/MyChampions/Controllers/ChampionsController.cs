using API_MyChampions.Mapper;
using DTO_MyChampions;
using Microsoft.AspNetCore.Mvc;
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
        private StubData stubData;

        public ChampionsController(StubData stubData)
        {
            this.stubData = stubData;
        }

        public void Controller(IDataManager dataManager)
        {
            this.dataManager= dataManager;
        }

        // GET: api/<ChampionsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            StubData stubData = new StubData();
            var champions = (await stubData.ChampionsMgr.GetItems(0, (await stubData.ChampionsMgr.GetNbItems()))).Select(champion=>champion.ToDTO());
            return Ok(champions);
        }

        // GET api/<ChampionsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChampionsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChampionDTO champion)
        {
            return CreatedAtAction(nameof(Get), new { Id = 1 }, (await dataManager.ChampionsMgr.AddItem(ChampionMapper.ToModel(champion))).ToDTO());
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
