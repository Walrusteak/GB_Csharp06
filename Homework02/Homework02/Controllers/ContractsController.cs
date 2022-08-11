using Microsoft.AspNetCore.Mvc;

namespace Homework02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(null);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(null);
        }

        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpPut("update/{id}")]
        public IActionResult Update([FromRoute] int id)
        {
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok();
        }
    }
}
