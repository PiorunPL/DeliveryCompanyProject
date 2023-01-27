using MediatR;
using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Common;
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
    private readonly IHasher _hasher;

    public ClientRegisterCommandHandler(
        IClientRepository clientRepository, IJwtTokenGenerator jwtTokenGenerator, ILogger<ClientRegisterCommandHandler> logger, IHasher hasher)
    {
        _clientRepository = clientRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _logger = logger;
        _hasher = hasher;
    }

    public async Task<ClientAuthenticationResult> Handle(ClientRegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_clientRepository.GetClientByEmail(command.Email) is not null)
            throw new ArgumentException("User with given email is already registered!");

        if (!ValidateData(command.Email, command.FirstName, command.LastName, command.Password))
            throw new ArgumentException("Data was not validated");
        
        //TODO: VERIFY PASSWORD: Entropy and dictionaryAttack
        if (EntropyCalcuator.GetEntropy(command.Password) < 40)
            throw new ArgumentException("Password is weak!");
        
        var hasherResponse = _hasher.HashPassword(command.Password);

        var client = Client.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            hasherResponse.hash,
            hasherResponse.salt
        );

        _clientRepository.Add(client);


        //3.  Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(client);

        return new ClientAuthenticationResult(
            client,
            token);
    }

    private bool ValidateData(string email, string firstName, string lastName, string password)
    {
        if (!Validator.ValidateEmail(email))
            return false;
        if (!Validator.ValidateName(firstName))
            return false;
        if (!Validator.ValidateName(lastName))
            return false;
        if (!Validator.ValidatePassword(password))
            return false;

        return true;
    }

    
}