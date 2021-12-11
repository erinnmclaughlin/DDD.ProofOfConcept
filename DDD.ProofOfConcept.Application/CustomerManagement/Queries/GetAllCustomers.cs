using DDD.ProofOfConcept.Application.Services;
using DDD.ProofOfConcept.Domain.CustomerManagement.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.ProofOfConcept.Application.CustomerManagement.Queries
{
    public class GetAllCustomers
    {
        public record Query() : IRequest<IList<Customer>>;

        public class Handler : IRequestHandler<Query, IList<Customer>>
        {
            private readonly IRepository<Customer> _customerRepository;
            private readonly ICurrentUserService _currentUserService;

            public Handler(IRepository<Customer> customerRepository, ICurrentUserService currentUserService)
            {
                _customerRepository = customerRepository;
                _currentUserService = currentUserService;
            }

            public async Task<IList<Customer>> Handle(Query request, CancellationToken cancellationToken)
            {
                _currentUserService.EnsureLoggedIn();

                return await _customerRepository.ListAsync(cancellationToken);
            }
        }

    }
}
