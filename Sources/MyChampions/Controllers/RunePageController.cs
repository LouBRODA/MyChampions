using API_MyChampions.Mapper;
using DTO_MyChampions;
using Microsoft.AspNetCore.Mvc;
using Model;

//RunePageController

namespace API_MyChampions.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RunePageController : ControllerBase
    {
        private IDataManager dataManager;
        private readonly ILogger<RunePageController> _logger;

        public RunePageController(IDataManager dataManager, ILogger<RunePageController> logger)
        {
            this.dataManager = dataManager;
            _logger = logger;
        }

        // GET: api/<RunePageController>
        [ApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation($"Method Get called");
            try
            {
                var runePages = (await dataManager.RunePagesMgr.GetItems(0, (await dataManager.RunePagesMgr.GetNbItems()))).Select(runePage => runePage?.ToDTO());
                return Ok(runePages);
            }
            catch (Exception exception)
            {
                _logger.LogError($"ERR : Method Get !");
                return StatusCode(500, exception);
            }
        }

        // GETBYNAME api/<RunePageController>/5
        [ApiVersion("1.0")]
        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            _logger.LogInformation($"Method GetByName called with {name}");
            try
            {
                var runePages = (await dataManager.RunePagesMgr.GetItems(0, (await dataManager.RunePagesMgr.GetNbItems()))).Select(runePage => runePage?.ToDTO());
                var runePageName = runePages.Where(rp => rp.Name.Equals(name));
                return Ok(runePageName);
            }
            catch (Exception exception)
            {
                _logger.LogError($"ERR : Method GetByName with {name} !");
                return StatusCode(500, exception);
            }
        }

        // POST api/<RunePageController>
        [ApiVersion("1.0")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RunePageDTO runePage)
        {
            _logger.LogInformation($"Method Post called with {runePage}");
            try
            {
                var runePageModel = runePage.ToModel();
                var runePageResult = await dataManager.RunePagesMgr.AddItem(runePageModel);
                var runePageDto = runePageResult.ToDTO();
                return CreatedAtAction("Get", new { Id = 1 }, runePageDto);
            }
            catch (Exception exception)
            {
                _logger.LogError($"ERR : Method Post with {runePage} !");
                return StatusCode(500, exception);
            }
        }

        // PUT api/<RunePageController>/5
        [ApiVersion("1.0")]
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody] RunePageDTO runePage)
        {
            _logger.LogInformation($"Method Put called with {name} and {runePage}");
            try
            {
                var runePageDto = await dataManager.RunePagesMgr.GetItemsByName(name, 0, await dataManager.RunePagesMgr.GetNbItems());
                await dataManager.RunePagesMgr.UpdateItem(runePageDto.First(), runePage.ToModel());
                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError($"ERR : Method Put with {name} and {runePage} !");
                return StatusCode(500, exception);
            }
        }

        // DELETE api/<RunePageController>/5
        [ApiVersion("1.0")]
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            _logger.LogInformation($"Method Delete called with {name}");
            try
            {
                var runePage = (await dataManager.RunePagesMgr.GetItemsByName(name, 0, 1)).First();
                dataManager.RunePagesMgr.DeleteItem(runePage);
                return Ok(runePage.ToDTO());
            }
            catch (Exception exception)
            {
                _logger.LogError($"ERR : Method Delete with {name} !");
                return StatusCode(500, exception);
            }
        }
    }
}
