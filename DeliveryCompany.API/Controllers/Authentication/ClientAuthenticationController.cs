using DeliveryCompany.Application.Authentication.Commands.Register.Clients;
using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Authentication.Queries.Login.Clients;
using DeliveryCompany.Contracts.Authentication.Clients;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCompany.API.Controllers.Authentication;

[ApiController]
[Route("auth/client")]
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
    public async Task<IActionResult> Register(ClientRegisterRequest request)
    {
        var command = _mapper.Map<ClientRegisterCommand>(request);
        ClientAuthenticationResult authResult = await _mediator.Send(command);

        return Ok(_mapper.Map<ClientAuthenticationResponse>(authResult));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginRequest request){
        var query = _mapper.Map<ClientLoginQuery>(request);
        ClientAuthenticationResult authResult = await _mediator.Send(query);

        return Ok(_mapper.Map<ClientAuthenticationResponse>(authResult));
    }
}