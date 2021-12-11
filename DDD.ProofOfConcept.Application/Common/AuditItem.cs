using DDD.ProofOfConcept.Domain.Common;
using System;

namespace DDD.ProofOfConcept.Application.Common
{
    public enum AuditType { Create, Update, Delete, None }

    public class AuditItem : DomainObject
    {
        public AuditType AuditType { get; private set; }
        public string Description { get; private set; } = null!;
        public DateTimeOffset Timestamp { get; private set; }
        public Guid UserId { get; private set; }

        protected AuditItem()
        {
        }

        public AuditItem(AuditType auditType, string description, Guid userId)
        {
            AuditType = auditType;
            Description = description;
            UserId = userId;

            Timestamp = DateTime.Now;
        }
    }
}
