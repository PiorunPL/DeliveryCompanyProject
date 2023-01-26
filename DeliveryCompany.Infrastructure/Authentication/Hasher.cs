using System.Security.Cryptography;
using DeliveryCompany.Application.Interfaces.InServices.Authentication;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DeliveryCompany.Infrastructure.Authentication;

public class Hasher : IHasher
{
    private readonly string pepper = "super-secret-pep";
    
    public (string hash, string salt) HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
        string saltConverted = Convert.ToBase64String(salt);

        string hashed = Hash(password, salt);
         
        return (hashed, saltConverted);
    }

    public bool PasswordVerifier(string password, string saltBase, string storedHash)
    {
        byte[] salt = Convert.FromBase64String(saltBase);

        string hashedPassword = Hash(password, salt);
        
        return hashedPassword.Equals(storedHash);
    }

    private string Hash(string password, byte[] salt)
    {
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password + pepper,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: 1000000,
            numBytesRequested: 512 / 8));
    }
}