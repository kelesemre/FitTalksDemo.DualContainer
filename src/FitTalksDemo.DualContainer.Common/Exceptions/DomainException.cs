using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FitTalksDemo.DualContainer.Common.Exceptions
{
    [Serializable]
    public class DomainException : Exception
    {

        public int StatusCode;
        public DomainException()
        {

        }
        public DomainException(string message)
           : base(message)
        {
            this.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
        public DomainException(string message, int errorCode)
            : base(message)
        {
            this.StatusCode = errorCode;
        }
    }
}
