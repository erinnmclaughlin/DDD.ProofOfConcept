using DDD.ProofOfConcept.Application.UserManagement.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.ProofOfConcept.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUser.Command command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _mediator.Send(command, cancellationToken);
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser.Command command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _mediator.Send(command, cancellationToken);
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
