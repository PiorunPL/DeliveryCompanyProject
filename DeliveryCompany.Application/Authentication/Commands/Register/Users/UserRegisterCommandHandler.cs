// using DeliveryCompany.Application.Common.Interfaces.Authentication;
using DeliveryCompany.Application.Common.Interfaces.Persistance;
using MediatR;
using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Common.Interfaces.Authentication;
using DeliveryCompany.Domain.User;

namespace DeliveryCompany.Application.Authentication.Commands.Register.Users;

public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, UserAuthenticationResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public UserRegisterCommandHandler(
        IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<UserAuthenticationResult> Handle(UserRegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            throw new ArgumentException("User with given email is already registered!");
        }

        // 2. Create user (generate Unique ID) & Persist to DB
        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password
        );

        _userRepository.Add(user);


        //3.  Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);  

        return new UserAuthenticationResult(
            user,
            token);
    }
}