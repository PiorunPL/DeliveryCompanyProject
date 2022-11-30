using FluentValidation;

namespace DeliveryCompany.Application.Authentication.Queries.Login.Clients;

public class ClientLoginQueryValidator : AbstractValidator<ClientLoginQuery>
{
    public ClientLoginQueryValidator(){
        RuleFor( x => x.Email).NotEmpty();
        RuleFor( x => x.Password).NotEmpty();
    }
}