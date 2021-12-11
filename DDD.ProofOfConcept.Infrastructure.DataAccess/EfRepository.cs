using Ardalis.Specification.EntityFrameworkCore;
using DDD.ProofOfConcept.Application.Services;
using DDD.ProofOfConcept.Domain.Common;

namespace DDD.ProofOfConcept.Infrastructure.DataAccess
{
    public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : DomainObject
    {
        public EfRepository(AppDbContext context) : base(context)
        {
        }
    }
}
