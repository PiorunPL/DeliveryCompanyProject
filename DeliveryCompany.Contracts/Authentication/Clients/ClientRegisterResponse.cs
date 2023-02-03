namespace DeliveryCompany.Contracts.Authentication.Clients;

public record ClientRegisterResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token,
    string SecretCode,
    string Entropy
);