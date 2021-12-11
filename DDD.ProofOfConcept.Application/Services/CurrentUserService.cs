using DDD.ProofOfConcept.Application.UserManagement.Entities;
using System;

namespace DDD.ProofOfConcept.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public User? User { get; private set; }

        public void EnsureLoggedIn()
        {
            if (User is null)
                throw new UnauthorizedAccessException();
        }

        public void Login(User user)
        {
            User = user;
        }

        public void Logout()
        {
            User = null;
        }
    }
}
