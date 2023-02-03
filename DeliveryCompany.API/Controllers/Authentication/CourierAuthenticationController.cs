// using DeliveryCompany.Application.Authentication.Commands.Register.Workers;
// using DeliveryCompany.Application.Authentication.Common;
// using DeliveryCompany.Application.Authentication.Queries.Login.Workers;
// using DeliveryCompany.Contracts.Authentication.Workers;
// using MapsterMapper;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
//
// namespace DeliveryCompany.API.Controllers.Authentication;
//
// [ApiController]
// [Route("auth/courier")]
// public class CourierAuthenticationController : ControllerBase
// {
//     private readonly ISender _mediator;
//     private readonly IMapper _mapper;
//
//     public CourierAuthenticationController(IMapper mapper, ISender mediator)
//     {
//         _mapper = mapper;
//         _mediator = mediator;
//     }
//
//     [HttpPost("register")]
//     [Authorize(Roles = "Administrator")]
//     public async Task<IActionResult> Register(WorkerRegisterRequest request)
//     {
//         var command = _mapper.Map<CourierRegisterCommand>(request);
//         CourierAuthenticationResult authResult = await _mediator.Send(command);
//
//         return Ok(_mapper.Map<WorkerAuthenticationResponse>(authResult));
//     }
//
//     [HttpPost("login")]
//     public async Task<IActionResult> Login(WorkerLoginRequest request){
//         var query = _mapper.Map<CourierLoginQuery>(request);
//         CourierAuthenticationResult authResult = await _mediator.Send(query);
//
//         return Ok(_mapper.Map<WorkerAuthenticationResponse>(authResult));
//     }
// }