using Microsoft.AspNetCore.Mvc;
using visiotech.application.Interfaces;

namespace visiotech.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrapesController : ControllerBase
    {
        private readonly IGrapeApp _grapeApp;
        public GrapesController(IGrapeApp grapeApp)
        {
            _grapeApp = grapeApp;
        }
        
        [HttpGet("area")]
        public async Task<ActionResult> GetGrapeByArea()
        {
            try
            {
                var mData = await _grapeApp.GetGrapeByArea();
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
