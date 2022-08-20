using Homework03.Models.Controller;
using Homework03.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework03.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _service;

        public PersonsController(IService<Person> service)
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
        public IActionResult Add([FromBody] Person person)
        {
            _service.Add(person);
            return Ok();
        }

        [HttpPut()]
        public IActionResult Update([FromBody] Person person)
        {
            _service.Delete(person);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_service.Get(id));
        }
    }
}
