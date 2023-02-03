using DeliveryCompany.Domain.Common;
using DeliveryCompany.Domain.Common.ValueObjects;

namespace DeliveryCompany.Domain.Clients;

public sealed class Client : Person
{
    public string HashedCode { get; set; }
    public string CodeSalt { get; set; }
    public Client(
        PersonId personId,
        string firstName,
        string lastName,
        string email,
        string passwordHash,
        string salt,
        string hashedCode,
        string codeSalt) : base(personId, firstName, lastName, email, passwordHash, salt)
    { 
        LogClientCreated();
        HashedCode = hashedCode;
        CodeSalt = codeSalt;
    }

    public static Client Create(
        string firstName,
        string lastName,
        string email,
        string password,
        string salt,
        string hashedCode,
        string codeSalt)
    {
        return new(
            PersonId.CreateUnique(),
            firstName,
            lastName,
            email,
            password, 
            salt,
            hashedCode,
            codeSalt
        );
    }

    private void LogClientCreated()
    {
        string log = "Client created:";
        log += $"\n\tClient Id: {Id.Value.ToString()}";
        log += $"\n\tFirst name: {FirstName}";
        log += $"\n\tLast name: {LastName}";
        log += $"\n\tEmail: {Email}";
        Console.WriteLine(log);
    }
}