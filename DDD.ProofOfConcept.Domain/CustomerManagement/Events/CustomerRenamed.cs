using DDD.ProofOfConcept.Domain.CustomerManagement.Entities;
using MediatR;

namespace DDD.ProofOfConcept.Domain.CustomerManagement.Events
{
    public class CustomerRenamed : INotification
    {
        public Customer Customer { get; }

        public CustomerRenamed(Customer customer)
        {
            Customer = customer;
        }
    }
}
