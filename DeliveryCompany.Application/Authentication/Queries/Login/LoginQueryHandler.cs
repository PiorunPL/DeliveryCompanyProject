using DeliveryCompany.Application.Common.Interfaces.Authentication;
using DeliveryCompany.Application.Common.Interfaces.Persistance;
using MediatR;
using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Domain.User;

namespace DeliveryCompany.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<UserLoginQuery, UserAuthenticationResult>{

    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(
        IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<UserAuthenticationResult> Handle(UserLoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
         // 1. Validate the user exists
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {   
            throw new ArgumentException("User with given email does not exist!");
        }

        // 2. Validate the password is correct
        if (user.Password != query.Password)
        {
            throw new ArgumentException("Wrong password!");
        }

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);   

        return new UserAuthenticationResult(user, token);
    }
}