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
        string password) : base(personId, firstName, lastName, email, password)
    { 
        LogClientCreated();
    }

    public static Client Create(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        return new(
            PersonId.CreateUnique(),
            firstName,
            lastName,
            email,
            password
        );
    }

    private void LogClientCreated()
    {
        string log = "Client created:";
        log += $"\n\tClient Id: {Id.Value.ToString()}";
        log += $"\n\tFirst name: {FirstName}";
        log += $"\n\tLast name: {LastName}";
        log += $"\n\tEmail: {Email}";
        log += $"\n\tPassword: {Password}";
        Console.WriteLine(log);
    }
}