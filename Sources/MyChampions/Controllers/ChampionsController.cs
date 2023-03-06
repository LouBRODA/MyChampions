using API_MyChampions;
using API_MyChampions.Mapper;
using DTO_MyChampions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Model;
using StubLib;
using System.Xml.Linq;

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
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest, [FromQuery] string? name = "")
        {

            //_logger.LogInformation(_keyConfig.Value.Key);

            IEnumerable<ChampionDTO> dtos = new List<ChampionDTO>();

            if(pageRequest.Count > 50)
            {
                _logger.LogWarning($"ERR : Count superior to the limit with {pageRequest} !");
            }

            int total = await dataManager.ChampionsMgr.GetNbItems();
            
            _logger.LogInformation($"Method Get called with {pageRequest} and {name}");

            try
            {
                if (name != "")
                {
                    if (pageRequest is null)
                    {
                        dtos = (await dataManager.ChampionsMgr.GetItems(0,int.MaxValue)).Where(champion => champion.Name.Contains(name)).Select(champion => champion?.ToDTO());
                    }
                    dtos = (await dataManager.ChampionsMgr.GetItems(pageRequest.Index, pageRequest.Count)).Where(champion => champion.Name.Contains(name)).Select(champion => champion?.ToDTO());
                }
                else
                {
                    dtos = (await dataManager.ChampionsMgr.GetItems(pageRequest.Index, pageRequest.Count)).Select(champion => champion?.ToDTO());
                }
          
                var page = new ChampionPageDto()
                {
                    Data = dtos,
                    Index = pageRequest.Index,
                    Count = pageRequest.Count,
                    TotalCount = total,
                };

                return Ok(page);
            }
            catch (Exception exception)
            { 
                _logger.LogWarning($"ERR : Method Get with {pageRequest} and {name} !");
                return BadRequest(exception); 
            }


        }   

        // GET api/<ChampionsController>/5
        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            _logger.LogInformation($"Method GetByName called with {name}");
            try
            {
                var champions = (await dataManager.ChampionsMgr.GetItems(0, (await dataManager.ChampionsMgr.GetNbItems()))).Select(champion => champion?.ToDTO());
                var champName = champions.Where(c => c.Name.Equals(name));
                return Ok(champName);
            }
            catch (Exception exception)
            {
                _logger.LogWarning($"ERR : Method GetByName with {name} !");
                return BadRequest(exception);
            }
        }

        // POST api/<ChampionsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChampionDTO champion)
        {
            _logger.LogInformation($"Method Post called with {champion}");
            try
            {
                var championModel = champion.ToModel();
                var championResult = await dataManager.ChampionsMgr.AddItem(championModel);
                var championDto = championResult.ToDTO();
                return CreatedAtAction("Get", new { Id = 1 }, championDto);
            }
            catch (Exception exception)
            {
                _logger.LogWarning($"ERR : Method Post with {champion} !");
                return BadRequest(exception);
            }
        }

        // PUT api/<ChampionsController>/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody] ChampionDTO champion)
        {
            _logger.LogInformation($"Method Put called with {name} and {champion}");
            try
            {
                var championDto = await dataManager.ChampionsMgr.GetItemsByName(name, 0, await dataManager.ChampionsMgr.GetNbItems());
                await dataManager.ChampionsMgr.UpdateItem(championDto.First(), champion.ToModel());
                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogWarning($"ERR : Method Put with {name} and {champion} !");
                return BadRequest(exception);
            }
        }

        // DELETE api/<ChampionsController>/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            _logger.LogInformation($"Method Delete called with {name}");
            try
            {
                var champion = (await dataManager.ChampionsMgr.GetItemsByName(name, 0, 1)).First();
                dataManager.ChampionsMgr.DeleteItem(champion);
                return Ok(champion.ToDTO());
            }
            catch (Exception exception)
            {
                _logger.LogWarning($"ERR : Method Delete with {name} !");
                return BadRequest(exception);
            }
        }
    }
}
