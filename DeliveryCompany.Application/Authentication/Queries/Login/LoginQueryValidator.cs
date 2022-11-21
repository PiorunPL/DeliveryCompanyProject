using FluentValidation;

namespace DeliveryCompany.Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<UserLoginQuery>
{
    public LoginQueryValidator(){
        RuleFor( x => x.Email).NotEmpty();
        RuleFor( x => x.Password).NotEmpty();
    }
}