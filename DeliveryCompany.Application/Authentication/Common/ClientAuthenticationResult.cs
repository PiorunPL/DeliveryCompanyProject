using DeliveryCompany.Domain.Clients;

namespace DeliveryCompany.Application.Authentication.Common;

public record ClientAuthenticationResult(
    Client Client,
    string Token
);