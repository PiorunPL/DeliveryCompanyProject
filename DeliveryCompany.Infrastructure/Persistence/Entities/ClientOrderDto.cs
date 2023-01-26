using System;
using System.Collections.Generic;

namespace DeliveryCompany.Infrastructure.Persistence.Entities;

public partial class ClientOrderDto
{
    public string OrderId { get; set; } = null!;

    public string ClientId { get; set; } = null!;

    public DateTime DateSent { get; set; }

    public DateTime DateDelivered { get; set; }

    public string AddressSent { get; set; } = null!;

    public string AddressDelivery { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string SizeId { get; set; } = null!;

    public string Status { get; set; } = null!;
    
    public string? PathToImage { get; set; }
    public virtual ICollection<SharedOrderDto> SharedToClientsId { get; set; } = new List<SharedOrderDto>();

    public virtual ICollection<ClientDto> SharedToClients { get; } = new List<ClientDto>();

    public virtual ClientDto Client { get; set; } = null!;

    public virtual ICollection<CourierOrderDto> CourierOrders { get; } = new List<CourierOrderDto>();

    public virtual SizeDto Size { get; set; } = null!;
}
