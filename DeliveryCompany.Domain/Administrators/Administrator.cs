using DeliveryCompany.Domain.Common;
using DeliveryCompany.Domain.Common.ValueObjects;

namespace DeliveryCompany.Domain.Administrators;

public class Administrator : Person
{
    public DateTime DateBirth { get; set; }
    public string Address { get; set; }
    private Administrator(
        PersonId personId,
        string firstName,
        string lastName,
        string email,
        string password,
        DateTime dateBirth,
        string address) : base(personId, firstName, lastName, email, password)
    {
        DateBirth = dateBirth;
        Address = address;
        LogAdministratorCreated();
    }

    public static Administrator Create(
        string firstName,
        string lastName,
        string email,
        string password,
        DateTime dateBirth,
        string address)
    {
        return new(
            PersonId.CreateUnique(),
            firstName,
            lastName,
            email,
            password,
            dateBirth,
            address);
    }

    private void LogAdministratorCreated()
    {
        string log = $"Administrator created:";
        log += $"\n\tID: {Id.Value.ToString()}";
        log += $"\n\tFirst name: {FirstName}";
        log += $"\n\tLast name: {LastName}";
        log += $"\n\tEmail: {Email}";
        log += $"\n\tPassword: {Password}";
        log += $"\n\tDateBirth: {DateBirth.ToString()}";
        log += $"\n\tAddress: {Address}";
        Console.WriteLine(log);
    }
}