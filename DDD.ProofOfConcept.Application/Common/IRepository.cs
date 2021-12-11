using Ardalis.Specification;
using DDD.ProofOfConcept.Domain.Common;

namespace DDD.ProofOfConcept.Application.Common
{
    public interface IRepository<T> : IRepositoryBase<T> where T : DomainObject
    {
    }
}
