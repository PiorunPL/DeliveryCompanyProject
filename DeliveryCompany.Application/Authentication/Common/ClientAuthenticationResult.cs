using DeliveryCompany.Domain.Client;

namespace DeliveryCompany.Application.Authentication.Common;

public record ClientAuthenticationResult(
    Client Client,
    string Token
);