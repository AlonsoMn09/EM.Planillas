using EM.Planilla.Application.Features.Employee.DTO;
using EM.Planilla.Application.Features.Employee.Ports;
using Microsoft.AspNetCore.Mvc;

namespace EM.Planilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseApiController
    {
        private readonly EmployeeUseCases _employeeUseCases;
        public EmployeeController(EmployeeUseCases employeeUseCases)
        {
            _employeeUseCases = employeeUseCases;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeRequest request)
        {
            var result = await _employeeUseCases.create.ExecuteAsync(request);
            return HandlerResult(result);
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ListEmployeeRequest request)
        {
            var result = await _employeeUseCases.list.ExecuteAsync(request);
            return HandlerResult(result);
        }
    }
}
