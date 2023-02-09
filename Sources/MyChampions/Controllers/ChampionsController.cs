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

        public ChampionsController(IDataManager dataManager)
        {
            this.dataManager= dataManager;
        }

        // GET: api/<ChampionsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var champions = (await dataManager.ChampionsMgr.GetItems(0, (await dataManager.ChampionsMgr.GetNbItems()))).Select(champion=>champion?.ToDTO());
            return Ok(champions);
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
