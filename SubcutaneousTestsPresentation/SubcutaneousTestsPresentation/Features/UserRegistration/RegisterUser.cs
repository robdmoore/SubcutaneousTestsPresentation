using System.Threading.Tasks;
using SubcutaneousTestsPresentation.Domain;
using SubcutaneousTestsPresentation.Domain.Users;
using SubcutaneousTestsPresentation.Infrastructure.Commands;
using SubcutaneousTestsPresentation.Infrastructure.Database;

namespace SubcutaneousTestsPresentation.Features.UserRegistration
{
    public class RegisterUser : ICommand
    {
        public PostalAddress Address { get; private set; }
        public PersonalDetails PersonalDetails { get; private set; }
        public Password Password { get; private set; }
        public string LoginUrl { get; private set; }

        public RegisterUser(PostalAddress address, PersonalDetails personalDetails, Password password, string loginUrl)
        {
            Address = address;
            PersonalDetails = personalDetails;
            Password = password;
            LoginUrl = loginUrl;
        }
    }

    public class RegisterTeamHandler : ICommandHandler<RegisterUser>
    {
        private readonly SubcutaneousTestsPresentationDbContext _context;
        private readonly IDateTimeProvider _dateTimeProvider;

        public RegisterTeamHandler(SubcutaneousTestsPresentationDbContext context, IDateTimeProvider dateTimeProvider)
        {
            _context = context;
            _dateTimeProvider = dateTimeProvider;
        }

        public Task ExecuteAsync(RegisterUser command)
        {
            var team = new User(_dateTimeProvider, command.PersonalDetails, command.Address, command.Password);
            _context.Users.Add(team);

            // todo: Send email

            return _context.SaveChangesAsync();
        }
    }
}