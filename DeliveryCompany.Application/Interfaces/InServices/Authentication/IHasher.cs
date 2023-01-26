namespace DeliveryCompany.Application.Interfaces.InServices.Authentication;

public interface IHasher
{
    public (string hash, string salt) HashPassword(string password);
    public bool PasswordVerifier(string password, string saltBase, string storedHash);
}