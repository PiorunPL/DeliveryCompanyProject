namespace DeliveryCompany.Contracts.ClientOrders.Clients.Responses;

public record ClientGetAllApiResponse(
    List<ClientOrderDto> list
);

public record ClientOrderDto(
    Guid OrderId,
    string Name,
    string Status
);