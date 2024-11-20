using System.Net;

namespace ChronosApi.Services.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base("HSO-002", message, HttpStatusCode.NotFound, StatusCodes.Status404NotFound, null, DateTimeOffset.UtcNow, null)
        {}
    }
}
