namespace DeliveryCompany.Contracts.Authentication.Users;

public record UserLoginRequest(
    string Email,
    string Password
);