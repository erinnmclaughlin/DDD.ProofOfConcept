using Ardalis.Specification.EntityFrameworkCore;
using DDD.ProofOfConcept.Application.UserManagement.Entities;
using DDD.ProofOfConcept.Application.UserManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.ProofOfConcept.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
