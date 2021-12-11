using DDD.ProofOfConcept.Domain.CustomerManagement.Entities;
using MediatR;

namespace DDD.ProofOfConcept.Domain.CustomerManagement.Events
{
    public class CustomerRelocated : INotification
    {
        public Customer Customer { get; }

        public CustomerRelocated(Customer customer)
        {
            Customer = customer;
        }
    }
}
