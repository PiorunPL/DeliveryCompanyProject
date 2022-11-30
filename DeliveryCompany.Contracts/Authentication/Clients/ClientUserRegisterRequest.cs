namespace DeliveryCompany.Contracts.Authentication.Clients;

public record ClientRegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password
);