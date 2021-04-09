using System;

namespace BookSoft.DAL.Exceptions
{
    public class BadResponseException : Exception
    {
        public bool ResponseMessage { get; set; }
        public BadResponseException(bool responseMessage)
        {
            ResponseMessage = responseMessage;
        }

        public BadResponseException(string message, bool responseMessage) : base(message)
        {
            ResponseMessage = responseMessage;
        }

        public BadResponseException(string message, Exception innerException, bool responseMessage) : base(message, innerException)
        {
            ResponseMessage = responseMessage;
        }

        
    }
}
