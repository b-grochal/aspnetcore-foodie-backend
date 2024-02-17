using System.Collections.Generic;

namespace Foodie.Common.Exceptions
{
    public sealed class ValidationFailureException : AppException
    {
        public ValidationFailureException(IReadOnlyDictionary<string, string[]> errorsDictionary) : base("Validation failure")
        {
            ErrorsDictionary = errorsDictionary;
        } 

        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
    }
}
