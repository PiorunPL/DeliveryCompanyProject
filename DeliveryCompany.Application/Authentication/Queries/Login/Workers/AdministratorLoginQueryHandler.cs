using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Interfaces.InServices.Authentication;
using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Administrators;
using MediatR;

namespace DeliveryCompany.Application.Authentication.Queries.Login.Workers;

public class
    AdministratorLoginQueryHandler : IRequestHandler<AdministratorLoginQuery, AdministratorAuthenticationResult>
{
    private readonly IAdministratorRepository _administratorRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IHasher _hasher;

    public AdministratorLoginQueryHandler(IAdministratorRepository administratorRepository,
        IJwtTokenGenerator jwtTokenGenerator, IHasher hasher)
    {
        _administratorRepository = administratorRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _hasher = hasher;
    }

    public async Task<AdministratorAuthenticationResult> Handle(AdministratorLoginQuery query,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_administratorRepository.GetAdministratorByEmail(query.Email) is not Administrator administrator)
            throw new ArgumentException("Administrator with given email does not exist!");
        
        if (!_hasher.PasswordVerifier(query.Password, administrator.Salt, administrator.PasswordHash))
            throw new ArgumentException("Wrong password!");
        
        var token = _jwtTokenGenerator.GenerateToken(administrator);

        return new AdministratorAuthenticationResult(administrator, token);
    }
}