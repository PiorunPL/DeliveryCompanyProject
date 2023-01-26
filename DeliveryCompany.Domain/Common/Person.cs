using DeliveryCompany.Domain.Common.Models;
using DeliveryCompany.Domain.Common.ValueObjects;

namespace DeliveryCompany.Domain.Common;

public abstract class Person : Entity<PersonId>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Salt { get; set; } = null!;

    protected Person(
        PersonId personId,
        string firstName,
        string lastName,
        string email,
        string passwordHash,
        string salt) : base(personId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        Salt = salt;
    }

    
}