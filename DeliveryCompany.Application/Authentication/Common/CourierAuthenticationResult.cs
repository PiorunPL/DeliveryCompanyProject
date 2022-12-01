using DeliveryCompany.Domain.Couriers;

namespace DeliveryCompany.Application.Authentication.Common;

public record CourierAuthenticationResult(
    Courier Courier,
    string Token
);