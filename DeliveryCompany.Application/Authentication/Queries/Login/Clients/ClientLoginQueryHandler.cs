using MediatR;
using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Interfaces.InServices.Authentication;
using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Clients;

namespace DeliveryCompany.Application.Authentication.Queries.Login.Clients;

public class ClientLoginQueryHandler : IRequestHandler<ClientLoginQuery, ClientAuthenticationResult>
{
    private readonly IClientRepository _clientRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IHasher _hasher;

    public ClientLoginQueryHandler(
        IClientRepository clientRepository, IJwtTokenGenerator jwtTokenGenerator, IHasher hasher)
    {
        _clientRepository = clientRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _hasher = hasher;
    }

    public async Task<ClientAuthenticationResult> Handle(ClientLoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        if (_clientRepository.GetClientByEmail(query.Email) is not Client client)
            throw new ArgumentException("User with given email does not exist!");

        if (!_hasher.PasswordVerifier(query.Password, client.Salt, client.PasswordHash))
            throw new ArgumentException("Wrong password!");

        var token = _jwtTokenGenerator.GenerateToken(client);

        return new ClientAuthenticationResult(client, token);
    }
}