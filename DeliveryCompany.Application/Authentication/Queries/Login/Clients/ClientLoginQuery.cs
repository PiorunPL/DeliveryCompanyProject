using DeliveryCompany.Application.Authentication.Common;
using MediatR;

namespace DeliveryCompany.Application.Authentication.Queries.Login.Clients;

public record ClientLoginQuery( 
    string Email,
    string Password
) : IRequest<ClientAuthenticationResult>;

