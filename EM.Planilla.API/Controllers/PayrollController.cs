using EM.Planilla.Application.Features.Loans.DTO;
using EM.Planilla.Application.Features.Loans.Ports;
using EM.Planilla.Application.Features.Payroll.DTO;
using EM.Planilla.Application.Features.Payroll.Ports;
using Microsoft.AspNetCore.Mvc;

namespace EM.Planilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : BaseApiController
    {
        private readonly PayrollUseCases _payrollUseCases;
        public PayrollController(PayrollUseCases payrollUseCases)
        {
            _payrollUseCases = payrollUseCases;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePayrollRequest request)
        {
            var result = await _payrollUseCases.create.ExecuteAsync(request);
            return HandlerResult(result);
        }        
    }
}
