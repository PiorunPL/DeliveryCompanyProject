using DeliveryCompany.Domain.Sizes;

namespace DeliveryCompany.Application.Interfaces.OutServices.Sizes.Administrators.Results;

public record SizeListResult(List<Size> sizes);