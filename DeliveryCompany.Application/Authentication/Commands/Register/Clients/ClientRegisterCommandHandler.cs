using MediatR;
using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Common;
using DeliveryCompany.Application.Interfaces.InServices.Authentication;
using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Clients;
using Microsoft.Extensions.Logging;

namespace DeliveryCompany.Application.Authentication.Commands.Register.Clients;

public class ClientRegisterCommandHandler : IRequestHandler<ClientRegisterCommand, ClientRegisterResult>
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

    public async Task<ClientRegisterResult> Handle(ClientRegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_clientRepository.GetClientByEmail(command.Email) is not null)
            throw new ArgumentException("User with given email is already registered!");

        if (!ValidateData(command.Email, command.FirstName, command.LastName, command.Password))
            throw new ArgumentException("Data was not validated");
        
        //TODO: VERIFY PASSWORD: dictionaryAttack
        double entropy = EntropyCalcuator.GetEntropy(command.Password);
        
        if (entropy < 40)
            throw new ArgumentException("Password is weak!");
        
        var hasherResponse = _hasher.HashPassword(command.Password);

        var secretCode = CodeGenerator.GenerateSecretCode();

        var hasherResponseCode = _hasher.HashPassword(secretCode);
        
        var client = Client.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            hasherResponse.hash,
            hasherResponse.salt,
            hasherResponseCode.hash,
            hasherResponseCode.salt
        );
        _clientRepository.Add(client);

        var token = _jwtTokenGenerator.GenerateToken(client);

        return new ClientRegisterResult(
            client,
            token,
            secretCode,
            entropy.ToString());
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