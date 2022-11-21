using DeliveryCompany.Application.Authentication.Commands.Register.Users;
using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Authentication.Queries.Login;
using DeliveryCompany.Contracts.Authentication.Users;
using DeliveryCompany.Domain.Common.ValueObjects;
using Mapster;

namespace DeliveryCompany.API.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserRegisterRequest, UserRegisterCommand>();

        config.NewConfig<UserLoginRequest, UserLoginQuery>();

        config.NewConfig<UserAuthenticationResult, UserAuthenticationResponse>()
            .Map(dest => dest, src => src.User);

        config.NewConfig<PersonId, Guid>()
            .Map(dest => dest, src => src.Value);
    }
}