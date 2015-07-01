using System;

namespace SubcutaneousTestsPresentation.Domain
{
    public interface IDateTimeProvider
    {
        DateTimeOffset Now();
    }
}