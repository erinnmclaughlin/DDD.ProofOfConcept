using DDD.ProofOfConcept.Application.CustomerManagement.Repositories;
using DDD.ProofOfConcept.Application.UserManagement.Repositories;
using DDD.ProofOfConcept.Infrastructure.DataAccess.CustomerManagement;
using DDD.ProofOfConcept.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.ProofOfConcept.Infrastructure.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
