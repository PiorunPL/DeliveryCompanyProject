using DeliveryCompany.Domain.Administrator;

namespace DeliveryCompany.Application.Authentication.Common;

public record AdministratorAuthenticationResult(
    Administrator Administrator,
    string Token
);