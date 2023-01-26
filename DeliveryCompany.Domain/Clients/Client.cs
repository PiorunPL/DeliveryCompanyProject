using DeliveryCompany.Domain.Common;
using DeliveryCompany.Domain.Common.ValueObjects;

namespace DeliveryCompany.Domain.Clients;

public sealed class Client : Person
{
    public Client(
        PersonId personId,
        string firstName,
        string lastName,
        string email,
        string passwordHash,
        string salt) : base(personId, firstName, lastName, email, passwordHash, salt)
    { 
        LogClientCreated();
    }

    public static Client Create(
        string firstName,
        string lastName,
        string email,
        string password,
        string salt)
    {
        return new(
            PersonId.CreateUnique(),
            firstName,
            lastName,
            email,
            password, 
            salt
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