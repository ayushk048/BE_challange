using Microsoft.AspNetCore.Http.Features;
using System.Net;

namespace _Diabetes_BE_challenge.CustomException
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string? message) : base(message)
        {
        }
    }
}
