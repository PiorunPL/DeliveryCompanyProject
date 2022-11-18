// using DeliveryCompany.Application.Common.Interfaces.Authentication;
using DeliveryCompany.Application.Common.Interfaces.Persistance;
using MediatR;
using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Domain.User;
using DeliveryCompany.Application.Common.Interfaces.Authentication;

namespace DeliveryCompany.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(
        IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            throw new ArgumentException("User with given email is already registered!");
        }

        // 2. Create user (generate Unique ID) & Persist to DB
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        _userRepository.Add(user);


        //3.  Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);  

        return new AuthenticationResult(
            user,
            token);
    }
}