namespace DeliveryCompany.Contracts.ClientOrders;

public record ClientGetAllApiResponse(
    List<ClientOrderDTO> list
);

public record ClientOrderDTO(
    Guid OrderId,
    string Name,
    string Status
);