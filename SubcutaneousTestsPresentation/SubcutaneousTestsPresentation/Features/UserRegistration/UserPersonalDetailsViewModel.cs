using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using SubcutaneousTestsPresentation.Domain.Users;

namespace SubcutaneousTestsPresentation.Features.UserRegistration
{
    public class UserPersonalDetailsViewModel
    {
        public UserPersonalDetailsViewModel() {}

        public UserPersonalDetailsViewModel(PersonalDetails personalDetails)
        {
            Title = personalDetails.Title;
            FirstName = personalDetails.FirstName;
            LastName = personalDetails.LastName;
            Email = personalDetails.Email;
            Telephone = personalDetails.Telephone;
            Fax = personalDetails.Fax;
        }

        [Required]
        [RegularExpression(Validation.TitleRegex, ErrorMessage = Validation.TitleCriteriaText)]
        public string Title { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        [Email]
        public string Email { get; set; }
        [Required]
        [RegularExpression(Validation.PhoneRegex, ErrorMessage = Validation.PhoneCriteriaText)]
        public string Telephone { get; set; }
        [RegularExpression(Validation.PhoneRegex, ErrorMessage = Validation.PhoneCriteriaText)]
        public string Fax { get; set; }
    }
}