using DDD.ProofOfConcept.Application.CustomerManagement.Entities;
using DDD.ProofOfConcept.Application.CustomerManagement.Specifications;
using DDD.ProofOfConcept.Application.Services;
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
            private readonly IRepository<CustomerDetail> _customerRepository;

            public Handler(ICurrentUserService currentUserService, IRepository<CustomerDetail> customerRepo)
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
