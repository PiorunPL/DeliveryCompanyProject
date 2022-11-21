using System.ComponentModel.DataAnnotations;
using DeliveryCompany.Domain.Common;
using DeliveryCompany.Domain.Common.ValueObjects;

namespace DeliveryCompany.Domain.Courier;

public class Courier : Person
{
    public DateTime DateBirth { get; set; }
    public string Address { get; set; }
    private Courier(
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
        LogCourierCreated();
    }

    public Courier Create(
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

    private void LogCourierCreated()
    {
        Console.WriteLine($"Courier created: \nId: {Id.Value}\nFirst name: {FirstName}\nLast name: {LastName}\nEmail: {Email}\nPassword: {Password}\nDateBirth: {DateBirth}\nAddress: {Address}");
    }
}