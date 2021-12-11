using Ardalis.Specification;
using DDD.ProofOfConcept.Application.CustomerManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.ProofOfConcept.Application.CustomerManagement.Specifications
{
    internal class CustomerAuditTrailSpec : Specification<CustomerDetail, IReadOnlyCollection<CustomerAuditItem>>,
        ISpecification<CustomerDetail, IReadOnlyCollection<CustomerAuditItem>>
    {
        public CustomerAuditTrailSpec(Guid customerId)
        {
            Query.Where(customer => customer.Id == customerId);
            Query.Select(customer => customer.AuditTrail);
        }
    }
}
