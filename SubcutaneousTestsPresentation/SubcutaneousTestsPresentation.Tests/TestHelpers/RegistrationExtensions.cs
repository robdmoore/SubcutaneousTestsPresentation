using Autofac;
using Autofac.Builder;

namespace SubcutaneousTestsPresentation.Tests.TestHelpers
{
    public static class RegistrationExtensions
    {
        public static IRegistrationBuilder<TLimit, TActivatorData, TStyle> InstancePerTestRun
            <TLimit, TActivatorData, TStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TStyle> registration,
                params object[] lifetimeScopeTags)
        {
            return registration.InstancePerRequest(lifetimeScopeTags);
        }
    }
}
