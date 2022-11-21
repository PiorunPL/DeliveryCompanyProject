using DeliveryCompany.Domain.User;

namespace DeliveryCompany.Application.Authentication.Common;

public record UserAuthenticationResult(
    User User,
    string Token
);