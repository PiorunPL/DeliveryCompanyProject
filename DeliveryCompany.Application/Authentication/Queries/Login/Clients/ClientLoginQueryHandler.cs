using DeliveryCompany.Application.Common.Interfaces.Authentication;
using DeliveryCompany.Application.Interfaces.Persistence;
using MediatR;
using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Domain.Client;

namespace DeliveryCompany.Application.Authentication.Queries.Login.Clients;

public class ClientLoginQueryHandler : IRequestHandler<ClientLoginQuery, ClientAuthenticationResult>{

    private readonly IClientRepository _clientRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public ClientLoginQueryHandler(
        IClientRepository clientRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _clientRepository = clientRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ClientAuthenticationResult> Handle(ClientLoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
         // 1. Validate the user exists
        if (_clientRepository.GetClientByEmail(query.Email) is not Client client)
        {   
            throw new ArgumentException("User with given email does not exist!");
        }

        // 2. Validate the password is correct
        if (client.Password != query.Password)
        {
            throw new ArgumentException("Wrong password!");
        }

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(client);   

        return new ClientAuthenticationResult(client, token);
    }
}