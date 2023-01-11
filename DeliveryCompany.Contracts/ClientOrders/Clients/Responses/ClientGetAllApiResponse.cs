namespace DeliveryCompany.Contracts.ClientOrders.Clients.Responses;

public record ClientGetAllApiResponse(
    List<ClientOrderDTO> list
);

public record ClientOrderDTO(
    Guid OrderId,
    string Name,
    string Status
);