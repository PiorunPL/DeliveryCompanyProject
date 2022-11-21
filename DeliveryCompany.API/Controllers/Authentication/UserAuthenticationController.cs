using DeliveryCompany.Application.Authentication.Commands.Register.Users;
using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Authentication.Queries.Login.Users;
using DeliveryCompany.Contracts.Authentication.Users;
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
    public async Task<IActionResult> Register(UserRegisterRequest request)
    {
        var command = _mapper.Map<UserRegisterCommand>(request);
        UserAuthenticationResult authResult = await _mediator.Send(command);

        return Ok(_mapper.Map<UserAuthenticationResponse>(authResult));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginRequest request){
        var query = _mapper.Map<UserLoginQuery>(request);
        UserAuthenticationResult authResult = await _mediator.Send(query);

        return Ok(_mapper.Map<UserAuthenticationResponse>(authResult));
    }
}