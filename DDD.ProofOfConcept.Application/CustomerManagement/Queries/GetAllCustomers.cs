using DDD.ProofOfConcept.Application.Common;
using DDD.ProofOfConcept.Application.CustomerManagement.Entities;
using DDD.ProofOfConcept.Application.CustomerManagement.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.ProofOfConcept.Application.CustomerManagement.Queries
{
    public class GetAllCustomers
    {
        public record Query() : IRequest<IList<CustomerDetail>>;

        public class Handler : IRequestHandler<Query, IList<CustomerDetail>>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly ICurrentUserService _currentUserService;

            public Handler(ICustomerRepository customerRepository, ICurrentUserService currentUserService)
            {
                _customerRepository = customerRepository;
                _currentUserService = currentUserService;
            }

            public async Task<IList<CustomerDetail>> Handle(Query request, CancellationToken cancellationToken)
            {
                _currentUserService.EnsureLoggedIn();
                return await _customerRepository.ListAsync(cancellationToken);
            }
        }

    }
}
