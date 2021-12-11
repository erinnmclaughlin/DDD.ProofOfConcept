using DDD.ProofOfConcept.Application.Services;
using DDD.ProofOfConcept.Application.UserManagement.Entities;
using DDD.ProofOfConcept.Application.UserManagement.Specifications;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.ProofOfConcept.Application.UserManagement.Commands
{
    public class RegisterUser
    {
        public class Command : IRequest<User>
        {
            // for simplicity, user registration just requires a unique username (no passwords)
            public string? Username { get; set; }

            public bool Validate() => new Validator().Validate(this).IsValid;
        }

        public class Handler : IRequestHandler<Command, User>
        {
            private readonly ICurrentUserService _currentUserService;
            private readonly IRepository<User> _userRepository;

            public Handler(ICurrentUserService currentUserService, IRepository<User> userRepository)
            {
                _currentUserService = currentUserService;
                _userRepository = userRepository;
            }

            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                // check that registration model is valid
                if (!request.Validate())
                    throw new ArgumentException("Invalid request.", nameof(request));

                // check that username is unique
                if (await _userRepository.GetBySpecAsync(new UserByUsername(request.Username!), cancellationToken) is not null)
                    throw new ArgumentException("Username has already been taken.", nameof(request));

                // create user and add to db
                var user = new User(request.Username!);
                await _userRepository.AddAsync(user, cancellationToken);

                // log user in
                _currentUserService.Login(user);

                // could do things like send confirmation email here, etc.

                // return user
                return user;
            }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Username)
                    .NotEmpty().WithMessage("Username is required.")
                    .MinimumLength(3).WithMessage("Username must be at least 3 characters.")
                    .MaximumLength(20).WithMessage("Username cannot exceed 20 characters.");
            }
        }
    }
}
