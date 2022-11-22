using DeliveryCompany.Application.Authentication.Common;
using MediatR;

namespace DeliveryCompany.Application.Authentication.Queries.Login.Workers;

public record AdministratorLoginQuery(
    string Email,
    string Password
) : IRequest<AdministratorAuthenticationResult>;