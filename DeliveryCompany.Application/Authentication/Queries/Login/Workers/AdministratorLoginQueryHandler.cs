using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Interfaces.InServices.Authentication;
using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Administrators;
using MediatR;

namespace DeliveryCompany.Application.Authentication.Queries.Login.Workers;

public class AdministratorLoginQueryHandler : IRequestHandler<AdministratorLoginQuery, AdministratorAuthenticationResult>
{
    private readonly IAdministratorRepository _administratorRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AdministratorLoginQueryHandler(IAdministratorRepository administratorRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _administratorRepository = administratorRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AdministratorAuthenticationResult> Handle(AdministratorLoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Validate the user exists
        if (_administratorRepository.GetAdministratorByEmail(query.Email) is not Administrator administrator){
            throw new ArgumentException("Administrator with given email does not exist!");
        }

        // 2. Validate the password is correct
        if (administrator.Password != query.Password)
        {
            throw new ArgumentException("Wrong password!");
        }

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(administrator);

        return new AdministratorAuthenticationResult(administrator,token);
    }


}