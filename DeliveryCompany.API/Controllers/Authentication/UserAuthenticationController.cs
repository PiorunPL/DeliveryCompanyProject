using DeliveryCompany.Application.Authentication.Commands.Register;
using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Authentication.Queries.Login;
using DeliveryCompany.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCompany.API.Controllers.Authentication;

[ApiController]
[Route("auth/user")]
public class UserAuthenticationController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public UserAuthenticationController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        AuthenticationResult authResult = await _mediator.Send(command);

        return Ok(_mapper.Map<AuthenticationResponse>(authResult));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request){
        var query = _mapper.Map<LoginQuery>(request);
        AuthenticationResult authResult = await _mediator.Send(query);

        return Ok(_mapper.Map<AuthenticationResponse>(authResult));
    }
}