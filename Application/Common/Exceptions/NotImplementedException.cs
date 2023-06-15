namespace Application.Common.CustomExceptionMiddleware
{
    public class NotImplementedException : Exception
    {
        public NotImplementedException(string message) : base(message)
        {
        }
    }
}
