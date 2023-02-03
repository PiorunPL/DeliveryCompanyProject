using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Common;
using DeliveryCompany.Application.Interfaces.InServices.Authentication;
using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Application.Interfaces.OutServices.Clients.Clients;
using DeliveryCompany.Domain.Clients;

namespace DeliveryCompany.Application.Clients;

public class ClientManage : IClientManage
{
    private readonly IClientRepository _clientRepository;
    private readonly IHasher _hasher;

    public ClientManage(IClientRepository clientRepository, IHasher hasher)
    {
        _clientRepository = clientRepository;
        _hasher = hasher;
    }

    public void changePassword(Guid clientId, string password)
    {
        if (!Validator.ValidatePassword(password))
            throw new ArgumentException("Data is not valid!");

        if (EntropyCalcuator.GetEntropy(password) < 40)
            throw new ArgumentException("Password is weak!");

        Client? client = _clientRepository.GetClientById(clientId);
        if (client is null)
            throw new ArgumentException("Client with given ID does not exist");

        var hashResult = _hasher.HashPassword(password);
        client.PasswordHash = hashResult.hash;
        client.Salt = hashResult.salt;

        _clientRepository.Update(client);
    }

    public void restorePassword(string email, string password, string secretCode)
    {
 
        if (!ValidateData(email,password,secretCode))
            throw new ArgumentException("Data is not valid!");

        if (EntropyCalcuator.GetEntropy(password) < 40)
            throw new ArgumentException("Password is weak!");

        Client? client = _clientRepository.GetClientByEmail(email);
        if (client is null)
            throw new ArgumentException("Client with given email does not exist");

        var hashResult = _hasher.HashPassword(password);
        client.PasswordHash = hashResult.hash;
        client.Salt = hashResult.salt;

        _clientRepository.Update(client);
    }

    private bool ValidateData(string email, string password, string secretCode)
    {
        if (!Validator.ValidateEmail(email))
            return false;
        if (!Validator.ValidatePassword(password))
            return false;
        if (!Validator.ValidateSecretCode(secretCode))
            return false;
        return true;
    }
}