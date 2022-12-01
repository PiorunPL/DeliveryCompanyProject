using DeliveryCompany.Domain.Common.Models;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Order.ValueObjects;
using DeliveryCompany.Domain.Size.ValueObjects;

namespace DeliveryCompany.Domain.Order;

public sealed class ClientOrder : Entity<ClientOrderId>
{
    public PersonId ClientId { get; set; }
    public DateTime DateSent { get; set; }
    public DateTime DateDelivered { get; set; }
    public string AddressSent { get; set; }
    public string AddressDelivery { get; set; }
    public string Name { get; set; }
    public SizeId SizeId { get; set; }
    public ClientOrderStatus Status { get; set; }


    private ClientOrder(
        ClientOrderId orderId,
        PersonId clientId,
        DateTime dateSent,
        DateTime dateDelivered,
        string addressSent,
        string addressDelivery,
        string name,
        SizeId sizeId,
        ClientOrderStatus status) : base(orderId)
    {
        ClientId = clientId;
        DateSent = dateSent;
        DateDelivered = dateDelivered;
        AddressSent = addressSent;
        AddressDelivery = addressDelivery;
        Name = setCorrectName(name, orderId);
        SizeId = sizeId;
        Status = status;
        LogClientOrderCreated();
    }

    public static ClientOrder Create(
        PersonId clientId,
        DateTime dateSent,
        DateTime dateDelivered,
        string addressSent,
        string addressDelivery,
        string name,
        SizeId sizeId,
        ClientOrderStatus status)
    {
        return new(
            ClientOrderId.CreateUnique(),
            clientId,
            dateSent,
            dateDelivered,
            addressSent,
            addressDelivery,
            name,
            sizeId,
            status
        );
    }

    private string setCorrectName(string name, ClientOrderId orderId)
    {
        if (name == null || name == "")
        {
            return orderId.Value.ToString();
        }
        else
        {
            return name;
        }
    }


    private void LogClientOrderCreated()
    {
        Console.WriteLine($"Client order created:\n\tOrder ID: {Id}\n\tClient ID: {ClientId}\n\tDate of Send: {DateSent}\n\tDate of delivery: {DateDelivered}\n\tAddress of send: {AddressSent}\n\tAddress of delivery: {AddressDelivery}\n\tName: {Name}\n\tSize ID: {SizeId}\n\tStatus: {Status}");
    }

}