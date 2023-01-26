using DeliveryCompany.Domain.Common;
using DeliveryCompany.Domain.Common.ValueObjects;

namespace DeliveryCompany.Domain.Couriers;

public sealed class Courier : Person
{
    public DateTime DateBirth { get; set; }
    public string Address { get; set; }

    public Courier(
        PersonId personId,
        string firstName,
        string lastName,
        string email,
        string passwordHash,
        string salt,
        DateTime dateBirth,
        string address) : base(personId, firstName, lastName, email, passwordHash, salt)
    {
        DateBirth = dateBirth;
        Address = address;
        LogCourierCreated();
    }

    public static Courier Create(
        string firstName,
        string lastName,
        string email,
        string password,
        string salt,
        DateTime dateBirth,
        string address)
    {
        return new(
            PersonId.CreateUnique(),
            firstName,
            lastName,
            email,
            password,
            salt,
            dateBirth,
            address);
    }

    private void LogCourierCreated()
    {
        string log = "Courier created:";
        log += $"\n\tId: {Id.Value.ToString()}";
        log += $"\n\tFirst name: {FirstName}";
        log += $"\n\tLast name: {LastName}";
        log += $"\n\tEmail: {Email}";
        log += $"\n\tPassword: {PasswordHash}";
        log += $"\n\tDateBirth: {DateBirth.ToString()}";
        log += $"\n\tAddress: {Address}";
        Console.WriteLine(log);
    }
}