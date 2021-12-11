using DDD.ProofOfConcept.Application.UserManagement.Entities;

namespace DDD.ProofOfConcept.Application.Services
{
    public interface ICurrentUserService
    {
        User? User { get; }
        void Login(User user);
        void Logout();

        void EnsureLoggedIn();
    }
}
