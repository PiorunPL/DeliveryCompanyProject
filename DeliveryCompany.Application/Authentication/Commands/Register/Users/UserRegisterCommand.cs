using DeliveryCompany.Application.Authentication.Common;
using MediatR;

namespace DeliveryCompany.Application.Authentication.Commands.Register.Users;

public record UserRegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<UserAuthenticationResult>;

