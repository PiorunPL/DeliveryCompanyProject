using DeliveryCompany.Application.Authentication.Commands.Register;
using DeliveryCompany.Application.Authentication.Common;
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
}