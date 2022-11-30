using DeliveryCompany.Application.Authentication.Common;
using MediatR;

namespace DeliveryCompany.Application.Authentication.Commands.Register.Clients;

public record ClientRegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<ClientAuthenticationResult>;

