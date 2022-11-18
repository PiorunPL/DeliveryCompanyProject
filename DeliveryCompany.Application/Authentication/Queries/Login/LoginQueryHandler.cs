using DeliveryCompany.Application.Common.Interfaces.Authentication;
using DeliveryCompany.Application.Common.Interfaces.Persistance;
using MediatR;
using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Domain.User;

namespace DeliveryCompany.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>{

    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
         // 1. Validate the user exists
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {   
            throw new Exception();
        }

        // 2. Validate the password is correct
        if (user.Password != query.Password)
        {
            throw new Exception();
        }

        // 3. Create JWT token
        var token = "Token";   

        return new AuthenticationResult(user, token);
    }
}