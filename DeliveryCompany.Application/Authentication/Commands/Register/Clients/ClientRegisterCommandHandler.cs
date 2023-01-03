// using DeliveryCompany.Application.Common.Interfaces.Authentication;

using MediatR;
using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Interfaces.InServices.Authentication;
using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Clients;
using Microsoft.Extensions.Logging;

namespace DeliveryCompany.Application.Authentication.Commands.Register.Clients;

public class ClientRegisterCommandHandler : IRequestHandler<ClientRegisterCommand, ClientAuthenticationResult>
{
    private readonly IClientRepository _clientRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ILogger<ClientRegisterCommandHandler> _logger;

    public ClientRegisterCommandHandler(
        IClientRepository clientRepository, IJwtTokenGenerator jwtTokenGenerator, ILogger<ClientRegisterCommandHandler> logger)
    {
        _clientRepository = clientRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _logger = logger;
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
        _logger.LogInformation("TestTest");

        _clientRepository.Add(client);


        //3.  Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(client);

        return new ClientAuthenticationResult(
            client,
            token);
    }
}