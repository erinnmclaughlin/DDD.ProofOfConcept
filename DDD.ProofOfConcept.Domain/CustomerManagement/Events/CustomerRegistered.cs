using DDD.ProofOfConcept.Domain.CustomerManagement.Entities;
using MediatR;

namespace DDD.ProofOfConcept.Domain.CustomerManagement.Events
{
    public class CustomerRegistered : INotification
    {
        public Customer Customer { get; }

        public CustomerRegistered(Customer customer)
        {
            Customer = customer;
        }
    }
}
