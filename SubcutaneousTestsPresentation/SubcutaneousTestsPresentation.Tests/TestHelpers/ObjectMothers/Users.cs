using SubcutaneousTestsPresentation.Tests.TestHelpers.Builders;

namespace SubcutaneousTestsPresentation.Tests.TestHelpers.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static class Users
        {
            public static UserBuilder Default
            {
                get
                {
                    return new UserBuilder();
                }
            }
        }
    }
}
