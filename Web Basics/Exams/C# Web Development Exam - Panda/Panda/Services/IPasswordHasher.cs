namespace Panda.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
