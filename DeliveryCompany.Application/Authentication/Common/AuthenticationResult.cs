using DeliveryCompany.Domain.User;

namespace DeliveryCompany.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);