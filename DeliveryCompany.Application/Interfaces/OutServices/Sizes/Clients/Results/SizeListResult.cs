using DeliveryCompany.Domain.Sizes;

namespace DeliveryCompany.Application.Interfaces.OutServices.Sizes.Clients.Results;

public record SizeListResult(List<Size> sizes);