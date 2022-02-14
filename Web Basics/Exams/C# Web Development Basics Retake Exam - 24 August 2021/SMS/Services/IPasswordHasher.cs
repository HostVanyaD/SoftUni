namespace SMS.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
