namespace SubcutaneousTestsPresentation.Domain.Users
{
    public class PostalAddress
    {
        public string Line1 { get; protected set; }
        public string Line2 { get; protected set; }
        public string Line3 { get; protected set; }

        public string City { get; protected set; }
        public string State { get; protected set; }
        public string Postcode { get; protected set; }
        public string Country { get; protected set; }

        protected PostalAddress() { }

        public PostalAddress(string line1, string line2, string line3, string city, string state, string postcode, string country)
        {
            Line1 = line1.OrThrowIfMissing("line1");
            Line2 = line2;
            Line3 = line3;
            City = city.OrThrowIfMissing("city");
            State = state;
            Postcode = postcode.OrThrowIfMissing("postcode");
            Country = country.OrThrowIfMissing("country");
        }
    }
}