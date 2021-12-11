using System;

namespace DDD.ProofOfConcept.Domain.Common
{
    public abstract class DomainObject
    {
        public Guid Id { get; private set; }

        public DomainObject()
        {
            Id = Guid.NewGuid();
        }
    }
}
