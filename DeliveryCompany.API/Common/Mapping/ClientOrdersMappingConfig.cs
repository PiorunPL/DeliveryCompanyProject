using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Client.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Client.Results;
using DeliveryCompany.Contracts.ClientOrders;
using DeliveryCompany.Domain.Orders;
using Mapster;

namespace DeliveryCompany.API.Common.Mapping;

public class ClientOrdersMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
        //Common
        config.NewConfig<ClientOrderResult, ClientOrderAPIClientResponse>()
            .Map(dest => dest, src => src.Order)
            .Map(dest => dest.OrderId, src => src.Order.Id.Value)
            .Map(dest => dest.ClientId, src => src.Order.ClientId.Value)
            .Map(dest => dest.SizeId, src => src.Order.SizeId.Value)
            .Map(dest => dest.Status, src => src.Order.Status.ToString());

        //Create new order
        config.NewConfig<(ClientOrderCreateApiRequest, Guid),CreateRequest>() 
            .Map(dest => dest, src => src.Item1)
            .Map(dest => dest.ClientId, src => src.Item2);

        //Cancel Order
        config.NewConfig<(ClientOrderCancelApiRequest, Guid), CancelRequest>()
            .Map(dest => dest.OrderId, src => src.Item1.OrderId)
            .Map(dest => dest.ClientId, src => src.Item2);
        
        //Get Order
        config.NewConfig<(ClientOrderClientGetApiRequest, Guid), GetRequest>()
            .Map(dest => dest.OrderId, src => src.Item1.OrderId)
            .Map(dest => dest.ClientId, src => src.Item2);

        //Get All Orders
        config.NewConfig<GetAllResult, ClientGetAllApiResponse>()
            .Map(dest => dest.list, src => src.Orders);
            // .PreserveReference(true);

        config.NewConfig<ClientOrder, ClientOrderDTO>()
            .Map(dest => dest.OrderId, src => src.Id)
            .Map(dest => dest.Status, src => src.Status.ToString());
        
    }
}