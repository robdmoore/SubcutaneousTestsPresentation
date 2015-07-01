using System;
using JetBrains.Annotations;

namespace SubcutaneousTestsPresentation.Domain
{
    public static class ObjectConstructorHelpers
    {
        public static string OrThrowIfMissing(this string param, [InvokerParameterName]string paramName)
        {
            if (string.IsNullOrWhiteSpace(param))
                throw new ArgumentOutOfRangeException(paramName, "String is null or empty");
            return param;
        }

        public static int OrThrowIfMissing(this int? param, [InvokerParameterName]string paramName)
        {
            if (!param.HasValue)
                throw new ArgumentOutOfRangeException(paramName, "Integer value not specified");
            return param.Value;
        }

        public static T OrThrowIfMissing<T>(this T param, [InvokerParameterName]string paramName) where T : class
        {
            if (param == null)
                throw new ArgumentNullException(paramName);

            return param;
        }

        public static int OrThrowIfNotBetween(this int param, int min, int max, [InvokerParameterName] string paramName)
        {
            if (param < min || param > max)
                throw new ArgumentOutOfRangeException(paramName, string.Format("Should be integer between {0} and {1}", min, max));

            return param;
        }
    }
}