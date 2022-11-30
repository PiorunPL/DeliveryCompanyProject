using DeliveryCompany.Application.Authentication.Commands.Register.Clients;
using DeliveryCompany.Application.Authentication.Commands.Register.Workers;
using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Authentication.Queries.Login.Clients;
using DeliveryCompany.Application.Authentication.Queries.Login.Workers;
using DeliveryCompany.Contracts.Authentication.Clients;
using DeliveryCompany.Contracts.Authentication.Workers;
using DeliveryCompany.Domain.Common.ValueObjects;
using Mapster;

namespace DeliveryCompany.API.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // CLIENT
        config.NewConfig<ClientRegisterRequest, ClientRegisterCommand>();

        config.NewConfig<UserLoginRequest, ClientLoginQuery>();

        config.NewConfig<ClientAuthenticationResult, ClientAuthenticationResponse>()
            .Map(dest => dest, src => src.Client);

        // ADMINISTRATOR
        config.NewConfig<WorkerRegisterRequest, AdministratorRegisterCommand>();

        config.NewConfig<WorkerLoginRequest, AdministratorLoginQuery>();

        config.NewConfig<AdministratorAuthenticationResult, WorkerAuthenticationResponse>()
            .Map(dest => dest, src => src.Administrator);

        // COURIER
        config.NewConfig<WorkerRegisterRequest, CourierRegisterCommand>();

        config.NewConfig<WorkerLoginRequest, CourierLoginQuery>();

        config.NewConfig<CourierAuthenticationResult, WorkerAuthenticationResponse>()
            .Map(dest => dest, src => src.Courier);

        // OTHER

        config.NewConfig<PersonId, Guid>()
            .Map(dest => dest, src => src.Value);
    }
}