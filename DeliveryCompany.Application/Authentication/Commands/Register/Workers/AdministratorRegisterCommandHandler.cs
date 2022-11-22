using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Common.Interfaces.Authentication;
using DeliveryCompany.Application.Interfaces.Persistence;
using DeliveryCompany.Domain.Administrator;
using MediatR;

namespace DeliveryCompany.Application.Authentication.Commands.Register.Workers;

public class AdministratorRegisterCommandHandler : IRequestHandler<AdministratorRegisterCommand, AdministratorAuthenticationResult>
{
    private readonly IAdministratorRepository _administratorRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AdministratorRegisterCommandHandler(IAdministratorRepository administratorRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _administratorRepository = administratorRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AdministratorAuthenticationResult> Handle(AdministratorRegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Validate the administrator doesn't exist
        if (_administratorRepository.GetAdministratorByEmail(command.Email) is not null)
        {
            throw new ArgumentException("Administrator with given email is already registered!");
        }

        // 2. Create Administrator
        var administrator = Administrator.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password,
            command.DateBirth,
            command.Address
        );

        _administratorRepository.Add(administrator);

        // 3. Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(administrator);

        return new AdministratorAuthenticationResult(
            administrator,
            token
        );
    }
}

