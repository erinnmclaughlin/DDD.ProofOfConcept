using DDD.ProofOfConcept.Domain.CustomerManagement.Entities;
using DDD.ProofOfConcept.Domain.CustomerManagement.ValueObjects;
using System.Collections.Generic;

namespace DDD.ProofOfConcept.Application.CustomerManagement.Entities
{
    public class CustomerDetail : Customer
    {
        private readonly List<CustomerAuditItem> _auditTrail = new();
        public IReadOnlyCollection<CustomerAuditItem> AuditTrail => _auditTrail.AsReadOnly();

        protected CustomerDetail()
        {
        }

        public CustomerDetail(string companyName, Location location) : base(companyName, location)
        {
        }

        public void Record(CustomerAuditItem auditItem)
        {
            _auditTrail.Add(auditItem);
        }
    }
}
