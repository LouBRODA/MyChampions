using API_MyChampions.Mapper;
using DTO_MyChampions;
using Microsoft.AspNetCore.Mvc;
using Model;

//SkinController

namespace API_MyChampions.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SkinController : ControllerBase
    {
        private IDataManager dataManager;
        private readonly ILogger<SkinController> _logger;

        public SkinController(IDataManager dataManager, ILogger<SkinController> logger)
        {
            this.dataManager = dataManager;
            _logger = logger;
        }

        // GET: api/<SkinController>
        [ApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation($"Method Get called");
            try
            {
                var skins = (await dataManager.SkinsMgr.GetItems(0, (await dataManager.SkinsMgr.GetNbItems()))).Select(skin => skin?.ToDTO());
                return Ok(skins);
            }
            catch (Exception exception)
            {
                _logger.LogError($"ERR : Method Get !");
                return StatusCode(500, exception);
            }
        }

        // GETBYNAME api/<SkinController>/5
        [ApiVersion("1.0")]
        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            _logger.LogInformation($"Method GetByName called with {name}");
            try
            {
                var skins = (await dataManager.SkinsMgr.GetItems(0, (await dataManager.SkinsMgr.GetNbItems()))).Select(skin => skin?.ToDTO());
                var skinName = skins.Where(s => s.Name.Equals(name));
                return Ok(skinName);
            }
            catch (Exception exception)
            {
                _logger.LogError($"ERR : Method GetByName with {name} !");
                return StatusCode(500, exception);
            }
        }

        // POST api/<SkinController>
        [ApiVersion("1.0")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SkinDTO skin)
        {
            _logger.LogInformation($"Method Post called with {skin}");
            try
            {
                var skinModel = skin.ToModel();
                var skinResult = await dataManager.SkinsMgr.AddItem(skinModel);
                var skinDto = skinResult.ToDTO();
                return CreatedAtAction("Get", new { Id = 1 }, skinDto);
            }
            catch (Exception exception)
            {
                _logger.LogError($"ERR : Method Post with {skin} !");
                return StatusCode(500, exception);
            }
        }

        // PUT api/<SkinController>/5
        [ApiVersion("1.0")]
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody] SkinDTO skin)
        {
            _logger.LogInformation($"Method Put called with {name} and {skin}");
            try
            {
                var skinDto = await dataManager.SkinsMgr.GetItemsByName(name, 0, await dataManager.SkinsMgr.GetNbItems());
                await dataManager.SkinsMgr.UpdateItem(skinDto.First(), skin.ToModel());
                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError($"ERR : Method Put with {name} and {skin} !");
                return StatusCode(500, exception);
            }
        }

        // DELETE api/<SkinController>/5
        [ApiVersion("1.0")]
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            _logger.LogInformation($"Method Delete called with {name}");
            try
            {
                var skin = (await dataManager.SkinsMgr.GetItemsByName(name, 0, 1)).First();
                dataManager.SkinsMgr.DeleteItem(skin);
                return Ok(skin.ToDTO());
            }
            catch (Exception exception)
            {
                _logger.LogError($"ERR : Method Delete with {name} !");
                return StatusCode(500, exception);
            }
        }
    }
}
