using apicampaign.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace apicampaign.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly onlinecampaignContext _context;
        //private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly ILogger<CampaignController> _logger;
        public CampaignController(onlinecampaignContext context, ILogger<CampaignController> logger)
        {
            _context = context;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into HomeController");
        }
        // GET: api/TodoItems
        [HttpGet]
        public ActionResult<IEnumerable<WO_MAS_CAMPAIGN>> GetCampaign()
        {
            // logger.Info("hello now You have visited the About view" + Environment.NewLine + DateTime.Now);
            _logger.LogInformation("Hello, this is the index!");
            return _context.WoMasCampaigns.ToList();
        }

        [HttpPut("orders")]
        [RequestSizeLimit(100_000_000)]
        //[RequestSizeLimit(10)]
        public async Task<ActionResult<IEnumerable<WO_MAS_CAMPAIGN>>> PickingPremiumCampaign([FromBody] OrderCampaign orderCampaigns)
        {

            return Ok();

        }

        [HttpPost("post")]
        [RequestSizeLimit(100_000_000)]
        //[RequestSizeLimit(10)]
        public async Task<ActionResult<IEnumerable<WO_MAS_CAMPAIGN>>> post([FromBody] OrderCampaign orderCampaigns)
        {

            return Ok();

        }
    }
}