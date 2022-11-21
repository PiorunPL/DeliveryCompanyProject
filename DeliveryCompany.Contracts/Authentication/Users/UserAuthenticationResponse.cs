namespace DeliveryCompany.Contracts.Authentication.Users;

public record UserAuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
);