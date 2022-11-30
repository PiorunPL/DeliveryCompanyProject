using DeliveryCompany.Domain.Common;
using DeliveryCompany.Domain.Common.ValueObjects;

namespace DeliveryCompany.Domain.Client;

public sealed class Client : Person
{
    private Client(
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
        Console.WriteLine($"Client created: \n\tClient Id: {Id.Value}\n\tFirst name: {FirstName}\n\tLast name: {LastName}\n\tEmail: {Email}\n\tPassword: {Password}");
    }
}