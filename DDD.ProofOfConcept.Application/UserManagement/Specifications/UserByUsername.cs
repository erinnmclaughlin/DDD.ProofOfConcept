using Ardalis.Specification;
using DDD.ProofOfConcept.Application.UserManagement.Entities;
using System.Linq;

namespace DDD.ProofOfConcept.Application.UserManagement.Specifications
{
    internal class UserByUsername : Specification<User>, ISingleResultSpecification<User>
    {
        public UserByUsername(string username)
        {
            Query.Where(user => user.Username.ToUpper() == username.ToUpper());
        }
    }
}
