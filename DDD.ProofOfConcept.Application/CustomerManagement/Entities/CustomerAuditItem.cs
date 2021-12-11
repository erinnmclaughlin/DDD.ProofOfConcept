using DDD.ProofOfConcept.Domain.Common;
using System;

namespace DDD.ProofOfConcept.Application.CustomerManagement.Entities
{
    public class CustomerAuditItem : DomainObject
    {
        public string Description { get; private set; }
        public Guid UserId { get; private set; }

        public DateTimeOffset Timestamp { get; private set; }

        public CustomerAuditItem(string description, Guid userId)
        {
            Description = description;
            UserId = userId;

            Timestamp = DateTimeOffset.Now;

        }
    }
}
