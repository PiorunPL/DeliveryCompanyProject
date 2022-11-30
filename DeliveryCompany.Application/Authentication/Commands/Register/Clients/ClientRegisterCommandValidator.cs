using FluentValidation;

namespace DeliveryCompany.Application.Authentication.Commands.Register.Clients;

public class ClientRegisterCommandValidator : AbstractValidator<ClientRegisterCommand>
{
    public ClientRegisterCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}