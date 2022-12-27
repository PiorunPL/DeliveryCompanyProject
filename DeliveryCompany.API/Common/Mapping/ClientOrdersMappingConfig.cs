using System.Reflection.Metadata.Ecma335;
using DeliveryCompany.Application.Interfaces.ManageClientOrders.Requests;
using DeliveryCompany.Application.Interfaces.ManageClientOrders.Results;
using DeliveryCompany.Contracts.ClientOrders;
using DeliveryCompany.Domain.Common.ValueObjects;
using Mapster;

namespace DeliveryCompany.API.Common.Mapping;

public class ClientOrdersMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Create new order
        config.NewConfig<(ClientOrderCreateApiRequest, Guid),ClientOrderCreateRequest>() 
            .Map(dest => dest, src => src.Item1)
            .Map(dest => dest.ClientId, src => src.Item2);
        
        config.NewConfig<ClientOrderResult, ClientOrderAPIClientResponse>()
            .Map(dest => dest, src => src.order)
            .Map(dest => dest.OrderId, src => src.order.Id.Value)
            .Map(dest => dest.ClientId, src => src.order.ClientId.Value)
            .Map(dest => dest.SizeId, src => src.order.SizeId.Value)
            .Map(dest => dest.Status, src => src.order.Status.ToString());
    }
}