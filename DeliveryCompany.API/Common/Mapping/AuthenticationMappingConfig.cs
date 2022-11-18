using DeliveryCompany.Application.Authentication.Commands.Register;
using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Authentication.Queries.Login;
using DeliveryCompany.Contracts.Authentication;
using Mapster;

namespace DeliveryCompany.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}