using DeliveryCompany.Domain.Common.Models;
using DeliveryCompany.Domain.Sizes.ValueObjects;

namespace DeliveryCompany.Domain.Sizes;

public sealed class Size : Entity<SizeId>
{

    public string Name { get; set; }
    public double Price { get; set; }
    //TODO: Add maxiumum size dimensions (x,y,z)

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
        string log = "Size created:";
        log += $"\n\tSize Id: {Id.Value.ToString()}";
        log += $"\n\tName: {Name}";
        log += $"\n\tPrice: {Price}";
        Console.WriteLine(log);
    }
}