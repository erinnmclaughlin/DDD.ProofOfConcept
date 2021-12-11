using Ardalis.Specification.EntityFrameworkCore;
using DDD.ProofOfConcept.Application.CustomerManagement.Entities;
using DDD.ProofOfConcept.Application.CustomerManagement.Repositories;

namespace DDD.ProofOfConcept.Infrastructure.DataAccess.CustomerManagement
{
    public class CustomerRepository : RepositoryBase<CustomerDetail>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
