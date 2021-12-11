using DDD.ProofOfConcept.Application.Common;
using DDD.ProofOfConcept.Domain.CustomerManagement.Entities;
using System;

namespace DDD.ProofOfConcept.Application.CustomerManagement.Entities
{
    public class CustomerAuditItem : AuditItem
    {
        public Guid CustomerId { get; private set; }

        protected CustomerAuditItem()
        {
        }

        public CustomerAuditItem(Customer customer, AuditType auditType, string description, Guid userId)
            : base(auditType, description, userId)
        {
            CustomerId = customer.Id;
        }
    }

    public class CustomerRegistered : CustomerAuditItem
    {
        private CustomerRegistered()
        {
        }

        public CustomerRegistered(Customer customer, Guid userId)
            : base(customer, AuditType.Create, "New customer registered.", userId)
        {
        }
    }
}
