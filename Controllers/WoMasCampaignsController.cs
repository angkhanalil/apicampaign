using apicampaign.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace apicampaign.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    public class WoMasCampaignsController : ControllerBase
    {
        private readonly onlinecampaignContext _context;

        public WoMasCampaignsController(onlinecampaignContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WO_MAS_CAMPAIGN>>> GetCampaign()
        {
            return _context.WoMasCampaigns.ToList();
        }
    }
}