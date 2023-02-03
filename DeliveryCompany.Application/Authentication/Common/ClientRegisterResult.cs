using DeliveryCompany.Domain.Clients;

namespace DeliveryCompany.Application.Authentication.Common;

public record ClientRegisterResult(
    Client Client,
    string Token,
    string SecretCode,
    string Entropy
);