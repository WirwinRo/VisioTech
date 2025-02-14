using Microsoft.AspNetCore.Mvc;
using visiotech.application.Dtos;
using visiotech.application.Interfaces;

namespace visiotech.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerApp _managerApp;

        public ManagersController(IManagerApp managerApp)
        {
            _managerApp = managerApp;
        }

        [HttpGet("ids")]
        public async Task<ActionResult> GetIds()
        {
            try
            {
                var mData = await _managerApp.List();
                return Ok(mData);
            }
            catch (Exception e)
            {
                var Errors = new List<string>() { e.Message };
                return BadRequest(new { message = Errors });
            }            
        }

        [HttpGet("taxnumbers")]
        public async Task<ActionResult> GetManagersOrderbyName([FromQuery] bool sorted = true)
        {
            try
            {
                IEnumerable<ManagerDto> mData;
                if (sorted)
                {
                    mData = (await _managerApp.List()).OrderBy(t => t.Name);
                }
                else
                {
                    mData = await _managerApp.List();
                }

                return Ok(mData);
            }
            catch (Exception e)
            {
                var Errors = new List<string>() { e.Message };
                return BadRequest(new { message = Errors });
            }
        }

        [HttpGet("totalarea")]
        public async Task<ActionResult> GetManagerArea()
        {
            try
            {
                var mData = await _managerApp.GetManagerArea();
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
