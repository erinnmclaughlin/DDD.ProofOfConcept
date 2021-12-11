using DDD.ProofOfConcept.Application.CustomerManagement.Commands;
using DDD.ProofOfConcept.Application.CustomerManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.ProofOfConcept.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterCustomer.Command command, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _mediator.Send(command, cancellationToken);
                return Ok(customer);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpGet("{customerId}/audit-trail")]
        public async Task<IActionResult> GetAuditTrail(Guid customerId, CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetCustomerAuditTrail.Query(customerId);
                var auditTrail = await _mediator.Send(query, cancellationToken);
                return Ok(auditTrail);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
