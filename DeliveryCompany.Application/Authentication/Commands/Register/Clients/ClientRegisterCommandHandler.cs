// using DeliveryCompany.Application.Common.Interfaces.Authentication;
using DeliveryCompany.Application.Interfaces.Persistence;
using MediatR;
using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Common.Interfaces.Authentication;
using DeliveryCompany.Domain.Client;

namespace DeliveryCompany.Application.Authentication.Commands.Register.Clients;

public class ClientRegisterCommandHandler : IRequestHandler<ClientRegisterCommand, ClientAuthenticationResult>
{
    private readonly IClientRepository _clientRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public ClientRegisterCommandHandler(
        IClientRepository clientRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _clientRepository = clientRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ClientAuthenticationResult> Handle(ClientRegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Validate the user doesn't exist
        if (_clientRepository.GetClientByEmail(command.Email) is not null)
        {
            throw new ArgumentException("User with given email is already registered!");
        }

        // 2. Create user (generate Unique ID) & Persist to DB
        var client = Client.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password
        );

        _clientRepository.Add(client);


        //3.  Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(client);

        return new ClientAuthenticationResult(
            client,
            token);
    }
}