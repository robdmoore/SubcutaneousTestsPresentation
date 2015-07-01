using System;

namespace SubcutaneousTestsPresentation.Domain
{
    /// <summary>
    /// This exception may be rendered to the end user so it has to include a human-readable message.
    /// </summary>
    public class ClientException : ApplicationException
    {
        public ClientException(string message)
            : base(message.OrThrowIfMissing("message")) { }

        public ClientException(string message, string paramName)
            : base(message.OrThrowIfMissing("message"))
        {
            ParamName = paramName.OrThrowIfMissing("paramName");
        }

        public string ParamName { get; private set; }
    }
}