using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Interfaces.InServices.Authentication;
using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Couriers;
using MediatR;

namespace DeliveryCompany.Application.Authentication.Queries.Login.Workers;

public class CourierLoginQueryHandler : IRequestHandler<CourierLoginQuery, CourierAuthenticationResult>
{
    private readonly ICourierRepository _courierRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IHasher _hahser;

    public CourierLoginQueryHandler(ICourierRepository courierRepository, IJwtTokenGenerator jwtTokenGenerator,
        IHasher hahser)
    {
        _courierRepository = courierRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _hahser = hahser;
    }

    public async Task<CourierAuthenticationResult> Handle(CourierLoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_courierRepository.GetCourierByEmail(query.Email) is not Courier courier)
            throw new ArgumentException("Administrator with given email does not exist!");


        if (!_hahser.PasswordVerifier(query.Password, courier.Salt, courier.PasswordHash))
            throw new ArgumentException("Wrong password!");

        var token = _jwtTokenGenerator.GenerateToken(courier);

        return new CourierAuthenticationResult(courier, token);
    }
}