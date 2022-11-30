using DeliveryCompany.Application.Authentication.Common;
using MediatR;

namespace DeliveryCompany.Application.Authentication.Commands.Register.Workers;

public record CourierRegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    DateTime DateBirth,
    string Address
) : IRequest<CourierAuthenticationResult>;