using System.Threading.Tasks;
using Backend.Business.Customer.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Web.Controllers
{
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        private readonly IMediator _mediator;

        public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<ActionResult> RegisterCustomer(RegisterCustomerCommand registerCustomerCommand)
        {
            var result = await _mediator.Send(registerCustomerCommand);

            return Ok(result);
        }
    }
}