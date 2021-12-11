using DDD.ProofOfConcept.Application.Common;
using DDD.ProofOfConcept.Application.CustomerManagement.Entities;
using DDD.ProofOfConcept.Application.CustomerManagement.Repositories;
using DDD.ProofOfConcept.Domain.CustomerManagement.ValueObjects;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.ProofOfConcept.Application.CustomerManagement.Commands
{
    public static class RegisterCustomer
    {
        public class Command : IRequest<CustomerDetail>
        {
            public string? CompanyName { get; set; }
            public string? City { get; set; }
            public string? Region { get; set; }
            public string? Country { get; set; }

            public bool Validate() => new Validator().Validate(this).IsValid;
        }

        public class Handler : IRequestHandler<Command, CustomerDetail>
        {
            private readonly ICustomerRepository _customerRepo;
            private readonly ICurrentUserService _currentUserService;

            public Handler(ICustomerRepository customerRepo, ICurrentUserService currentUserService)
            {
                _customerRepo = customerRepo;
                _currentUserService = currentUserService;
            }

            public async Task<CustomerDetail> Handle(Command request, CancellationToken cancellationToken)
            {
                _currentUserService.EnsureLoggedIn();

                if (!request.Validate())
                    throw new ArgumentException("Invalid request.", nameof(request));

                // Create objects
                var location = new Location(request.City, request.Region, request.Country);
                var customer = new CustomerDetail(request.CompanyName!, location);

                // Record registration event in audit trail
                customer.Record(new CustomerRegistered(customer, _currentUserService.User!.Id));

                // Save
                await _customerRepo.AddAsync(customer, cancellationToken);

                return customer;
            }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company name is required.");
                RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required.");
            }
        }
    }
}
