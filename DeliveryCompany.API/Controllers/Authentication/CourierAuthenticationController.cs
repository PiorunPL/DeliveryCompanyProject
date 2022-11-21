// using DeliveryCompany.Application.Authentication.Commands.Register.Workers;
// using DeliveryCompany.Application.Authentication.Common;
// using DeliveryCompany.Application.Authentication.Queries.Login;
// using DeliveryCompany.Contracts.Authentication;
// using MapsterMapper;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;

// namespace DeliveryCompany.API.Controllers.Authentication;

// [ApiController]
// [Route("auth/courier")]
// public class CourierAuthenticationController : ControllerBase
// {
//     private readonly ISender _mediator;
//     private readonly IMapper _mapper;

//     public CourierAuthenticationController(IMapper mapper, ISender mediator)
//     {
//         _mapper = mapper;
//         _mediator = mediator;
//     }

//     [HttpPost("register")]
//     public async Task<IActionResult> Register(CourierRegisterRequest request)
//     {
//         var command = _mapper.Map<CourierRegisterCommand>(request);
//         CourierAuthenticationResult authResult = await _mediator.Send(command);

//         return Ok(_mapper.Map<CourierAuthenticationResponse>(authResult));
//     }

//     [HttpPost("login")]
//     public async Task<IActionResult> Login(CourierLoginRequest request){
//         var query = _mapper.Map<CourierLoginQuery>(request);
//         CourierAuthenticationResult authResult = await _mediator.Send(query);

//         return Ok(_mapper.Map<CourierAuthenticationResponse>(authResult));
//     }
// }