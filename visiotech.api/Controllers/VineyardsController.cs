using Microsoft.AspNetCore.Mvc;
using visiotech.application.Application;
using visiotech.application.Interfaces;

namespace visiotech.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VineyardsController : ControllerBase
    {
        private readonly IVineyardApp _vineyardApp;

        public VineyardsController(IVineyardApp vineyardApp)
        {
            _vineyardApp = vineyardApp;
        }

        [HttpGet("managers")]
        public async Task<ActionResult> GetVineyardManager()
        {
            try
            {
                var mData = await _vineyardApp.GetVineyardManager();
                return Ok(mData);
            }
            catch (Exception e)
            {
                var Errors = new List<string>() { e.Message };
                return BadRequest(new { message = Errors });
            }
        }
    }
}
