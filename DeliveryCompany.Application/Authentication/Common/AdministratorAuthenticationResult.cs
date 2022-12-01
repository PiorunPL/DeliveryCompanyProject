using DeliveryCompany.Domain.Administrators;

namespace DeliveryCompany.Application.Authentication.Common;

public record AdministratorAuthenticationResult(
    Administrator Administrator,
    string Token
);