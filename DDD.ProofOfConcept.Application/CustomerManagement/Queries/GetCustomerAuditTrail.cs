using DDD.ProofOfConcept.Application.Common;
using DDD.ProofOfConcept.Application.CustomerManagement.Entities;
using DDD.ProofOfConcept.Application.CustomerManagement.Repositories;
using DDD.ProofOfConcept.Application.CustomerManagement.Specifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.ProofOfConcept.Application.CustomerManagement.Queries
{
    public class GetCustomerAuditTrail
    {
        public record Query(Guid CustomerId) : IRequest<IReadOnlyCollection<CustomerAuditItem>>;

        public class Handler : IRequestHandler<Query, IReadOnlyCollection<CustomerAuditItem>>
        {
            private readonly ICurrentUserService _currentUserService;
            private readonly ICustomerRepository _customerRepository;

            public Handler(ICurrentUserService currentUserService, ICustomerRepository customerRepo)
            {
                _currentUserService = currentUserService;
                _customerRepository = customerRepo;
            }

            public async Task<IReadOnlyCollection<CustomerAuditItem>> Handle(Query request, CancellationToken cancellationToken)
            {
                _currentUserService.EnsureLoggedIn();

                var spec = new CustomerAuditTrailSpec(request.CustomerId);
                return await _customerRepository.GetBySpecAsync(spec, cancellationToken);
            }
        }
    }
}
