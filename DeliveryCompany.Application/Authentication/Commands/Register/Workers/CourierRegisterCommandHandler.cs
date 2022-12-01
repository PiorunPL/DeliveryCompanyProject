using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Common.Interfaces.Authentication;
using DeliveryCompany.Application.Interfaces.Persistence;

using DeliveryCompany.Domain.Couriers;
using MediatR;

namespace DeliveryCompany.Application.Authentication.Commands.Register.Workers;

public class CourierRegisterCommandHandler : IRequestHandler<CourierRegisterCommand, CourierAuthenticationResult>
{
    private readonly ICourierRepository _courierRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public CourierRegisterCommandHandler(ICourierRepository courierRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _courierRepository = courierRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<CourierAuthenticationResult> Handle(CourierRegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Validate the courier doesn't exist
        if (_courierRepository.GetCourierByEmail(command.Email) is not null)
        {
            throw new ArgumentException("Administrator with given email is already registered!");
        }

        // 2. Create Courier
        var courier = Courier.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password,
            command.DateBirth,
            command.Address
        );

        _courierRepository.Add(courier);

        // 3. Create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(courier);

        return new CourierAuthenticationResult(
            courier,
            token
        );
    }
}

