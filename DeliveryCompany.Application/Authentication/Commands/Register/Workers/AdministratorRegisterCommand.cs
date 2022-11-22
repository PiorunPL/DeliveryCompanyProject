using DeliveryCompany.Application.Authentication.Common;
using MediatR;

namespace DeliveryCompany.Application.Authentication.Commands.Register.Workers;

public record AdministratorRegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    DateTime DateBirth,
    string Address
) : IRequest<AdministratorAuthenticationResult>;