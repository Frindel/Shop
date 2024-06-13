namespace Shop.Application.Common.Exceptions
{
    public class ForbiddenException : ApplicationException
    {
        public ForbiddenException(string description): base(description) 
        {
        }
    }
}
