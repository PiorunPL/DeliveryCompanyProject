using DeliveryCompany.Application.Authentication.Common;
using MediatR;

namespace DeliveryCompany.Application.Authentication.Queries.Login;

public record LoginQuery( 
    string Email,
    string Password
) : IRequest<AuthenticationResult>;

