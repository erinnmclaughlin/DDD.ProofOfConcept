using DDD.ProofOfConcept.Application.Common;
using DDD.ProofOfConcept.Application.CustomerManagement.Entities;

namespace DDD.ProofOfConcept.Application.CustomerManagement.Repositories
{
    public interface ICustomerRepository : IRepository<CustomerDetail>
    {
    }
}
