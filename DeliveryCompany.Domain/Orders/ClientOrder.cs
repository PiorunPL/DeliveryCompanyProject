using DeliveryCompany.Domain.Common.Models;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Orders.Enitities;
using DeliveryCompany.Domain.Orders.ValueObjects;
using DeliveryCompany.Domain.Sizes.ValueObjects;

namespace DeliveryCompany.Domain.Orders;

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
    public List<CourierOrder> CourierOrders = new List<CourierOrder>();

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
        if (name == null || name.Equals(""))
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
        string log = "Client order created:";
        log += $"\n\tOrder ID: {Id.Value.ToString()}";
        log += $"\n\tClient ID: {ClientId.Value.ToString()}";
        log += $"\n\tDate of Send: {DateSent.ToString()}";
        log += $"\n\tDate of delivery: {DateDelivered.ToString()}";
        log += $"\n\tAddress of send: {AddressSent}";
        log += $"\n\tAddress of delivery: {AddressDelivery}";
        log += $"\n\tName: {Name}";
        log += $"\n\tSize ID: {SizeId.Value.ToString()}";
        log += $"\n\tStatus: {Status}, {nameof(Status)}";
        Console.WriteLine(log);
    }

}