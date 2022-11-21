using DeliveryCompany.Application.Authentication.Common;
using MediatR;

namespace DeliveryCompany.Application.Authentication.Queries.Login.Users;

public record UserLoginQuery( 
    string Email,
    string Password
) : IRequest<UserAuthenticationResult>;
