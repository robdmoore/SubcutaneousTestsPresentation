namespace SubcutaneousTestsPresentation.Domain.Users
{
    public class PersonalDetails
    {
        public string Title { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        public string Email { get; protected set; }

        public string Telephone { get; protected set; }
        public string Fax { get; protected set; }

        public string FullName
        {
            get { return string.Format("{0} {1} {2}", Title, FirstName, LastName); }
        }

        protected PersonalDetails() { }

        public PersonalDetails(string title, string firstName, string lastName, string email, string telephoneNumber, string fax)
        {
            Title = title.OrThrowIfMissing("title");
            FirstName = firstName.OrThrowIfMissing("firstName");
            LastName = lastName.OrThrowIfMissing("lastName");
            Email = email.OrThrowIfMissing("email");
            Telephone = telephoneNumber.OrThrowIfMissing("telephoneNumber");
            Fax = fax;
        }
    }
}