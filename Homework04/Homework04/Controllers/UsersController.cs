using Homework04.Models.Controller;
using Homework04.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework04.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IService<UserDto> _service;

        public UsersController(IService<UserDto> service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string searchTerm)
        {
            return Ok(_service.Search(searchTerm));
        }

        [HttpGet()]
        public IActionResult GetSkip([FromQuery] int skip, int take)
        {
            return Ok(_service.Get(skip, take));
        }

        [HttpPost()]
        public IActionResult Add([FromBody] UserDto User)
        {
            _service.Add(User);
            return Ok();
        }

        [HttpPut()]
        public IActionResult Update([FromBody] UserDto User)
        {
            _service.Delete(User);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_service.Get(id));
        }
    }
}
