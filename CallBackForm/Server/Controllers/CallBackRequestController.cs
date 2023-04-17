using CallBackForm.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CallBackForm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallBackRequestController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CallBackRequest(UserDetails userDetails)
        {
        
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

    }
}
