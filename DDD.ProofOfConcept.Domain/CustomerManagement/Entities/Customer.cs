using DDD.ProofOfConcept.Domain.Common;
using DDD.ProofOfConcept.Domain.CustomerManagement.ValueObjects;
using System;

namespace DDD.ProofOfConcept.Domain.CustomerManagement.Entities
{
    public class Customer : DomainObject
    {
        public string CompanyName { get; set; } = null!;
        public Location Location { get; set; } = null!;

        protected Customer()
        {
        }

        public Customer(string companyName, Location location)
        {
            CompanyName = companyName;
            Location = location;
        }

        public void Rename(string companyName)
        {
            if (string.IsNullOrWhiteSpace(companyName))
                throw new ArgumentNullException(nameof(companyName));

            CompanyName = companyName;
        }

        public void Relocate(string city, string region, string country)
        {
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentNullException(nameof(country));

            Location = new Location(city, region, country);
        }
    }
}
