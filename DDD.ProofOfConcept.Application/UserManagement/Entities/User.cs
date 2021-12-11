using DDD.ProofOfConcept.Domain.Common;

namespace DDD.ProofOfConcept.Application.UserManagement.Entities
{
    public class User : DomainObject
    {
        public string Username { get; private set; } = null!;

        private User()
        {
        }

        public User(string username)
        {
            Username = username;
        }
    }
}
