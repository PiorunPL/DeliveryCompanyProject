namespace DeliveryCompany.Contracts.Authentication.Clients;

public record UserLoginRequest(
    string Email,
    string Password
);