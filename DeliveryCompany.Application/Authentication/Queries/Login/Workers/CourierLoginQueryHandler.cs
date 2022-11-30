using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Common.Interfaces.Authentication;
using DeliveryCompany.Application.Interfaces.Persistence;
using DeliveryCompany.Domain.Administrator;
using DeliveryCompany.Domain.Courier;
using MediatR;

namespace DeliveryCompany.Application.Authentication.Queries.Login.Workers;

public class CourierLoginQueryHandler : IRequestHandler<CourierLoginQuery, CourierAuthenticationResult>
{
    private readonly ICourierRepository _courierRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public CourierLoginQueryHandler(ICourierRepository courierRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _courierRepository = courierRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<CourierAuthenticationResult> Handle(CourierLoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Validate the user exists
        if (_courierRepository.GetCourierByEmail(query.Email) is not Courier courier){
            throw new ArgumentException("Administrator with given email does not exist!");
        }

        // 2. Validate the password is correct
        if (courier.Password != query.Password)
        {
            throw new ArgumentException("Wrong password!");
        }

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(courier);

        return new CourierAuthenticationResult(courier,token);
    }


}