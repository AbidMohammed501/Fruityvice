using FruityviceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruityviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruityviceController : ControllerBase
    {
        private readonly ILogger<FruityviceController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IFruityviceService _fruityService;

        public FruityviceController(ILogger<FruityviceController> logger, IConfiguration configuration, IFruityviceService fruityService)
        {
            _logger = logger;
            _configuration = configuration;
            _fruityService = fruityService;
        }

        /// <summary>
        /// (ListofFruits)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("fruits/list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FruitsList()
        {
            _logger.LogInformation("FruitsList invoked");
            _logger.LogDebug("FruitsList invoked");

            try
            {
                var results = new List<Fruits>();
                results = (List<Fruits>)await _fruityService.FruitsList();
                _logger.LogInformation("FruitsList complete");

                if (results != null)
                    _logger.LogDebug("FruitsList result: {@results}", results);

                return (results == null || results.Count == 0) ? NotFound() : Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in FruitsList failed");
                throw;
            }
        }

        /// <summary>
        /// (FruitsListByFruitfamily)
        /// family ex: Ebenaceae, Rosaceae, Musaceae, Solanaceae, Malvaceae, Ericaceae, Actinidiaceae ......
        /// </summary>
        /// <param name="family"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("list/fruits/{family}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FruitsListByFruitfamily([FromRoute] string family)
        {
            _logger.LogInformation("FruitsListByFruitfamily invoked");
            _logger.LogDebug("FruitsListByFruitfamily invoked {@request}", family);

            try
            {
                var results = new List<Fruits>();
                results = (List<Fruits>)await _fruityService.FruitsListByFruitfamily(family);
                _logger.LogInformation("FruitsListByFruitfamily complete");

                if (results != null)
                    _logger.LogDebug("FruitsList result: {@results}", results);

                return (results == null || results.Count == 0) ? NotFound() : Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in FruitsListByFruitfamily failed {family}", family);
                throw;
            }
        }
    }
}
