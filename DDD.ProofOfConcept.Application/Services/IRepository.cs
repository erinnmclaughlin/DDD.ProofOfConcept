using Ardalis.Specification;
using DDD.ProofOfConcept.Domain.Common;

namespace DDD.ProofOfConcept.Application.Services
{
    public interface IRepository<T> : IRepositoryBase<T> where T : DomainObject
    {
    }
}
