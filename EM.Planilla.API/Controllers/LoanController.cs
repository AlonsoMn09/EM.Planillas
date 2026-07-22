using EM.Planilla.Application.Features.Loans.DTO;
using EM.Planilla.Application.Features.Loans.Ports;
using Microsoft.AspNetCore.Mvc;

namespace EM.Planilla.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : BaseApiController
    {
        private readonly LoanUseCases _loanUseCases;
        public LoanController(LoanUseCases loanUseCases)
        {
            _loanUseCases = loanUseCases;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLoanRequest request)
        {
            var result = await _loanUseCases.create.ExecuteAsync(request);
            return HandlerResult(result);
        }
    }
}
