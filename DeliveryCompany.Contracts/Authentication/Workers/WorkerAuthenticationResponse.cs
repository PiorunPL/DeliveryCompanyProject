namespace DeliveryCompany.Contracts.Authentication.Workers;

public record WorkerAuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    DateTime DateBirth,
    string Address,
    string Token
);