namespace SubcutaneousTestsPresentation.Domain.Users
{
    public class Password
    {
        internal static int WorkFactor = 10;

        public string Value { get; protected set; }

        protected Password() {}

        public Password(string password)
        {
            Value = BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
        }

        public virtual bool Matches(string password)
        {
            if (password == null)
                return false;
            return BCrypt.Net.BCrypt.Verify(password, Value);
        }
    }
}