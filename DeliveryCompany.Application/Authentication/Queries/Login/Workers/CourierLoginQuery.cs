using DeliveryCompany.Application.Authentication.Common;
using MediatR;

namespace DeliveryCompany.Application.Authentication.Queries.Login.Workers;

public record CourierLoginQuery(
    string Email,
    string Password
) : IRequest<CourierAuthenticationResult>;
