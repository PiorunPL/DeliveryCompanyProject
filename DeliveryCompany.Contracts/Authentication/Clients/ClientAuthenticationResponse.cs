namespace DeliveryCompany.Contracts.Authentication.Clients;

public record ClientAuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
);