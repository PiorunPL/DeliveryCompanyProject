using DeliveryCompany.Domain.Common.Models;
using DeliveryCompany.Domain.Size.ValueObjects;

namespace DeliveryCompany.Domain.Size;

public sealed class Size : Entity<SizeId>
{

    string Name { get; set; }
    double Price { get; set; }

    private Size(
        SizeId id,
        string name,
        double price
    ) : base(id)
    {
        Name = name;
        Price = price;
        LogSizeCreated();
    }


    public static Size Create(
        string name,
        double price
    )
    {
        return new(
            SizeId.CreateUnique(),
            name,
            price);
    }

    private void LogSizeCreated()
    {
        Console.WriteLine($"Size created:\n\tSize Id: {Id.Value}\n\tName: {Name}\n\tPrice: {Price}");
    }
}