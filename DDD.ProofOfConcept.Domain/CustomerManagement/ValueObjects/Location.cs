namespace DDD.ProofOfConcept.Domain.CustomerManagement.ValueObjects
{
    public class Location
    {
        public string? City { get; }
        public string? Region { get; }
        public string? Country { get; }

        private Location()
        {
        }

        public Location(string? city, string? region, string? country)
        {
            City = city;
            Region = region;
            Country = country;
        }
    }
}
