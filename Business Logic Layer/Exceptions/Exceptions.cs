using System;


namespace BusinessLogicLayer.Exceptions
{
    public class ValidationException : Exception
    {
        public string Property { get; }
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
