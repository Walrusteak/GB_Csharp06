using Microsoft.AspNetCore.Mvc;

namespace Homework02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(null);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update([FromRoute] int id)
        {
            return Ok();
        }
    }
}
