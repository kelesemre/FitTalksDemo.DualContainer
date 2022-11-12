using System.Net;

namespace FitTalksDemo.DualContainer.Common.Exceptions
{
    public class NotFoundException : DomainException
    {
        public NotFoundException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.NotFound;
        }
        public NotFoundException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
