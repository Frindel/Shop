namespace Shop.Application.Interfaces
{
    public interface ITokensGenerator
    {
        public string GenerateAccessTocken(int userId);

        public string GenerateRefreshTocken();
    }
}
