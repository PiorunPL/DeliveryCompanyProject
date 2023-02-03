using DeliveryCompany.API.Common;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients.Results;
using DeliveryCompany.Application.Interfaces.OutServices.Clients.Clients;
using DeliveryCompany.Contracts.ClientOrders.Clients.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCompany.API.Controllers.Clients;

[ApiController]
[Authorize(Roles = "Client")]
[Route("manageClient/client")]
public class ClientManageController : ControllerBase
{
    private readonly IClientManage _clientManage;

    public ClientManageController(IClientManage clientManage)
    {
        _clientManage = clientManage;
    }

    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword(PasswordRequest request)
    {
        Guid clientId = CommonMethods.GetPersonsGuid(this.HttpContext);

        try
        {
            await Task.Run(() => _clientManage.changePassword(clientId, request.password));
        }
        catch (ArgumentException e)
        {
            return BadRequest();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }


        return Ok();
    }
    
    [AllowAnonymous]
    [HttpPost("restore-password")]
    public async Task<IActionResult> CreateNewOrder(PasswordRecoverRequest request)
    {
        try
        {
            await Task.Run(() => _clientManage.restorePassword(request.email, request.password, request.secretCode));
        }
        catch (ArgumentException e)
        {
            return BadRequest();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }


        return Ok();
    }

    public record PasswordRequest(string password);

    public record PasswordRecoverRequest(string email, string password, string secretCode);
}