using apicampaign.Models;
using Microsoft.AspNetCore.Mvc;

namespace apicampaign.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly onlinecampaignContext _context;

        public CampaignController(onlinecampaignContext context)
        {
            _context = context;
        }
        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WO_MAS_CAMPAIGN>>> GetCampaign()
        {
            return _context.WoMasCampaigns.ToList();
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<WO_MAS_CAMPAIGN>>> PickingPremiumCampaign()
        {
            //[FromBody]PaymentRequest request

            return BadRequest();

        }
    }
}