using System.Net;

namespace ChronosApi.Services.Exceptions
{
    public class ConflictException : BaseException
    {
        public ConflictException(string message) : base("HSO-001", message, HttpStatusCode.Conflict, StatusCodes.Status409Conflict, null, DateTimeOffset.UtcNow, null)
        {}
    }
}