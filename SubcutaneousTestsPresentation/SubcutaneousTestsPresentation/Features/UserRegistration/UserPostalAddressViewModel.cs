using System.ComponentModel.DataAnnotations;
using SubcutaneousTestsPresentation.Domain.Users;

namespace SubcutaneousTestsPresentation.Features.UserRegistration
{
    public class UserPostalAddressViewModel
    {
        public UserPostalAddressViewModel() {}

        public UserPostalAddressViewModel(PostalAddress address)
        {
            AddressLine1 = address.Line1;
            AddressLine2 = address.Line2;
            AddressLine3 = address.Line3;
            City = address.City;
            State = address.State;
            Postcode = address.Postcode;
            Country = address.Country;
        }

        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        [Required]
        public string City { get; set; }
        public string State { get; set; }
        [Required]
        public string Postcode { get; set; }
        [Required]
        public string Country { get; set; }
    }
}