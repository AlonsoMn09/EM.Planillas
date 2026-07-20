using EM.Planilla.Application.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EM.Planilla.API.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IActionResult HandlerResult(Result result)
        {
            if (result.IsSuccess) return Ok(result);

            if (result.Errors.Any())
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    result.Errors,
                    TimeSpan = DateTime.Now
                });
            }

            return BadRequest(result);
        }
    }
}
