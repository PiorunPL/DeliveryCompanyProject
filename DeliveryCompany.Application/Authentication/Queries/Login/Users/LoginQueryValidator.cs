using FluentValidation;

namespace DeliveryCompany.Application.Authentication.Queries.Login.Users;

public class UserLoginQueryValidator : AbstractValidator<UserLoginQuery>
{
    public UserLoginQueryValidator(){
        RuleFor( x => x.Email).NotEmpty();
        RuleFor( x => x.Password).NotEmpty();
    }
}