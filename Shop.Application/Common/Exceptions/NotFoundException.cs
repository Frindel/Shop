namespace Shop.Application.Common.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string description) : base(description)
        {
        }
    }
}
