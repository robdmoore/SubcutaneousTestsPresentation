using System.ComponentModel.DataAnnotations;
using SubcutaneousTestsPresentation.Domain.Users;

namespace SubcutaneousTestsPresentation.Features.UserRegistration
{
    public class UserRegistrationViewModel
    {
        public UserRegistrationViewModel()
        {
            PostalAddress = new UserPostalAddressViewModel();
            PersonalDetails = new UserPersonalDetailsViewModel();
        }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = Validation.PasswordCriteriaText)]
        [RegularExpression(Validation.PasswordRegex, ErrorMessage = Validation.PasswordCriteriaText)]
        public string Password { get; set; }

        [Required]
        [DataAnnotationsExtensions.EqualTo("Password", ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public UserPersonalDetailsViewModel PersonalDetails { get; set; }
        public UserPostalAddressViewModel PostalAddress { get; set; }

        public RegisterUser ToCommand(string loginUrl)
        {
            var pa = PostalAddress;
            var pd = PersonalDetails;

            return new RegisterUser(
                new PostalAddress(pa.AddressLine1, pa.AddressLine2, pa.AddressLine3, pa.City, pa.State, pa.Postcode, pa.Country),
                new PersonalDetails(pd.Title, pd.FirstName, pd.LastName, pd.Email, pd.Telephone, pd.Fax),
                new Password(Password),
                loginUrl
            );
        }

    }
}