using System;
using SubcutaneousTestsPresentation.Domain;

namespace SubcutaneousTestsPresentation.Infrastructure.Time
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset Now()
        {
            return DateTimeOffset.UtcNow;
        }
    }
}