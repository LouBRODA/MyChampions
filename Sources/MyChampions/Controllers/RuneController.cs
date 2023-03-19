using API_MyChampions.Mapper;
using DTO_MyChampions;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_MyChampions.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RuneController : ControllerBase
    {
        private IDataManager dataManager;
        private readonly ILogger<RuneController> _logger;

        public RuneController(IDataManager dataManager, ILogger<RuneController> logger)
        {
            this.dataManager = dataManager;
            _logger = logger;
        }

        // GET: api/<RuneController>
        [ApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation($"Method Get called");
            try
            {
                var runes = (await dataManager.RunesMgr.GetItems(0, (await dataManager.RunesMgr.GetNbItems()))).Select(rune => rune?.ToDTO());
                return Ok(runes);
            }
            catch (Exception exception)
            {
                _logger.LogError($"ERR : Method Get !");
                return StatusCode(500, exception);
            }
        }

        // GETBYNAME api/<RuneController>/5
        [ApiVersion("1.0")]
        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            _logger.LogInformation($"Method GetByName called with {name}");
            try
            {
                var runes = (await dataManager.RunesMgr.GetItems(0, (await dataManager.RunesMgr.GetNbItems()))).Select(rune => rune?.ToDTO());
                var runeName = runes.Where(s => s.Name.Equals(name));
                return Ok(runeName);
            }
            catch (Exception exception)
            {
                _logger.LogError($"ERR : Method GetByName with {name} !");
                return StatusCode(500, exception);
            }
        }

        // POST api/<RuneController>
        [ApiVersion("1.0")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RuneDTO rune)
        {
            _logger.LogInformation($"Method Post called with {rune}");
            try
            {
                var runeModel = rune.ToModel();
                var runeResult = await dataManager.RunesMgr.AddItem(runeModel);
                var runeDto = runeResult.ToDTO();
                return CreatedAtAction("Get", new { Id = 1 }, runeDto);
            }
            catch (Exception exception)
            {
                _logger.LogError($"ERR : Method Post with {rune} !");
                return StatusCode(500, exception);
            }
        }

        // PUT api/<RuneController>/5
        [ApiVersion("1.0")]
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody] RuneDTO rune)
        {
            _logger.LogInformation($"Method Put called with {name} and {rune}");
            try
            {
                var runeDto = await dataManager.RunesMgr.GetItemsByName(name, 0, await dataManager.RunesMgr.GetNbItems());
                await dataManager.RunesMgr.UpdateItem(runeDto.First(), rune.ToModel());
                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError($"ERR : Method Put with {name} and {rune} !");
                return StatusCode(500, exception);
            }
        }

        // DELETE api/<RuneController>/5
        [ApiVersion("1.0")]
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            _logger.LogInformation($"Method Delete called with {name}");
            try
            {
                var rune = (await dataManager.RunesMgr.GetItemsByName(name, 0, 1)).First();
                dataManager.RunesMgr.DeleteItem(rune);
                return Ok(rune.ToDTO());
            }
            catch (Exception exception)
            {
                _logger.LogError($"ERR : Method Delete with {name} !");
                return StatusCode(500, exception);
            }
        }
    }
}
