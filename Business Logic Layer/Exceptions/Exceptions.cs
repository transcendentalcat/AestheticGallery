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

    public class PhotoNotFoundException : Exception
    {
        public PhotoNotFoundException(string message) : base(message)
        {
        }
    }

    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(string message) : base(message)
        {
        }
    }

    public class AlbumNotFoundException : Exception
    {
        public AlbumNotFoundException(string message) : base(message)
        {
        }
    }

    public class CommentNotFoundException : Exception
    {
        public CommentNotFoundException(string message) : base(message)
        {
        }
    }
}
