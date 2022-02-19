namespace Andreys.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
