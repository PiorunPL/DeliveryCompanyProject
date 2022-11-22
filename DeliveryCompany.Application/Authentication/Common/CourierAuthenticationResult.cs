using DeliveryCompany.Domain.Courier;

namespace DeliveryCompany.Application.Authentication.Common;

public record CourierAuthenticationResult(
    Courier Courier,
    string Token
);