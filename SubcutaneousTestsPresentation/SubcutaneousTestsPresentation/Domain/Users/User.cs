using System;

namespace SubcutaneousTestsPresentation.Domain.Users
{
    public class User : Entity
    {
        public PersonalDetails PersonalDetails { get; protected set; }
        public PostalAddress PostalAddress { get; protected set; }
        public Password Password { get; protected set; }

        public DateTimeOffset CreatedDate { get; protected set; }
        public DateTimeOffset LastModifiedDate { get; protected set; }
        public bool Active { get; protected set; }

        protected User() {}

        public User(IDateTimeProvider dateTimeProvider, PersonalDetails personalDetails, PostalAddress postalAddress, Password password)
        {

            CreatedDate = dateTimeProvider.Now();
            LastModifiedDate = dateTimeProvider.Now();
            PersonalDetails = personalDetails.OrThrowIfMissing("personalDetails");
            PostalAddress = postalAddress.OrThrowIfMissing("postalAddress");
            Password = password.OrThrowIfMissing("password");
            Active = true;
        }
    }
}