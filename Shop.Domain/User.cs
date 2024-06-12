namespace Shop.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string RefreshToken { get; set; } = null!;

        public bool IsAdmin { get; set; }
    }
}
