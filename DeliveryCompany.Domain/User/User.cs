using DeliveryCompany.Domain.Common;
using DeliveryCompany.Domain.Common.ValueObjects;

namespace DeliveryCompany.Domain.User;

public sealed class User : Person
{
    private User(
        PersonId personId,
        string firstName,
        string lastName,
        string email,
        string password) : base(personId, firstName, lastName, email, password)
    { 
        LogUserCreated();
    }

    public static User Create(
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

    private void LogUserCreated()
    {
        Console.WriteLine($"User created: \nUser Id: {Id.Value}\nFirst name: {FirstName}\nLast name: {LastName}\nEmail: {Email}\nPassword: {Password}");
    }
}