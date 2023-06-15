namespace Application.Common.CustomExceptionMiddleware
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
