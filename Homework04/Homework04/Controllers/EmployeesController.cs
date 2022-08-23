using Homework04.Models.Controller;
using Homework04.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework04.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IService<EmployeeDto> _service;

        public EmployeesController(IService<EmployeeDto> service)
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
        public IActionResult Add([FromBody] EmployeeDto Employee)
        {
            _service.Add(Employee);
            return Ok();
        }

        [HttpPut()]
        public IActionResult Update([FromBody] EmployeeDto Employee)
        {
            _service.Delete(Employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_service.Get(id));
        }
    }
}
