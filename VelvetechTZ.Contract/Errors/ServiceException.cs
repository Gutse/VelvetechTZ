using System;

namespace VelvetechTZ.Contract.Errors
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