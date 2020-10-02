using System;

namespace VelvetechTZ.Domain.Errors
{
    public class ServiceException : Exception
    {
        public ServiceError Error { get; set; }

        public ServiceException(ServiceError error)
        {
            Error = error;
        }
    }
}