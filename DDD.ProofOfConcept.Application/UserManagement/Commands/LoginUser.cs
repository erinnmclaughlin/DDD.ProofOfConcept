using DDD.ProofOfConcept.Application.Common;
using DDD.ProofOfConcept.Application.UserManagement.Entities;
using DDD.ProofOfConcept.Application.UserManagement.Repositories;
using DDD.ProofOfConcept.Application.UserManagement.Specifications;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.ProofOfConcept.Application.UserManagement.Commands
{
    public class LoginUser
    {
        public class Command : IRequest<User>
        {
            public string? Username { get; set; }

            public bool Validate() => new Validator().Validate(this).IsValid;
        }

        public class Handler : IRequestHandler<Command, User>
        {
            private readonly ICurrentUserService _currentUserService;
            private readonly IUserRepository _userRepository;

            public Handler(ICurrentUserService currentUserService, IUserRepository userRepository)
            {
                _currentUserService = currentUserService;
                _userRepository = userRepository;
            }

            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!request.Validate())
                    throw new ArgumentException("Invalid request.", nameof(request));

                var spec = new UserByUsername(request.Username!);
                var user = await _userRepository.GetBySpecAsync(spec, cancellationToken);

                if (user is null)
                    throw new ArgumentException("Username was not found.", nameof(request));

                _currentUserService.Login(user);
                return user;
            }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required.");
            }
        }
    }
}
